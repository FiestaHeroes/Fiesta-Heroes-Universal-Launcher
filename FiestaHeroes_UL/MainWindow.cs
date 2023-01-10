using MadMilkman.Ini;
using SharpCompress.Archive;
using SharpCompress.Common;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FiestaLauncher
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        WebClient WC = new WebClient();
        IniFile LocalINI = new IniFile();
        IniFile ServerINI = new IniFile();

        private async void MainWindow_LoadAsync(object sender, EventArgs e)
        {
            // Check for required files.

            // This library is used to read/write the .ini configuration files.
            if (!File.Exists("MadMilkman.Ini.dll"))
            {
                MessageBox.Show("Oops, MadMilkman.Ini.dll is missing. Please contact your Administrator.");
                Application.Exit();
            }

            // This library is used to extract our .rar archive.
            if (!File.Exists("SharpCompress.dll"))
            {
                MessageBox.Show("Oops, SharpCompress.dll is missing. Please contact your Administrator.");
                Application.Exit();
            }

            // The location of the client-side configuration.
            if (!File.Exists("./reslauncher/launcher.ini"))
            {
                MessageBox.Show("Oops, launcher.ini is missing. Please contact your Administrator.");
                Application.Exit();
            }

            // Local configuration file.
            LocalINI.Load("./reslauncher/launcher.ini");
            string ServerIP = LocalINI.Sections[0].Keys[0].Value;

            // Server configuration file.
            ServerINI.Load(WC.OpenRead(($"{ServerIP}Config.ini")));
            string ServerSettingsWindowTitle = ServerINI.Sections[0].Keys[0].Value;
            string ServerSettingsBanner = ServerINI.Sections[0].Keys[1].Value;

            // Application Settings.
            // This is read from your server configuration file.
            
            // Window title. Your server name for example.
            Text = ServerSettingsWindowTitle;

            // Banner image. Your server logo for example. 
            // Image resolution: 500x95
            BannerImage.Image = new Bitmap(new MemoryStream(WC.DownloadData(ServerSettingsBanner)));

            // Slight delay for calling the update section. Delay is not needed. But, I like it.
            await Task.Delay(300);
            await CheckForUpdates();
        }
        private async Task CheckForUpdates()
        {
            // Defining variables from our configuration file.    
            string ServerIP = LocalINI.Sections[0].Keys[0].Value;
            string ServerPatchVersion = ServerINI.Sections[2].Keys[0].Value;
            string ServerPatchDownloadDIR = ServerINI.Sections[6].Keys[0].Value;
            string ServerFileName = ServerINI.Sections[1].Keys[0].Value;
            string ServerExtension = ServerINI.Sections[1].Keys[1].Value;

            WC.Proxy = null;

            string LocalPatchVersion = LocalINI.Sections[0].Keys[1].Value;

            int Client = int.Parse(LocalPatchVersion);
            int Server = int.Parse(ServerPatchVersion);

            for (var i = Client; i <= Server; i++)
            {
                if (Client == Server)
                {
                    Finish();
                }
                else
                {
                    Client++;

                    FileNameLabel.Text = $" Downloading patch{Client}.rar...";
                    WC.DownloadProgressChanged += UpdateDL_ProgressChanged;
                    await WC.DownloadFileTaskAsync(new Uri($"{ServerIP}{ServerPatchDownloadDIR}/{ServerFileName}{Client}{ServerExtension}"), $"./{ServerFileName}{Client}{ServerExtension}");

                    ChangeLine($"PatchVersion={Client}", "./reslauncher/launcher.ini", 3);

                    IArchive archive = ArchiveFactory.Open($"{ServerFileName}{Client}{ServerExtension}");
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                        {
                            FileNameLabel.Text = $" Extracting {ServerFileName}{Client}{ServerExtension}...";
                            textBox1.Text = entry.FilePath.ToString();
                            await Task.Delay(100);
                            entry.WriteToDirectory("./", ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                        }
                    }

                    if (archive.IsComplete)
                    {
                        archive.Dispose();
                        File.Delete($"{ServerFileName}{Client}{ServerExtension}");
                        DownloadProgressLabel.ResetText();
                        textBox1.Clear();
                    }
                }
            }
        }
        // Credits: https://stackoverflow.com/questions/1971008/edit-a-specific-line-of-a-text-file-in-c-sharp
        static void ChangeLine(string newText, string fileName, int lineToEdit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[lineToEdit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        public void UpdateDL_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgressLabel.Text = $"{{{e.ProgressPercentage.ToString()}%}}";
            DownloadProgress.Value = e.ProgressPercentage;

            if (DownloadProgressLabel.Text == "{100%}")
            {
                DownloadProgress.Maximum = 101;
                DownloadProgress.Value = 101;
                DownloadProgress.Maximum = 100;
            }
        }

        public void Finish()
        {
            FileNameLabel.ForeColor = Color.Green;
            FileNameLabel.Text = "Up-to-Date!";

            StartButton.Enabled = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            string GameServerIP = ServerINI.Sections[3].Keys[0].Value;
            string ServerPort = ServerINI.Sections[4].Keys[0].Value;
            string ServerSettingsMaintenanceMode = ServerINI.Sections[7].Keys[0].Value;
            string Executable = ServerINI.Sections[5].Keys[0].Value;
            
            if (ServerSettingsMaintenanceMode == "1")
            {
                MessageBox.Show("Server is currently under maintenance. Please try again later.");
            }
            else
            {
                FileNameLabel.ForeColor = Color.Black;
                FileNameLabel.Text = "Starting...";

                try
                {
                   var Game = new ProcessStartInfo
                    {
                        FileName = $"{Executable}",
                        Arguments = $"-i {GameServerIP} -p {ServerPort}",
                        UseShellExecute = false
                    };

                    Process.Start(Game);
                    Application.Exit();
                }
                catch (Exception FileEx)
                {
                    MessageBox.Show(FileEx.Message);
                    Application.Exit();
                }
            }
        }
    }
}