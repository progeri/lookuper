using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using ClassLibrary;

namespace LookUpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("LookUpServer.exe.config");
            Utils.DumpAllInfoAboutRegisteredRemotingTypes();

            Console.WriteLine("\nPress any key to close");
            Console.ReadKey();

        }
    }
}
