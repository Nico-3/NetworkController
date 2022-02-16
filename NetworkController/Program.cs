using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using Microsoft.VisualBasic.FileIO;

namespace PingProgram
{
    public class Program
    {

        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.White;

            Install();

            static void Install()
            {
                string installfile = @"C:\netprogram\install\install.txt";
                string ipfile = @"C:\netprogram\install\ipfile.txt";
                string path2 = @"C:\netprogram\install";
                string path = @"C:\netprogram\netlog";

                try
                {

                    //Check ob Programm schon installiert wurde

                    if (File.Exists(installfile) && File.Exists(ipfile) && Directory.Exists(path) && Directory.Exists(path2))     //falls schon diese Daten existieren
                    {
                        readip();     //rufe diese Funktion auf
                    }
                    else
                    {

                        #region INSTALL FOLDER CREATE

                        try
                        {
                            if (Directory.Exists(path2))
                            {

                            }
                            else
                            {
                                DirectoryInfo di = Directory.CreateDirectory(path2);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ORDNER KONNTEN NICHT ERSTELLT WERDEN!\n \nDer Fehler wurde im Fehlerlog gespeichert!\n\n Genauer Pfad:\n\nC:/netprogram/netlog/errorlog.txt");
                            Fehlercode(e);
                        }

                        #endregion



                        #region NETLOG FOLDER CREATE

                        try
                        {
                            if (Directory.Exists(path))
                            {

                            }
                            else
                            {
                                DirectoryInfo di = Directory.CreateDirectory(path);
                            }


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ORDNER KONNTEN NICHT ERSTELLT WERDEN!\n \nDer Fehler wurde im Fehlerlog gespeichert!\n\n Genauer Pfad:\n\nC:/netprogram/netlog/errorlog.txt");
                            Fehlercode(e);
                        }

                        #endregion

                        System.Threading.Thread.Sleep(3000);
                        try
                        {
                            var crinstall = File.Create(installfile);
                            crinstall.Close();
                            var crip = File.Create(ipfile);
                            crip.Close();
                        }
                        catch (Exception e)
                        {
                            Fehlercode(e);
                        }

                        readip();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("ORDNER KONNTEN NICHT ERSTELLT WERDEN!\n \nDer Fehler wurde im Fehlerlog gespeichert!\n\n Genauer Pfad:\n\nC:/netprogram/netlog/errorlog.txt");
                    Fehlercode(e);
                }

            }

            static void readip()
            {

                //String line;
                try
                {
                    string ipfile = @"C:/netprogram/install/ipfile.txt";
                    string ip = null;
                    int counter = 0;

                    // Read the file and display it line by line.  
                    foreach (string line in System.IO.File.ReadLines(ipfile))
                    {
                        ip = line;
                        counter++;
                    }



                    saveip(ip);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: Ich bin hier" + e.Message);
                }
            }

            static void saveip(string ip)
            {

                string ipfile = @"C:\netprogram\install\ipfile.txt";
                String line = null;
                string newip = null;

                if (ip != null)
                {
                    Console.Clear();
                    Console.Write("\nIst diese Adresse ( " + ip +
                                  " ) Ihre gewünschte Zieladresse?\n \n Dann geben sie bitte");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(" JA ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("oder");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" NEIN ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("ein!\n \n");
                    line = Console.ReadLine();

                    if (line == "JA")
                    {
                        ping(ip);

                    }
                    else if (line == "NEIN")
                    {


                        Console.Clear();
                        Console.WriteLine(
                            "\nBitte geben sie Ihre gewünschte Web Adresse oder Ihre IP Adresse an!\n \nEingabe:  \n");
                        newip = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine(
                            "\nMöchten sie diese IP speichern?\n\n Dann geben sie bitte");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(" JA ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("oder");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write(" NEIN ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("ein!\n \n");
                        line = Console.ReadLine();

                        if (line == "JA")
                        {
                            Console.WriteLine("DEV" + newip + ip);
                            FileStream ipdatei = new FileStream(@ipfile, FileMode.Open);
                            StreamWriter ipschreiber = new StreamWriter(ipdatei);
                            ipschreiber.WriteLine(newip);
                            ipschreiber.Close();
                            ping(ip);
                        }
                        else if (line == "NEIN")
                        {
                            newip = ip;
                            ping(ip);
                        }
                    }
                }
                else if (ip == null)
                {
                    Console.Clear();
                    Console.WriteLine("\nEs ist standartmäßig keine IP Adresse vergeben! Diese wird gespeichert!\n\nBitte geben sie jetzt eine IP oder Webadresse an!\n\n");
                    line = Console.ReadLine();
                    newip = line;
                    ip = newip;
                    FileStream ipdatei = new FileStream(@ipfile, FileMode.Open);
                    StreamWriter ipschreiber = new StreamWriter(ipdatei);
                    ipschreiber.WriteLine(newip);
                    ipschreiber.Close();
                    ping(ip);
                }
                else
                {
                    Console.WriteLine("Da hat etwas nicht geklappt!");
                }

            }


            static void ping(string ip)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nDas Programm wird nun mit dieser Adresse (" + ip + ") gestartet!\n" +
                    "\nSollten sie diese Adresse ändern wollen sollten sie das Programm neu starten!" +
                    "\nEs gibt keine Möglichkeit den durchgehenden Ping zu unterbrechen!\n" +
                    "Falls sie dies wünschen müssen sie ebenfalls das Programm neustarten!");

                System.Threading.Thread.Sleep(5000);
                Console.Clear();


                string x = "x";

                while (x == "x")
                {
                    try
                    {
                        System.Threading.Thread.Sleep(1000);
                        DateTime localDate = DateTime.Now;
                        FileStream logdatei = new FileStream(@"C:/netprogram/netlog/pinglog.txt", FileMode.Append);
                        StreamWriter schreiber = new StreamWriter(logdatei);
                        Ping myPing = new Ping();
                        PingReply reply = myPing.Send(ip, 5000);

                        if (reply != null)
                        {
                            string createText = "\nStatus:  " + reply.Status + " \nTime: " +
                                                reply.RoundtripTime.ToString() +
                                                " ms" + "\nZeitstempel: " + localDate.ToString("g");
                            schreiber.WriteLine(createText);
                            schreiber.Close();
                            logdatei.Close();

                            if (reply.RoundtripTime == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Status:  " + reply.Status + " \nTime: " +
                                                  reply.RoundtripTime.ToString() +
                                                  " ms \nAddress: " + reply.Address + "\n \nNicht erreichbar! \n");
                            }
                            else if (reply.RoundtripTime < 100)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Status:  " + reply.Status + " \nVerzögerung: " +
                                                  reply.RoundtripTime.ToString() + " ms \nServer Adresse: " +
                                                  reply.Address +
                                                  "\nZeitstempel: " + localDate.ToString("g") +
                                                  ("\n \nGuter Ping! \n"));
                            }
                            else if (reply.RoundtripTime < 500)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Status:  " + reply.Status + " \nTime: " +
                                                  reply.RoundtripTime.ToString() +
                                                  " ms \nAddress: " + reply.Address + "\n \nMittlerer Ping! \n");
                            }
                            else if (reply.RoundtripTime > 500)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Status:  " + reply.Status + " \nTime: " +
                                                  reply.RoundtripTime.ToString() +
                                                  " ms \nAddress: " + reply.Address + "\n \nHoher Ping! \n");
                            }
                            else if (reply.RoundtripTime > 1000)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Status:  " + reply.Status + " \nTime: " +
                                                  reply.RoundtripTime.ToString() +
                                                  " ms \nAddress: " + reply.Address + "\n \nKritischer Ping! \n");
                            }
                            else
                            {
                                Console.WriteLine("FATAL ERROR");
                            }
                        }
                        else
                        {
                            Console.WriteLine("FATAL ERROR");
                        }
                    }
                    catch (Exception e)
                    {
                        Fehlercode(e);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Ungültige IP! Abfrage wird erneut gestartet!\n\nDer Fehler wurde im Fehlerlog gespeichert!\n\n Genauer Pfad:\n\nC:/netprogram/netlog/errorlog.txt");
                        System.Threading.Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    }
                }
            }
        }



        static void Exit()
        {
            Console.WriteLine("Programm wird beendet!");
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        }

        static void Fehlercode(Exception e)
        {
            string errpath = "C:/netprogram/netlog/errorlog.txt";
            DateTime localDate = DateTime.Now;
            FileStream errlogdatei = new FileStream(@errpath, FileMode.Append);
            StreamWriter errschreiber = new StreamWriter(errlogdatei);

            Console.WriteLine("DIE FEHLERDATEI FINDEN SIE UNTER " + errpath);
            errschreiber.WriteLine("---------------");
            errschreiber.WriteLine("FEHLER GENERIERT AM: " + localDate);
            errschreiber.WriteLine("");
            errschreiber.WriteLine("Fehler fängt hier an: ");
            errschreiber.WriteLine(e);
            errschreiber.WriteLine("---------------");
            errschreiber.Close();
            errlogdatei.Close();
            Exit();
        }
    }
}
