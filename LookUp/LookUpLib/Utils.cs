using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;

namespace ClassLibrary
{
    public class Utils
    {
        private static void DumpTypeEntries(Array arr)
        {
            foreach (object obj in arr)
            {
                Console.WriteLine(obj.GetType().Name+" : "+ obj);
            }
        }

        public static void DumpAllInfoAboutRegisteredRemotingTypes()
        {
            Console.WriteLine("ALL REGISTERED TYPES IN REMOTING -(BEGIN)---------");

            DumpTypeEntries(RemotingConfiguration.GetRegisteredActivatedClientTypes());
            DumpTypeEntries(RemotingConfiguration.GetRegisteredActivatedServiceTypes());
            DumpTypeEntries(RemotingConfiguration.GetRegisteredWellKnownClientTypes());
            DumpTypeEntries(RemotingConfiguration.GetRegisteredWellKnownServiceTypes());

            Console.WriteLine("ALL REGISTERED TYPES IN REMOTING -(END)  ---------");
        }

        public static void ShowLeaseInfo(ILease leaseInfo)
        {
            Console.WriteLine();
            if (leaseInfo != null)
            {
                Console.WriteLine("Lease Info : ");

                //Show current lease time
                Console.WriteLine("Current Lease Time: {0}:{1}",
                    leaseInfo.CurrentLeaseTime.Minutes,
                    leaseInfo.CurrentLeaseTime.Seconds);

                //Show the initial lease time
                Console.WriteLine("Initial Lease Time: {0}:{1}",
                    leaseInfo.InitialLeaseTime.Minutes,
                    leaseInfo.InitialLeaseTime.Seconds);

                //Show the renew on call time
                Console.WriteLine("Renew on call time: {0}:{1}",
                    leaseInfo.RenewOnCallTime.Minutes,
                    leaseInfo.RenewOnCallTime.Seconds);

                //Show thr current state
                Console.WriteLine("Current state: {0}", leaseInfo.CurrentState);
            }
            else 
            {
                Console.WriteLine("No Lease Info");
            }
        }

    }
}
