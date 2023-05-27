using System;
using System.Net;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace TnusersMultiTool
{
    public class TnusersMultiTool 
    { 
        public static void Logo()
        {
            string shit = "\r\n░██████╗██╗░░██╗██╗████████╗\r\n██╔════╝██║░░██║██║╚══██╔══╝\r\n╚█████╗░███████║██║░░░██║░░░\r\n░╚═══██╗██╔══██║██║░░░██║░░░\r\n██████╔╝██║░░██║██║░░░██║░░░\r\n╚═════╝░╚═╝░░╚═╝╚═╝░░░╚═╝░░░";
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("██╗░░██╗███╗░░░███╗░█████╗░███╗░░██╗░██████╗  ██████╗░██╗░░██╗░█████╗░████████╗░█████╗░███╗░░██╗");
            Console.WriteLine("██║░██╔╝████╗░████║██╔══██╗████╗░██║██╔════╝  ██╔══██╗██║░░██║██╔══██╗╚══██╔══╝██╔══██╗████╗░██║");
            Console.WriteLine("█████═╝░██╔████╔██║███████║██╔██╗██║╚█████╗░  ██████╔╝███████║██║░░██║░░░██║░░░██║░░██║██╔██╗██║");
            Console.WriteLine("██╔═██╗░██║╚██╔╝██║██╔══██║██║╚████║░╚═══██╗  ██╔═══╝░██╔══██║██║░░██║░░░██║░░░██║░░██║██║╚████║");
            Console.WriteLine("██║░╚██╗██║░╚═╝░██║██║░░██║██║░╚███║██████╔╝  ██║░░░░░██║░░██║╚█████╔╝░░░██║░░░╚█████╔╝██║░╚███║");
            Console.WriteLine("╚═╝░░╚═╝╚═╝░░░░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═════╝░  ╚═╝░░░░░╚═╝░░╚═╝░╚════╝░░░░╚═╝░░░░╚════╝░╚═╝░░╚══╝");
            Console.WriteLine(shit);
            /*Console.WriteLine("██████╗░███████╗░██████╗████████╗██████╗░░█████╗░██╗░░░██╗███████╗██████╗░");
            Console.WriteLine("██╔══██╗██╔════╝██╔════╝╚══██╔══╝██╔══██╗██╔══██╗╚██╗░██╔╝██╔════╝██╔══██╗");
            Console.WriteLine("██║░░██║█████╗░░╚█████╗░░░░██║░░░██████╔╝██║░░██║░╚████╔╝░█████╗░░██████╔╝");
            Console.WriteLine("██║░░██║██╔══╝░░░╚═══██╗░░░██║░░░██╔══██╗██║░░██║░░╚██╔╝░░██╔══╝░░██╔══██╗");
            Console.WriteLine("██████╔╝███████╗██████╔╝░░░██║░░░██║░░██║╚█████╔╝░░░██║░░░███████╗██║░░██║");
            Console.WriteLine("╚═════╝░╚══════╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚════╝░░░░╚═╝░░░╚══════╝╚═╝░░╚═╝ ");*/
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            try
            {
                if (!File.Exists("PhotonDestryerManager.dll"))
                {
                    Console.WriteLine("Loading...");
                    WebClient web = new WebClient();
                    web.DownloadFile("https://tnuser.com/PhotonDestroyer/PhotonDestryerManager.dll", "PhotonDestryerManager.dll");
                }

                if (File.Exists("JoinMaster.txt"))
                {
                    File.Delete("JoinMaster.txt");
                }
                if (File.Exists("CloseConnection.txt"))
                {
                    File.Delete("CloseConnection.txt");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor= ConsoleColor.DarkRed;
                Console.WriteLine($"ERROR: \n {ex.ToString()}");
                Console.ReadLine();
                Environment.Exit(99999);
            }
            Logo();
            Console.WriteLine("Welcome, Photon Destroyer options are below");
            string[] options =
            {
                "[1] Join Master Server",
                "[2] Close Connecton All",
                "[3] Set Master",
                "[4] Disconnect from Photon",
                "[5] Check for photon event codes",
                "[6] Join Lobby"
            };
            foreach (string i in options)
            {
                Console.WriteLine($"{i}");
            }
            Console.WriteLine("");
            Console.WriteLine("Type Option Below");
            Console.WriteLine("");
            var x = Console.ReadLine();
            if (x == "1")
            {
                Console.WriteLine($"Your option: {x}");
                Console.WriteLine("Connecting");

                if (File.Exists("JoinMaster.txt"))
                {
                    File.Delete("JoinMaster.txt");
                    File.WriteAllText("JoinMaster.txt", "Y");
                }
                else
                {
                    File.WriteAllText("JoinMaster.txt", "Y");
                }

                Console.WriteLine("Connected");
                Console.WriteLine("Press Enter To Restart");
                Console.ReadLine();
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
            }
            else if (x == "2")
            {
                Console.WriteLine($"Your option: {x}");
                Console.WriteLine("Closing");

                if (File.Exists("CloseConnection.txt"))
                {
                    File.Delete("CloseConnection.txt");
                    File.WriteAllText("CloseConnection.txt", "Y");
                }
                else
                {
                    File.WriteAllText("CloseConnection.txt", "Y");
                }

                Console.WriteLine("Press Enter To Restart");
                Console.ReadLine();
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
            }
            else if (x == "3")
            {
                Console.WriteLine($"Your option: {x}");

                if (File.Exists("SetMaster.txt"))
                {
                    File.Delete("SetMaster.txt");
                    File.WriteAllText("SetMaster.txt", "Y");
                }
                else
                {
                    File.WriteAllText("SetMaster.txt", "Y");
                }

                Console.WriteLine("Press Enter To Restart");
                Console.ReadLine();
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
            }
            else if (x == "4")
            {
                Console.WriteLine($"Your option: {x}");

                if (File.Exists("Disconnect.txt"))
                {
                    File.Delete("Disconnect.txt");
                    File.WriteAllText("Disconnect.txt", "Y");
                }
                else
                {
                    File.WriteAllText("Disconnect.txt", "Y");
                }

                Console.WriteLine("Press Enter To Restart");
                Console.ReadLine();
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
            }
            else if (x == "5")
            {
                Console.WriteLine($"Your option: {x}");

                if (File.Exists("event.txt"))
                {
                    File.Delete("event.txt");
                    File.WriteAllText("event.txt", "Y");
                }
                else
                {
                    File.WriteAllText("event.txt", "Y");
                }
                Console.WriteLine("press enter to stop");
                Thread.Sleep(1000);

                var xyz = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\eventcodes.txt");
                Console.WriteLine($"{xyz}");

                
                Console.ReadLine();
                File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\event.txt");
                File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\eventcodes.txt");
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
                Environment.Exit(0);
            }
            else if (x == "6")
            {

            }
        }
    }

}