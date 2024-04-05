using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FiestaHeroes_UL;
using MadMilkman.Ini;

namespace FiestaLauncher
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            InitializeComponent();
        }

        WebClient WC = new WebClient();
        IniFile LocalINI = new IniFile();
        IniFile ServerINI = new IniFile();

        // Check for required files. Decided to use an array since the list was getting bigger, and it looked bulky having so many individual checks. Also, using this for the strings as well.
        string[] RequiredFiles =
        {
            "MadMilkman.Ini.dll", "UnRAR.dll", "./reslauncher/launcher.ini", "./reslauncher/optimize.ini"
        };

        private async void MainWindow_LoadAsync(object sender, EventArgs e)
        {
            foreach (string file in RequiredFiles)
            {
                if (!File.Exists(file))
                {
                    MessageBox.Show($"Oops, {file} is missing. Please contact your Administrator.");
                    Application.Exit();
                }
            }

            // Local configuration file.
            LocalINI.Load(RequiredFiles[2]);
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
            try
            {
                BannerImage.Image = new Bitmap(new MemoryStream(WC.DownloadData(ServerSettingsBanner)));
            }
            catch
            {
                MessageBox.Show($"Oops, having trouble loading your banner image from {ServerSettingsBanner}.");
                BannerImage.Image = null;
            }

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

                    ChangeLine($"PatchVersion={Client}", RequiredFiles[2], 5);

                    var unrar = new Unrar();
                    unrar.ExtractionProgress += (s, e) =>
                    {
                        FileNameLabel.Text = $" Extracting {ServerFileName}{Client}{ServerExtension}...";
                        textBox1.Text = e.FileName.ToString();
                    };

                    unrar.Open($"{ServerFileName}{Client}{ServerExtension}", Unrar.OpenMode.Extract);
                    while (unrar.ReadHeader())
                    {
                        unrar.ExtractToDirectory("./");
                    }

                    unrar.Close();
                    unrar.Dispose();

                    File.Delete($"{ServerFileName}{Client}{ServerExtension}");
                    DownloadProgressLabel.ResetText();
                    textBox1.Clear();
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

            string DeleteFilesCheck = ServerINI.Sections[7].Keys[2].Value;

            if (DeleteFilesCheck == "1")
            {
                for (int DefaultKey = 0; DefaultKey < ServerINI.Sections[10].Keys.Count; DefaultKey++)
                {
                    string FileToDelete = ServerINI.Sections[10].Keys[DefaultKey].Value;
                    File.Delete(FileToDelete);
                }

                StartButton.Enabled = true;
                OptionsButton.Enabled = true;
            }
            else
            {
                StartButton.Enabled = true;
                OptionsButton.Enabled = true;
            }
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

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            var Options = new OptionsWindow();
            Options.Show();
        }
    }
}
