using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Assignment3
{
    public partial class Form1 : Form
    {
        String username;
        Socket s;

        public Form1(String Username)
        {

            InitializeComponent();

            this.username = Username;

            Connecttoserver();

        }

        public bool Connecttoserver()
        {
            byte[] bytes = new byte[1024];

            try
            {
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.    
                s = new Socket(ipAddress.AddressFamily,
                 SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    s.Connect(remoteEP);

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Cannot Connect to Server");

                    Application.Exit();
                }

                byte[] Bytes = new byte[1024];
                // Encode the data string into a byte array.    
                byte[] msg = Encoding.ASCII.GetBytes(username);
                // Send the data through the socket.    
                int bytesSent = s.Send(msg);

                handleClinet client = new handleClinet();
                client.startClient(s, messagebox, usersnames);

            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
                return true;
          
        }
        private void button1_Click_1(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(yourmessage.Text))
            {

            }
            else
            {
                byte[] Bytes = new byte[1024];
                // Encode the data string into a byte array.    
                byte[] msg = Encoding.ASCII.GetBytes(username+" "+yourmessage.Text);
                messagebox.Items.Add("Me: " + yourmessage.Text);
                // Send the data through the socket.    
                int bytesSent = s.Send(msg);


            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            byte[] Bytes = new byte[1024];
      
            byte[] msg = Encoding.ASCII.GetBytes("b#"+" "+username);
         
            int bytesSent = s.Send(msg);

          
            
        }
    }

    public class handleClinet
    {
        Socket clientSocket;
        ListBox listBox;
        ListBox userNames;
        public void startClient(Socket inClientSocket,ListBox list,ListBox uns)
        {
            this.clientSocket = inClientSocket;
            Thread ctThread = new Thread(receivemssg);
            this.listBox = list;
            this.userNames = uns;
            ctThread.Start();
        }

        private void receivemssg()
        {
            while (true)
            {
                byte[] recbytes = new byte[1024];
                int bytesRec = clientSocket.Receive(recbytes);
                String servermssg = Encoding.ASCII.GetString(recbytes, 0, bytesRec);
                string[] servermessages = servermssg.Split(' ');
                if (servermessages[0].Equals("#"))
                {
                   
                    userNames.Items.Add(servermessages[1]);
                }
                else
                {
                    listBox.Items.Add(servermssg);
                }
            }
        }
    }
}
