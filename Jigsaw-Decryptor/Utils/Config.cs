using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jigsaw_Decryptor
{
    internal static class Config
    {
        internal static readonly string WORK_PATH;
        internal static readonly string TEMP_EXE_PATH;
        internal static readonly string FINAL_EXE_PATH;
        internal const string ENCRYPTED_FILE_LIST = @"EncryptedFileList.txt";
        internal const string FILE_EXTENSION = ".fun";
        internal const string DRPBX_EXE = "drpbx.exe";
        internal const string FRFX_EXE = "firefox.exe";

        static Config()
        {
            var ROAMING_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var LOCAL_PATH = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            WORK_PATH = Path.Combine(ROAMING_PATH, "System32Work");
            TEMP_EXE_PATH = Path.Combine(LOCAL_PATH, "Drpbx", DRPBX_EXE);
            FINAL_EXE_PATH = Path.Combine(ROAMING_PATH, "Frfx", FRFX_EXE);
        }
    }
}
