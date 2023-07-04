using System;
using System.Windows.Forms;
using MadMilkman.Ini;
using System.IO;
using System.Net;

namespace FiestaHeroes_UL
{
    public partial class OptionsWindow : Form
    {
        public OptionsWindow()
        {
            InitializeComponent();
        }

        WebClient WC = new WebClient();
        IniFile ServerINI = new IniFile();
        IniFile LauncherINI = new IniFile();
        IniFile OptimizeINI = new IniFile();

        // Check for required files. Decided to use an array since the list was getting bigger, and it looked bulky having so many individual checks. Also, using this for the strings as well.
        string[] RequiredFiles =
        {
            "./reslauncher/launcher.ini", "./reslauncher/optimize.ini"
        };

        private void OptionsWindow_Load(object sender, EventArgs e)
        {
            {
                // Local configuration file.
                LauncherINI.Load(RequiredFiles[0]);
                string ServerIP = LauncherINI.Sections[0].Keys[0].Value;

                // Server configuration file.
                ServerINI.Load(WC.OpenRead(($"{ServerIP}Config.ini")));

                // Integrity Check.
                string IntegrityCheck = ServerINI.Sections[7].Keys[1].Value;

                if (IntegrityCheck == "1")
                {
                    IntegrityCheckButton.Enabled = true;
                }

                // Optimize Client.
                OptimizeINI.Load(RequiredFiles[1]);
                string Applied = OptimizeINI.Sections[0].Keys[0].Value;

                if (Applied == "0")
                {
                    ApplyButton.Enabled = true;
                }
                else
                {
                    RestoreButton.Enabled = true;
                }
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            OptimizeINI.Load(RequiredFiles[1]);

            for (int DefaultKey = 0; DefaultKey < OptimizeINI.Sections[1].Keys.Count; DefaultKey++)
            {
                try
                {
                    string Files = OptimizeINI.Sections[1].Keys[DefaultKey].Value;

                    File.Move(Files, $"{Files}.xkl");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            ChangeLine("Applied=1", RequiredFiles[1], 2);

            MessageBox.Show("Optimization has been applied.");
            this.Close();
        }

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            OptimizeINI.Load(RequiredFiles[1]);

            for (int DefaultKey = 0; DefaultKey < OptimizeINI.Sections[1].Keys.Count; DefaultKey++)
            {
                try
                {
                    string Files = OptimizeINI.Sections[1].Keys[DefaultKey].Value;

                    File.Move($"{Files}.xkl", Files);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            ChangeLine("Applied=0", RequiredFiles[1], 2);

            MessageBox.Show("Optimization has been removed.");
            this.Close();
        }

        private void PatchVersionResetButton_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeLine($"PatchVersion=0", RequiredFiles[0], 5);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            MessageBox.Show("Patch version has now been successfully reset. Application will now restart.");
            Application.Restart();
        }

        private void IntegrityCheckButton_Click(object sender, EventArgs e)
        {
            IntegrityCheck ShowIntegrityCheckWindow = new IntegrityCheck();
            ShowIntegrityCheckWindow.ShowDialog();
        }

        // Credits: https://stackoverflow.com/questions/1971008/edit-a-specific-line-of-a-text-file-in-c-sharp
        static void ChangeLine(string newText, string fileName, int lineToEdit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[lineToEdit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }
    }
}
