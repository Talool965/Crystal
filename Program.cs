using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO;

namespace Crystal
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //STRINGS and modules
            string creator = "@9upq | https://github.com/talool965";
            string verison = "1.0.0";
            Modules Get = new Modules();
            Modules.ValidFile();
            string API = "https://story-of-jesus.xyz/userinfo?cookie=";
            string GetDirectory = System.IO.File.ReadAllText(@"Config\CookiesDirectory.ini");
            if (GetDirectory.Contains("DEFAULT"))
            {
                GetDirectory = "Cookies.txt";

            }

            string cookies = GetDirectory;
            //DETECT IF THE WEBSERVER IS ON?\\
            Console.Title = "CRYSTAL [●]";
            try
            {
                WebClient client = new WebClient();
                client.DownloadString(API);
            }
            catch (Exception)
            {
                Console.Title = "CRYSTAL [API-FAILURE]";
                Console.ReadKey();
            }
            //---END---\\


            try
            {
                //CountLINES
                Console.Title = "CRYSTAL [●●]";
                Modules GetMod = new Modules();
                Modules.ReadCookies();

            }
            catch (Exception)
            {
                string time = DateTime.Now.ToString("h:mm:ss tt");
                Console.Title = "CRYSTAL [ERRORDETECTED]";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{time}]");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" CRYSTAL CONSOLE: ");
                Console.ResetColor();
                Console.Write("No valid cookies file");
                Console.ResetColor();
                Console.Write(" exist would you like to ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("ROLL BACK" );
                Console.ResetColor();
                Console.Write(" to the old settings?");

               
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" Y");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("/");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("N");
                Console.WriteLine();
                Console.ResetColor();
                string YN = Console.ReadLine();

                if (YN.Equals("Y"))
                {
                    if (File.Exists("Cookies.txt"))
                    {
                        //DOnothing
                    }
                    else
                    {
                        File.Create("Cookies.txt");
                    }
                    System.IO.File.WriteAllText(@"Config\CookiesDirectory.ini", "DEFAULT");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"[{time}]");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" CRYSTAL CONSOLE: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Settings has been restored!");
                    Console.ResetColor();
                    Thread.Sleep(700);
                    Environment.Exit(1);

                }
                else if (YN.Equals("N"))
                {
                    Console.WriteLine("Exiting..");
                    Thread.Sleep(100);
                    Environment.Exit(0);

                }
                else
                {
                    Console.WriteLine("INVALID OPTION");
                    Thread.Sleep(200);
                    Environment.Exit(0);

                }

            }



            string file = new StreamReader(cookies).ReadToEnd();
            string[] lines = file.Split('\n');
            int CountCookies = lines.GetLength(0);
            Thread.Sleep(200);
            Console.Title = "CRYSTAL [●●●]";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"   ___                           _  ");
            Console.WriteLine(@"  / (_)                         | | ");
            Console.WriteLine(@" |      ,_          , _|_  __,  | | ");
            Console.WriteLine(@" |     /  |  |   | / \_|  /  |  |/  ");
            Console.WriteLine(@"  \___/   |_/ \_/|/ \/ |_/\_/|_/|__/");
            Console.WriteLine(@"                /|                  ");
            Console.WriteLine(@"                \|                ");
            Console.WriteLine();
            Console.WriteLine($"Made by {creator}");
            Console.ResetColor();
            Thread.Sleep(200);
            Console.Title = "CRYSTAL [●●●●]";

            Console.Title = $"CRYSTAL | COOKIESLOADED [{CountCookies}] | VERISON: {verison} ALPHA | [{creator}]";

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("[1] Basic cookie checker [PROXYLESS]");
            Console.WriteLine("[2] Remove Duplicates");
            Console.WriteLine("[3] ProxyChecker");
            Console.WriteLine("[4] Settings");
            Console.ResetColor();

            try
            {
                //Writing//
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\r\n>> ");
                Console.ResetColor();
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {

                    case 1:
                        Console.Clear();
                        Modules.cookiechecker();
                        break;

                    case 2:
                        Console.Clear();
                        Modules.RemoveDuplicates();
                        break;
                    case 3:
                        Console.Clear();
                        Modules.ProxyChecker();
                        break;
                    case 4:
                        Modules.settings();
                        Console.Clear();

                        break;
                    case 5:
                        Console.Clear();

                        break;

                }

            }
            catch (Exception)
            {
                string time = DateTime.Now.ToString("h:mm:ss tt");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{time}]");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" CRYSTAL CONSLOE: ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("INVALID INPUT");
                Console.ReadKey();

            }
        }
    }
}
