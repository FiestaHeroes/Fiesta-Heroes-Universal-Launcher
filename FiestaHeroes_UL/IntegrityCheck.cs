using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using MadMilkman.Ini;

namespace FiestaHeroes_UL
{
    public partial class IntegrityCheck : Form
    {
        public IntegrityCheck()
        {
            InitializeComponent();
        }

        private async void IntegrityCheck_LoadAsync(object sender, EventArgs e)
        {
            PositionWindowBottomRight();
            await Start();
        }

        // Ensure that the integrity check window is always positioned at the bottom-right corner of the screen.
        private void PositionWindowBottomRight()
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width - Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height - Height;
            Location = new Point(x, y);
        }

        // Begin the check.
        private async Task Start()
        {
            try
            {
                IniFile LocalINI = new IniFile();
                IniFile ServerINI = new IniFile();
                WebClient WC = new WebClient();
                MD5 MD5 = new MD5CryptoServiceProvider();

                // Local configuration file.
                LocalINI.Load("./reslauncher/launcher.ini");

                // Server configuration file.
                string serverIP = LocalINI.Sections[0].Keys[0].Value;
                ServerINI.Load(WC.OpenRead($"{serverIP}Config.ini"));

                for (int i = 0; i < ServerINI.Sections[8].Keys.Count; i++)
                {
                    string fileName = ServerINI.Sections[8].Keys[i].Value;
                    string serverHash = ServerINI.Sections[9].Keys[i].Value;

                    // Use the current file name string for the text on the group box.
                    FileName.Text = fileName;

                    // Get the local MD5 file hash and compare
                    using (FileStream stream = File.OpenRead(fileName))
                    {
                        byte[] md5FileHash = MD5.ComputeHash(stream);
                        string md5Trim = BitConverter.ToString(md5FileHash).Replace("-", string.Empty);
                        stream.Close();

                        LocalTextbox.Text = md5Trim;
                        ServerTextbox.Text = serverHash;

                        await Task.Delay(10);

                        // Local and server hash doesn't match. So, this is most likely one of reasons they get the "Client Manipulation" error.
                        if (LocalTextbox.Text != ServerTextbox.Text)
                        {
                            DisplayMessageBox($"{fileName} doesn't match the server's. Please contact your Administrator.");
                            return;
                        }
                    }

                    LocalTextbox.Clear();
                    ServerTextbox.Clear();
                }

                // Successfully finished.
                Hide();
                DisplayMessageBox("The integrity check was successfully completed, and no problems were detected while comparing the specified files with our server's list.");
            }
            catch (Exception ex)
            {
                DisplayMessageBox($"{ex.Message}. Please contact your Administrator.");
                return;
            }
        }

        // Ensures the form closes after displaying a message. I didn't want to bother with adding Close(); after every MessageBox.Show() statement.
        private void DisplayMessageBox(string message)
        {
            MessageBox.Show(message);
            Close();
        }
    }
}
