using Jigsaw_Decryptor.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Jigsaw_Decryptor
{
    public partial class JigsawDecryptorForm : Form
    {
        public JigsawDecryptorForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle; // prevents resize handles
            MaximizeBox = false;

            this.BackColor = Color.FromArgb(30, 30, 30);
            this.txtDecrypting.BackColor = Color.FromArgb(30, 30, 30);
            this.txtDecryptingFilename.BackColor = Color.FromArgb(30, 30, 30);
            this.btnDecrypt.BackColor = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.pbxJigsawDecryptor.Visible = true;
            this.pbProgress.Visible = false;
            this.pbProgress.Enabled = false;
            this.txtDecrypting.Visible = false;
            this.txtDecryptingFilename.Visible = false;
            this.lblProgresFileNumber.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to recover your files now?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                StartFSDecryption();
            }
        }

        private void StartFSDecryption()
        {
            toggleUIVisibility();

            int totalFilesEncrypted = Decryptor.encryptedFileList.Count;
            this.pbProgress.Minimum = 0;
            this.pbProgress.Maximum = totalFilesEncrypted;
            this.lblProgresFileNumber.Text = $"0/{totalFilesEncrypted}";

            this.bwDecrypt.RunWorkerAsync();
        }

        private void toggleUIVisibility()
        {
            this.pbProgress.Enabled = !this.pbProgress.Enabled;
            this.pbProgress.Visible = !this.pbProgress.Visible;
            this.txtDecrypting.Visible = !this.txtDecrypting.Visible ;
            this.txtDecryptingFilename.Visible = !this.txtDecryptingFilename.Visible;
            this.lblProgresFileNumber.Visible = !this.lblProgresFileNumber.Visible;
        }

        private void bwDecrypt_DoWork(object sender, DoWorkEventArgs e)
        {
            Decryptor.DecryptFileSystem((BackgroundWorker) sender);
        }

        private void bwDecrypt_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.pbProgress.Value = e.ProgressPercentage;
            this.lblProgresFileNumber.Text = $"{e.ProgressPercentage}/{this.pbProgress.Maximum}";
            this.txtDecryptingFilename.Text = Decryptor.currentFilename;
        }

        private void bwDecrypt_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool success;

            if (e.Error != null)
            {
                Logger.Log("Background Worker error: " + e.Error.Message);
                MessageBox.Show("Unexpected error occurred while decrypting file system", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            } else
            {
                Cleaner.KillJigsawProcesses();
                success = Cleaner.DeleteDroppedFiles();
                success = Cleaner.RemovePersistance() && success;

                if (success) {
                   MessageBox.Show("Jigsaw was totally removed from your system!!\nIt is recommended to reboot your system for potential leftovers.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                } else {
                   MessageBox.Show("Jigsaw partially removed from your system.\nCheck generated logs to identify potential leftovers.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Application.Exit();
            }
        }
    }
}
