using System;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace Server
{
    class Program
    {
       
        static void Main(string[] args)
        {

            startServer();
        
        }

        public static void startServer()
        {
            List<String> Users=new List<String>();
            List<Socket> userssockets = new List<Socket>();
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            try
            {
                // Create a Socket that will use Tcp protocol      
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // A Socket must be associated with an endpoint using the Bind method  
                listener.Bind(localEndPoint);
                // Specify how many requests a Socket can listen before it gives Server busy response.  
                // We will listen 1000 requests at a time  
                string data = null;
                while (true)
                {
                    data = null;
                    listener.Listen(1000);

                    Console.WriteLine("Waiting for a connection...");
                    Socket clienthandler = listener.Accept();

                  
                    byte[] bytes = new byte[1024];
                    int bytesRec = clienthandler.Receive(bytes);
                     data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    data = "#" +" "+ data;
                    Users.Add(data);
                    
      
                    foreach (String s in Users)
                    {
                        byte[] usersnames = Encoding.ASCII.GetBytes(s);
                        Thread.Sleep(1000);
                        clienthandler.Send(usersnames);
                    }


                    foreach (Socket s in userssockets)
                    {
                        if (!s.Equals(clienthandler))
                        {
                            byte[] newuser = Encoding.ASCII.GetBytes(data);
                            s.Send(newuser);
                        }
                    }
                    userssockets.Add(clienthandler);
                    handleClinet client = new handleClinet();
                    client.startClient(clienthandler, userssockets,Users);
                }

              
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

    public class handleClinet
    {
        Socket clientSocket;
        string clientname;
        List<Socket> userssockets;
        List<String> Usersnames;
        public void startClient(Socket inClientSocket,List<Socket> sockets,List<String> u)
        {
            this.clientSocket = inClientSocket;
            Thread ctThread = new Thread(startChat);
            this.userssockets = sockets;
            this.Usersnames = u;
            ctThread.Start();
        }

        private void startChat()
        {
            string data = null;
            byte[] bytes = new byte[1024];
            
          
            while (true)
            {
                data = null;

                try
                {
                    if (clientSocket.Connected)
                    {
                        int bytesRec = clientSocket.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        byte[] msg = Encoding.ASCII.GetBytes(data);

                        string[] servermessages = data.Split(' ');
                        if (servermessages[0].Equals("b#"))
                        {
                            List<String> temp = new List<String>();
                           
                            foreach (String s in Usersnames)
                            {
                                
                                if (s.Equals("#"+" "+servermessages[1]))
                                {
                                     
                                    //Usersnames.Remove(s);
                                }
                                else
                                {
                                    temp.Add(s);
                                }
                            }
                            
                            Usersnames.Clear();

                            foreach (String s in temp)
                            {
                                Usersnames.Add(s);
                            }
                           

                           /* foreach (Socket s in userssockets)
                            {
                                if (s.Equals(clientSocket))
                                {
                                    userssockets.Remove(s);
                                    s.Close();
                                }
                            }*/

                        }
                        else
                        {

                            foreach (Socket s in userssockets)
                            {
                                if (s.Connected)
                                {
                                    if (!s.Equals(clientSocket))
                                    {
                                        s.Send(msg);
                                    }
                                }
                            }
                        }
                    }
                }

                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }

                
            }
            
        }
    }
}
