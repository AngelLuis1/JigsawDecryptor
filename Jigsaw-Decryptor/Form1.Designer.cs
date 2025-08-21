namespace Jigsaw_Decryptor
{
    partial class JigsawDecryptorForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JigsawDecryptorForm));
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.txtDecryptingFilename = new System.Windows.Forms.TextBox();
            this.lblProgresFileNumber = new System.Windows.Forms.Label();
            this.txtDecrypting = new System.Windows.Forms.TextBox();
            this.pbxJigsawDecryptor = new System.Windows.Forms.PictureBox();
            this.bwDecrypt = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pbxJigsawDecryptor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.BackColor = System.Drawing.SystemColors.Window;
            this.btnDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrypt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDecrypt.Location = new System.Drawing.Point(245, 399);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(190, 59);
            this.btnDecrypt.TabIndex = 0;
            this.btnDecrypt.Text = "Decrypt My Files!";
            this.btnDecrypt.UseVisualStyleBackColor = false;
            this.btnDecrypt.Click += new System.EventHandler(this.button1_Click);
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(68, 256);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(457, 34);
            this.pbProgress.TabIndex = 1;
            // 
            // txtDecryptingFilename
            // 
            this.txtDecryptingFilename.BackColor = System.Drawing.Color.White;
            this.txtDecryptingFilename.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDecryptingFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecryptingFilename.ForeColor = System.Drawing.SystemColors.Window;
            this.txtDecryptingFilename.Location = new System.Drawing.Point(175, 307);
            this.txtDecryptingFilename.Multiline = true;
            this.txtDecryptingFilename.Name = "txtDecryptingFilename";
            this.txtDecryptingFilename.ReadOnly = true;
            this.txtDecryptingFilename.Size = new System.Drawing.Size(350, 71);
            this.txtDecryptingFilename.TabIndex = 2;
            // 
            // lblProgresFileNumber
            // 
            this.lblProgresFileNumber.AutoSize = true;
            this.lblProgresFileNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgresFileNumber.ForeColor = System.Drawing.SystemColors.Window;
            this.lblProgresFileNumber.Location = new System.Drawing.Point(531, 262);
            this.lblProgresFileNumber.Name = "lblProgresFileNumber";
            this.lblProgresFileNumber.Size = new System.Drawing.Size(141, 20);
            this.lblProgresFileNumber.TabIndex = 5;
            this.lblProgresFileNumber.Text = "100000 / 1000000";
            // 
            // txtDecrypting
            // 
            this.txtDecrypting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDecrypting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDecrypting.ForeColor = System.Drawing.SystemColors.Window;
            this.txtDecrypting.Location = new System.Drawing.Point(70, 307);
            this.txtDecrypting.Multiline = true;
            this.txtDecrypting.Name = "txtDecrypting";
            this.txtDecrypting.ReadOnly = true;
            this.txtDecrypting.Size = new System.Drawing.Size(98, 25);
            this.txtDecrypting.TabIndex = 6;
            this.txtDecrypting.Text = "Decrypting:";
            // 
            // pbxJigsawDecryptor
            // 
            this.pbxJigsawDecryptor.Image = global::Jigsaw_Decryptor.Properties.Resources.jigsaw_decryptor_transparent;
            this.pbxJigsawDecryptor.Location = new System.Drawing.Point(205, 30);
            this.pbxJigsawDecryptor.Name = "pbxJigsawDecryptor";
            this.pbxJigsawDecryptor.Size = new System.Drawing.Size(242, 204);
            this.pbxJigsawDecryptor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxJigsawDecryptor.TabIndex = 7;
            this.pbxJigsawDecryptor.TabStop = false;
            this.pbxJigsawDecryptor.Visible = false;
            // 
            // bwDecrypt
            // 
            this.bwDecrypt.WorkerReportsProgress = true;
            this.bwDecrypt.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDecrypt_DoWork);
            this.bwDecrypt.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwDecrypt_ProgressChanged);
            this.bwDecrypt.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDecrypt_RunWorkerCompleted);
            // 
            // JigsawDecryptorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(679, 515);
            this.Controls.Add(this.pbxJigsawDecryptor);
            this.Controls.Add(this.txtDecrypting);
            this.Controls.Add(this.lblProgresFileNumber);
            this.Controls.Add(this.txtDecryptingFilename);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.btnDecrypt);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JigsawDecryptorForm";
            this.Text = "JigsawDecryptor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxJigsawDecryptor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.TextBox txtDecryptingFilename;
        private System.Windows.Forms.Label lblProgresFileNumber;
        private System.Windows.Forms.TextBox txtDecrypting;
        private System.Windows.Forms.PictureBox pbxJigsawDecryptor;
        private System.ComponentModel.BackgroundWorker bwDecrypt;
    }
}

