using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading.Tasks;

namespace netinfo
{
    class Program
    {
        static void Main(string[] args)
        {
            IPGlobalProperties wlasnosciIP = IPGlobalProperties.GetIPGlobalProperties();
            Console.WriteLine("Nazwa hosta: " + wlasnosciIP.HostName);
            Console.WriteLine("Nazwa domeny: " + wlasnosciIP.DomainName);
            Console.WriteLine();
            int licznik = 0;
            foreach (NetworkInterface kartySieciowe in NetworkInterface.GetAllNetworkInterfaces())
            {
                Console.WriteLine("Karta #" + ++licznik + ": " + kartySieciowe.Id);
                Console.WriteLine(" Adres MAC: " + kartySieciowe.GetPhysicalAddress().ToString());
                Console.WriteLine(" Nazwa: " + kartySieciowe.Name);
                Console.WriteLine(" Opis: " + kartySieciowe.Description);
                Console.WriteLine(" Status: " + kartySieciowe.OperationalStatus);
                Console.WriteLine(" Szybkość: " + (kartySieciowe.Speed) / (double)1000000 + " Mb/s");
                Console.WriteLine(" Adresy bram sieciowych:");
                foreach (GatewayIPAddressInformation adresBramy in kartySieciowe.GetIPProperties().GatewayAddresses)
                    Console.WriteLine(" " + adresBramy.Address.ToString());
                Console.WriteLine(" Serwery DNS:");
                foreach (IPAddress adresIP in kartySieciowe.GetIPProperties().DnsAddresses)
                    Console.WriteLine(" " + adresIP.ToString());
                Console.WriteLine(" Serwery DHCP:");
                foreach (IPAddress adresIP in kartySieciowe.GetIPProperties().DhcpServerAddresses)
                    Console.WriteLine(" " + adresIP.ToString());
                Console.WriteLine(" Serwery WINS:");
                foreach (IPAddress adresIP in kartySieciowe.GetIPProperties().WinsServersAddresses)
                    Console.WriteLine(" " + adresIP.ToString());
                Console.WriteLine();
                Console.WriteLine(" Aktualne połączenia TCP/IP typu klient:");
                foreach (TcpConnectionInformation polaczenieTCP in
                IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections())
                {
                    Console.WriteLine(" Zdalny adres: " + polaczenieTCP.RemoteEndPoint.Address.ToString() + ":" + polaczenieTCP.RemoteEndPoint.Port);
                    Console.WriteLine(" Status: " + polaczenieTCP.State.ToString());
                }
                Console.WriteLine(" Aktualne połączenia TCP/IP typu serwer:");
                foreach (IPEndPoint polaczenieTCP in
                IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners())
                    Console.WriteLine(" Zdalny adres: " + polaczenieTCP.Address.ToString() + ":" + polaczenieTCP.Port);
                Console.WriteLine(" Aktualne połączenia UDP:");
                foreach (IPEndPoint polaczenieUDP in
                IPGlobalProperties.GetIPGlobalProperties().GetActiveUdpListeners())
                    Console.WriteLine(" Zdalny adres" + polaczenieUDP.Address.ToString() + ":" + polaczenieUDP.Port);
                Console.ReadLine();
            }
        }
    }
}
