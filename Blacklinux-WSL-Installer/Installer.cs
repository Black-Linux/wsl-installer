using System;
using System.Diagnostics;
using System.Net;
using System.Threading;

using KeyEvents;
using Functions;

namespace blacklinux_installer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Installing Blacklinux";

            Console.WriteLine("Installing Blacklinux WSL... This can take some time..");
            System.IO.Directory.CreateDirectory(@"C:\Program Files\Blacklinux\WSL");
            Thread.Sleep(2000);


            Console.WriteLine("Downloading Rootfs... (47.8MB)");

            using (var RootfsDownload = new WebClient())
            {
                RootfsDownload.DownloadFile("http://download.blacklinux.ga/rootfs.tar", @"C:\Users\Default\rootfs.tar");
            }



            Console.WriteLine("Downloading Executeable... (344KB)");

            using (var ExeDownload = new WebClient())
            {
                ExeDownload.DownloadFile("http://download.blacklinux.ga/2021/08/03/wsl-images/blacklinux.exe" , @"C:\Program Files\Blacklinux\WSL\blacklinux.exe");
            }

            Console.WriteLine("Creating Link... ");

            using (var LinkDownload = new WebClient())
            {
                LinkDownload.DownloadFile("http://download.blacklinux.ga/2021/08/03/wsl-images/Blacklinux.lnk", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Blacklinux.lnk");
            }



            Console.WriteLine("Downloading Remove-Tool (336KB)");

            using (var RemoverDownload = new WebClient())
            {
                RemoverDownload.DownloadFile("http://download.blacklinux.ga/installer/current/wsl-exe/Blacklinux-WSL-Remover.exe", @"C:\Program Files\Blacklinux\WSL\wsl-remover.exe");
            }

            Console.WriteLine("Creating Link for Remover... ");

            using (var LinkDownload = new WebClient())
            {
                LinkDownload.DownloadFile("http://download.blacklinux.ga/2021/08/03/wsl-images/Remove%20Blacklinux.lnk", @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Remove Blacklinux.lnk");
            }



            System.IO.Directory.CreateDirectory(@"C:\Users\Default\WSL");

            string WslInstall = @"--import Blacklinux C:\Users\Default\WSL\ C:\Users\Default\rootfs.tar";
            Process.Start("wsl.exe", WslInstall);

            Console.WriteLine("Blacklinux WSL has been successfully installed. Press any key to exit");
            Events.AwaitUntilKeyPressed();
        }


    }
}
