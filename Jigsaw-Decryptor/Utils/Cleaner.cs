using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Jigsaw_Decryptor.Utils
{
    internal class Cleaner
    {
        internal static bool DeleteDroppedFiles()
        {
            bool success = true;
            try
            {
                Directory.Delete(Config.WORK_PATH, recursive: true);
                Logger.Log($"Directory '{Config.WORK_PATH}' deleted");

                File.Delete(Config.TEMP_EXE_PATH);
                Logger.Log($"File '{Config.TEMP_EXE_PATH}' deleted");

                File.Delete(Config.FINAL_EXE_PATH);
                Logger.Log($"File '{Config.FINAL_EXE_PATH}' deleted");

                Directory.Delete(Path.GetDirectoryName(Config.TEMP_EXE_PATH));
                Logger.Log($"Directory '{Path.GetDirectoryName(Config.TEMP_EXE_PATH)}' deleted");

                Directory.Delete(Path.GetDirectoryName(Config.FINAL_EXE_PATH));
                Logger.Log($"Directory '{Path.GetDirectoryName(Config.FINAL_EXE_PATH)}' deleted");
            } catch (DirectoryNotFoundException dnf)
            {
                Logger.Log(dnf.Message);
                success = false;
            } catch (FileNotFoundException fnf)
            {
                Logger.Log(fnf.Message);
                success = false;
            } catch (UnauthorizedAccessException uae)
            {
                Logger.Log(uae.Message);
                success = false;
            }
            return success;
        }

        internal static bool RemovePersistance()
        {
            bool success = true;
            string keyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyPath, writable: true))
            {
                if (key != null)
                {
                    if (key.GetValue(Config.FRFX_EXE) != null)
                    {
                        key.DeleteValue(Config.FRFX_EXE);
                        Logger.Log($"Registry value '{Config.FRFX_EXE}' deleted");
                    }
                    else
                    {
                        Logger.Log($"Registry value '{Config.FRFX_EXE}' does not exist.");
                        success = false;
                    }
                }
                else
                {
                    Logger.Log($"Registry key '{keyPath}' not found.");
                    success = false;
                }
            }

            return success;
        }

        internal static void KillJigsawProcesses()
        {
            // Kill drpbx.exe process if present
            KillProcessByNameAndPath(Path.GetFileNameWithoutExtension(Config.DRPBX_EXE), Config.TEMP_EXE_PATH);

            // Kill firefox.exe process if present (only jigsaw firefox.exe)
            KillProcessByNameAndPath(Path.GetFileNameWithoutExtension(Config.FRFX_EXE), Config.FINAL_EXE_PATH);
        }

        private static void KillProcessByNameAndPath(string name, string full_path)
        {
            foreach (var process in Process.GetProcessesByName(name))
            {
                try
                {
                    if (process.MainModule.FileName.Equals(full_path, StringComparison.OrdinalIgnoreCase))
                    {
                        process.Kill();
                        process.WaitForExit();
                        Logger.Log($"Process {process.Id}:{process.ProcessName} killed");
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log($"Could not kill {process.Id}:{process.ProcessName}");
                    Logger.Log(ex.Message);
                    MessageBox.Show($"Could not kill {process.Id}:{process.ProcessName}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
