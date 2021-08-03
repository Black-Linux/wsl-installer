using System;
using System.Diagnostics;
using System.Net;

using KeyEvents;
using Functions;

namespace blacklinux_installer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Installing Blacklinux WSL... This can take some time..");

            using (var client = new WebClient())
            {
                client.DownloadFile("http://download.blacklinux.ga/2021/08/03/wsl-images/rootfs.tar", @"C:\Users\Default\rootfs.tar");
            }

            Console.WriteLine(@"Roofs saved at C:\Users\Default\rootfs.tar");

            System.IO.Directory.CreateDirectory(@"C:\Users\Default\WSL");




            string WslInstall = @"--import Blacklinux C:\Users\Default\WSL\ C:\Users\Default\rootfs.tar";
            Process.Start("wsl.exe", WslInstall);

            Console.WriteLine("Blacklinux WSL has been successfully installed. Press any Key to exit");
            Events.AwaitUntilKeyPressed();
        }


    }
}
