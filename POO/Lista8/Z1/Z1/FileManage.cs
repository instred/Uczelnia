using System;

namespace z1
{
    public class FileManage
    {
        public static void CopyFileCommand(string from, string to)
        {
            Console.WriteLine("Kopiuje plik z " + from + "do" + to);
        }

        public static void CreateFileCommand(string path)
        {
            Console.WriteLine("Tworzenie pliku " + path);
        }

        public static void DownloadFtpCommand(string address)
        {
            Console.WriteLine("Pobieranie FTP: " + address);
        }

        public static void DownloadHttpCommand(string address)
        {
            Console.WriteLine("Pobieranie HTTP: " + address);
        }
    }
}