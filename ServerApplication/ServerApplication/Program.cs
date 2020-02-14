using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Configuration;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using ApplicationUtility;
using ServerApplication.Classes;
using ServerElemets;



namespace ServerApplication
{
    /// <summary>
    /// Category File
    /// </summary>
    public enum Category
    {
        Animals,
        Color,
        Fruits

    }
    /// <summary>
    /// This is  application Server 
    /// </summary>
    /// 
    public class Program
    {
        /// <summary>
        /// TcpListern this listern for requests 
        /// </summary>
       public static TcpListener _listern; 
        /// <summary>
        /// User List That Contains Players
        /// </summary>
       public static List<UsersServer> _users= new List<UsersServer>();
        /// <summary>
        /// List Of Rooms
        /// </summary>
       public static List<RoomServer> Rooms = new List<RoomServer>();

       public static string randomWord;

      
        
        static void Main(string[] args)
        {
            //keyCode
            ConsoleKeyInfo key ;
            Thread th;
           
                Console.WriteLine("Start Server ...");
                // get these data from AppConfig
                IPAddress address = IPAddress.Parse(ConfigurationManager.AppSettings["IpAddress"]);
                int PortNumber = int.Parse(ConfigurationManager.AppSettings["Port"]);
                //Create tcp Listern
                _listern = new TcpListener(address, PortNumber);
                _listern.Start();
                th = new Thread(ListenToNewUser);
                th.Start();
                Console.WriteLine("to Stop The Server Press Ctrl+C");
            do
            {
                key = Console.ReadKey();

            } while (key.Key == ConsoleKey.C && key.Modifiers == ConsoleModifiers.Control);
           
            th.Abort();
           



        }
        public static void ListenToNewUser()
        {
            try
            {
                while (true)
                {
                    Socket soket = _listern.AcceptSocket();
                    byte[] array = new byte[soket.ReceiveBufferSize];
                    soket.Receive(array);
                    string Information = Encoding.Default.GetString(array).Replace('\0', ' ').ToString();

                    UserClient Client = JsonConvert.DeserializeObject<UserClient>(Information);
                    if (Client.TypeOfRequest == TypeOfRequest.CreateNewUser)
                    {
                        UsersServer server = new UsersServer(Client.UserName, soket);
                        server.OnClientRecive += server_OnClientRecive;
                        server.OnClientSend += server_OnClientSend;
                        server.EndPoint = (IPEndPoint)soket.RemoteEndPoint;
                        Client.ID = server.ID;
                        _users.Add(server);
                    }
                  
                    Client.IpAddress = ((IPEndPoint)soket.RemoteEndPoint).Address.ToString();
                    Client.Name = Client.UserName;
                    Client.Port = ((IPEndPoint)soket.RemoteEndPoint).Port.ToString();

                    string message = JsonConvert.SerializeObject(Client);
                    soket.Send(Encoding.Default.GetBytes(message));
                    Console.WriteLine("===================UserCreaded==================");
                    Console.WriteLine("User is Creaded ..>");
                    Console.WriteLine("Name :" + Client.ID);
                    Console.WriteLine("IpAddress : " + Client.IpAddress);
                    Console.WriteLine("Name : " + Client.Name);
                    Console.WriteLine("Port : " + Client.Port);
                    Console.WriteLine("DateTime: " + DateTime.Now.ToString());
                    Console.WriteLine("===========================================");


                }
            }
            catch
            {

            }
         

        }

        static void server_OnClientSend(UsersServer User, IViewer viewr)
        {
           
            
        }

        static  void server_OnClientRecive(UsersServer User, IViewer viewr)
        {
            try
            {
                if (viewr.TypeOfRequest == TypeOfRequest.MakeRoom)
                {
                    Room room = JsonConvert.DeserializeObject<Room>(viewr.Body);
                    Console.WriteLine("====================Room has been Created ================== ");
                    Console.WriteLine("RoomName :{0}", room.RoomName);
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("\tThe User Created :{0}", room.Player1.Name);
                    Console.WriteLine("\tThe UserID:{0}", room.Player1.ID);
                 
                    int PortNumber = Convert.ToInt32( ConfigurationManager.AppSettings["Port"]);
                    string Ip = ConfigurationManager.AppSettings["IpAddress"];
                     
                    RoomServer roomserver = new RoomServer(Guid.NewGuid(), room.RoomName, PortNumber, Ip);
                    roomserver.Player1ID = room.Player1.ID;
                    roomserver.PlayerName1 = room.Player1.Name;
                  string message =  JsonConvert.SerializeObject(roomserver);
                  User.SoketOfUser.Send(ASCIIEncoding.Default.GetBytes(message));
                 roomserver.OnPlayerOrWatcherEnter+=roomserver_OnPlayerOrWatcherEnter;
                    Rooms.Add(roomserver);
                    



                }
                else if (viewr.TypeOfRequest == TypeOfRequest.GetRoomCollection)
                {
                   
                   string message = JsonConvert.SerializeObject(Rooms.ToList().ToArray());
                   User.SoketOfUser.Send(ASCIIEncoding.Default.GetBytes(message));


                }
            }
            catch
            {
               UsersServer server= _users.SingleOrDefault(a => a.ID == User.ID);
               _users.Remove(server);

                User.Thread.Abort();
            }
        }

            static void roomserver_OnPlayerOrWatcherEnter(Socket soket, string data, RoomServer server)
            {
 	            RoomClient client = JsonConvert.DeserializeObject<RoomClient>(data);
                if (client.typeOfUser == 0)
                {
                    if (server.Player1 == null)
                    {
                        server.Player1 = soket;
                        ShowRoomInformation(client);

                    }
                    else if (server.Player2 == null)
                    {
                        Helper.SendConvert("Player : " + client.PlayerName2 + " \nID: " + client.Player2ID, server.Player1);
                        string message = Helper.ReciveConvert(server.Player1).Replace("\0", string.Empty);

                        if (message == "6")
                        {
                            server.Player2 = soket;
                            ShowRoomInformation(client);
                            server.Player2 = soket;
                            Category cat = (Category)client.Categories;
                            Helper<RoomClient>.SendConvert(client, server.Player2);
                            server.ClientSendAndRecive = new Thread(SendAndReciveTheCharacters);
                            server.ClientSendAndRecive.Start(server);




                        }
                        else
                        {
                            server.Player2ID = new Guid();
                            server.PlayerName2 = null;
                            client.Player2ID = new Guid();
                            client.PlayerName2 = null;
                            Helper<RoomClient>.SendConvert(client, server.Player2);

                        }
                    }



                }
                else if(client.typeOfUser == 1)
                {
                    Console.WriteLine("Watcher...");
                    Console.WriteLine("watching for  Room :"+server.RoomName);
                    Console.WriteLine("watching for ID :"+server.ID);
                    server.Watchers.Add(soket);

                    
                    

                }


          }

            private static void SendAndReciveTheCharacters(object obj)
            {
               
                bool flagword = true;
                bool flag = true;
                string word="";
                while (true)
                {
                    
                    RoomServer server = (RoomServer)obj;
                      
                    if(string.IsNullOrEmpty(word)){
                    word = ReadFromFile(server.Categories.ToString());
                      
                    }
                    
                    word.Replace("\0", string.Empty);
                    if (server.IsStarted == false)
                    {
                        Helper.SendConvert(word, server.Player1);
                        Helper.SendConvert(word, server.Player2);
                        SendWatchers(server, word);
                        server.IsStarted = true;
                    }
                    else
                    {
                        if (flag)
                        {
                            string message = Helper.ReciveConvert(server.Player1);
                            message = message.Replace("\0", string.Empty);
                            SendWatchers(server, "Player 1:" + message);
                            if (message != "false")
                            {
                                Console.WriteLine(message);
                                Helper.SendConvert(message, server.Player2);
                             

                            }
                            else
                            {
                                Helper.SendConvert("false", server.Player2);
                                
                                flag = false;
                            }
                        }
                        else
                        {
                            string message = Helper.ReciveConvert(server.Player2);
                            message = message.Replace("\0", string.Empty);

                            SendWatchers(server, "Player 2:" + message);

                            if (message != "false")
                            {
                                Console.WriteLine(message);
                                Helper.SendConvert(message, server.Player1);

                            }
                            else
                            {
                                Helper.SendConvert("false", server.Player1);
                                flag = true;
                            }

                        }

                    }


               
                }
                

                
            }

      
            
       
          
        

        private static void ShowRoomInformation(RoomClient client)
        {
            Console.WriteLine("Room Status :");
            Console.WriteLine("----------------");
            Console.WriteLine("\tRoom ID: " + client.ID);
            Console.WriteLine("\t Room Name :" + client.RoomName);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("\tPlayer1:");
            if (client.PlayerName1 != null)
            {
                Console.WriteLine("\t\tPlayer1 ID: " + client.Player1ID);
                Console.WriteLine("\t\tPlayer1 Name : " + client.PlayerName1);


            }
            else
            {
                Console.WriteLine("\tPlayer 1 isn't Exist..");
            }
            if (client.PlayerName2 != null)
            {
                Console.WriteLine("\t\tPlayer2 ID: " + client.Player2ID);
                Console.WriteLine("\t\tPlayer2 : " + client.PlayerName2);

            }
            else
            {
                Console.WriteLine("Player 2 isn't Exist ..");
            }

        }




        private static string ReadFromFile(string category)
        {
            string path = category + ".txt";
            string[] wordsFile = File.ReadAllLines(path);
            Random random = new Random();
            randomWord = wordsFile[random.Next(wordsFile.Length)];
            return randomWord;

        }
        private static void SendWatchers(RoomServer server,string meg)
        {
            foreach (var item in server.Watchers)
            {
                Helper.SendConvert(meg,item);

            }
        }
    }
}
