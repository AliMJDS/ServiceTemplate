
using ServiceTemplate;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Timers;
using System.Xml.Serialization;
using static FileDataSynhcronizer.Program;
using File = System.IO.File;

namespace FileDataSynhcronizer
{
    class Program
    {
        static void Main(string[] args)
        {
            if ((!Environment.UserInteractive))
            {
                Program.RunAsAService();
            }
            else
            {
                if (args != null && args.Length > 0)
                {
                    if (args[0].Equals("-i", StringComparison.OrdinalIgnoreCase))
                    {
                        SelfInstaller.InstallMe();
                    }
                    else
                    {
                        if (args[0].Equals("-u", StringComparison.OrdinalIgnoreCase))
                        {
                            SelfInstaller.UninstallMe();
                        }
                        else
                        {
                            Console.WriteLine("Invalid argument!");
                        }
                    }
                }
                else
                {
                    Program.RunAsAConsole();
                }
            }
        }

        static void RunAsAConsole()
        {



            Console.WriteLine("Starting Program in Console Mode");
            Console.ReadKey();
        }

        static void RunAsAService()
        {
            Console.WriteLine("Installing Service");

            ServiceBase[] servicesToRun = new ServiceBase[]
           {
                new ServiceWorker()
           };
            ServiceBase.Run(servicesToRun);
        }


    }
}

