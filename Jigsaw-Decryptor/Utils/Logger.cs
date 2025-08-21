using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jigsaw_Decryptor.Utils
{
    internal class Logger
    {
        private static readonly string logFilePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            $"log_{DateTime.Now:dd-MM-yyyy_HH-mm-ss}.txt");

        public static void Log(string message)
        {
            string logEntry = $"{DateTime.Now:dd-MM-yyyy HH:mm:ss} - {message}";
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
    }
}
