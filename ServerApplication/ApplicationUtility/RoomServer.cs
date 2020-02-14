using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using System.Net;
using System.Configuration;


namespace ApplicationUtility
{
   public  enum Categories
    {
        Animals,
        Food,
        Random

    }
    public delegate void RoomAddUserHandler(Socket soket,string data,RoomServer server);
    public class RoomServer
    {


        static int indexer =1;
       

        public RoomServer(Guid ID,string roomName)
        {
          
            
            if (this.RoomName == null)
            {
                this.ID = ID;
                this.RoomName = roomName;
                this.Watchers = new List<Socket>();
                
                 
              
            }


        }
        public event RoomAddUserHandler OnPlayerOrWatcherEnter;

        public RoomServer(Guid ID, string roomName, int port, string Ip)
            : this(ID, roomName)
        {
             indexer++;
            this.PortIndex = port;
            this.PortIndex = port + indexer;
            this.IpAddressString = Ip;
            this.IpAddress = IPAddress.Parse(Ip);
            this.Listener = new TcpListener(this.IpAddress,(port+indexer));
            this.Listener.Start();
            this.ThreadOperation = new Thread(OnRoomRun);
            this.ThreadOperation.Start();

        }
      
        public Guid ID { get; set; }
        [JsonIgnore]
        public TcpListener Listener { get; set; }

        public string RoomName { get; set; }
        [JsonIgnore]
        public Socket Player1 { get; set; }

        public Guid Player1ID { get; set; }

        public string PlayerName1 { get; set; }

        [JsonIgnore]
        public Socket Player2 { get; set; }

        public Guid Player2ID { get; set; }

        public string PlayerName2 { get; set; }

       [JsonIgnore]
        public IPAddress IpAddress { get; set; }

        public string IpAddressString { get; set; }


        [JsonIgnore]
        public List<Socket> Watchers { get; set; }
       
        [JsonIgnore]
        public Thread   ThreadOperation { get; set; }

        [JsonIgnore]
        public Thread ClientSendAndRecive { get; set; }

        public Categories Categories { get; set; }


        public int PortIndex { get; set; }

        public bool IsStarted { get; set; }

        public int typeOfUser { get; set; }

        private void OnRoomRun()
        {
            try
            {

                while (true)
                {

                    Socket soket = Listener.AcceptSocket();
                    byte[] arrayOfFirstRequest = new byte[soket.ReceiveBufferSize];
                   
                    soket.Receive(arrayOfFirstRequest);
                    string data = ASCIIEncoding.Default.GetString(arrayOfFirstRequest);
                    if (OnPlayerOrWatcherEnter != null)
                    {
                        Task.Run(() => OnPlayerOrWatcherEnter(soket, data,this));
                    }

                }
            }
            catch 
            {

                this.ThreadOperation.Abort();
            }
           



        }

       



    }
}
