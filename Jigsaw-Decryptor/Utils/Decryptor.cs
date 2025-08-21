using Jigsaw_Decryptor.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Jigsaw_Decryptor
{
    internal class Decryptor
    {
        private static readonly string EncryptedFileListPath = Path.Combine(Config.WORK_PATH, Config.ENCRYPTED_FILE_LIST);
        private static readonly string EncryptionPassword = "OoIsAwwF23cICQoLDA0ODe==";
        private static readonly byte[] IV = new byte[] { 0, 1, 0, 3, 5, 3, 0, 1, 0, 0, 2, 0, 6, 7, 6, 0 };
        internal static string currentFilename = "";
        internal static readonly List<string> encryptedFileList = Decryptor.GetEncryptedFilseList();

        internal static List<String> GetEncryptedFilseList()
        {
            List<string> files = null;

            if (File.Exists(EncryptedFileListPath))
            {
                files = new List<string>(File.ReadAllLines(EncryptedFileListPath));
            }
            else
            {
                MessageBox.Show($"The file {EncryptedFileListPath} is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            return files;
        }

        internal static void DecryptFileSystem(BackgroundWorker worker)
        {
            int fileCounter = 0;
            Stopwatch stopwatch = new Stopwatch();

            Logger.Log("Decrypting file system...");
            stopwatch.Start();
            foreach (string file in Decryptor.encryptedFileList)
            {
                try
                {
                    currentFilename = file + Config.FILE_EXTENSION;
                    if (File.Exists(currentFilename))
                    {
                        DecryptFile(currentFilename);
                        File.Delete(currentFilename);
                        worker.ReportProgress(++fileCounter);
                    }
                } catch (UnauthorizedAccessException ex)
                {
                    Logger.Log($"Unable to decrypt '{currentFilename}' due to '{ex.Message}'");
                } catch (IOException ex)
                {
                    Logger.Log($"Unexpected IOException due to '{ex.Message}'");
                }
            }
            stopwatch.Stop();

            Logger.Log($"File system decrypted in {getElapsedTime(stopwatch)}");
            File.Delete(Decryptor.EncryptedFileListPath);
            Logger.Log($"Deleted '{Decryptor.EncryptedFileListPath}' successfully.");
        }

        private static string getElapsedTime(Stopwatch stopwatch)
        {
            string elapsedTime = "";
            if (stopwatch.Elapsed.TotalSeconds < 60)
            {
                elapsedTime = $"{stopwatch.Elapsed.Seconds} seconds";
            }
            else
            {
                double minutes = stopwatch.Elapsed.TotalMinutes;
                elapsedTime = $"{minutes:F2} minutes";
            }

            return elapsedTime;
        }

        private static void DecryptFile(string filename)
        {
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.Key = Convert.FromBase64String(Decryptor.EncryptionPassword);
                aes.IV = Decryptor.IV;
                DecryptFile(filename, aes);
            }
        }

        private static void DecryptFile(string filename, SymmetricAlgorithm alg)
        {
            byte[] buffer = new byte[65536];

            using (FileStream fread = new FileStream(filename, FileMode.Open))
            using (FileStream fwrite = new FileStream(filename.Substring(0, filename.Length - Config.FILE_EXTENSION.Length), FileMode.Create))
            using (CryptoStream crypt = new CryptoStream(fwrite, alg.CreateDecryptor(), CryptoStreamMode.Write))
            {
                int readBytes;
                do
                {
                    readBytes = fread.Read(buffer, 0, buffer.Length);
                    if (readBytes != 0)
                        crypt.Write(buffer, 0, readBytes);
                } while (readBytes > 0);
            }
        }
    }
}
