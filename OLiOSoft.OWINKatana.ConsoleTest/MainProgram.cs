using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OLiOSoft.OWINKatana.ConsoleTest
{
    using OLiOSoft.OWINKatana.OHosted.OManager;
    using OLiOSoft.OWINKatana.TestHost;
    using OLiOSoft.OWINKatana.TestHost1;

    class MainProgram
    {
        static void Main(string[] args)
        {
            OLiOHostedCentre hostedCentre = OLiOHostedCentre.CreateSingletonMaster;

            hostedCentre.Run<TestHosted>();

            hostedCentre.Run<TestHosted1>();

            Thread.Sleep(6000);
            hostedCentre.Inspect();

            hostedCentre.Stop<TestHosted>();

            Thread.Sleep(6000);
            hostedCentre.Inspect();

            hostedCentre.Release();

            Thread.Sleep(6000);
            hostedCentre.Inspect();

            hostedCentre.Run<TestHosted>();

            Thread.Sleep(6000);
            hostedCentre.Inspect();

            Console.WriteLine("Done..");

            Console.ReadLine();
        }
    }
}
