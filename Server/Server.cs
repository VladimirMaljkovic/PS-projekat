using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class Server
    {
        private Socket serverskiSocket;
        static List<KlijentskaNit> klijentskeNiti = new List<KlijentskaNit>();

        public void Start()
        {
            serverskiSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverskiSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), int.Parse(ConfigurationManager.AppSettings["port"])));
            serverskiSocket.Listen(10);
            try
            {
                while (true)
                {
                    Socket klijentskiSoket = serverskiSocket.Accept();
                    KlijentskaNit klijentskaNit = new KlijentskaNit(klijentskiSoket);
                    klijentskeNiti.Add(klijentskaNit);
                    Thread nit = new Thread(klijentskaNit.ObradiZahteve);
                    nit.IsBackground = true;
                    nit.Start();
                }
            }
            catch (IOException e)
            {
                serverskiSocket.Close();
            }
            catch (SocketException e)
            {
                serverskiSocket.Close();
            }
        }

        internal void Stop()
        {
            try
            {
                serverskiSocket.Close();
                foreach (KlijentskaNit nit in klijentskeNiti)
                {
                    nit.klijentskiSoket.Close();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
