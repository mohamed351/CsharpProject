using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ServerElemets;

namespace ApplicationUtility
{   // This is handle the Send And Recive Request
    public delegate void ClientHandle(UsersServer User, IViewer viewr);

    /// <summary>
    /// This class use Information of UserServer and User Operation
    /// </summary>
    public class UsersServer
    {   
        public event ClientHandle OnClientSend;
        public event ClientHandle OnClientRecive;

        /// <summary>
        /// this is for Create new UserServer > Name , Soket
        /// </summary>
        /// <param name="Name">descript the name of User</param>
        /// <param name="soket">descript the Soket </param>
        public UsersServer(string Name, Socket soket)
        {
            this.ID = Guid.NewGuid();
            UserName = Name;
            this.SoketOfUser = soket;
            this.IsFirstTime = true;
            Thread = new Thread(OpenSessionToMe);
            Thread.Start();

        }

        public Guid ID { get; set; }
        public string UserName { get; set; }
        public IPEndPoint EndPoint { get; set; }
        [JsonIgnore]
        public Socket SoketOfUser { get; set; }
        [JsonIgnore]
        public Thread Thread { get; set; }
        public bool IsFirstTime { get; set; }

        private  void OpenSessionToMe()
        {
            try
            {
                ViewerData view = new ViewerData();
                while (true)
                {

                        byte[] array = new byte[1000];
                        this.SoketOfUser.Receive(array);
                        if (OnClientRecive != null)
                        {
                            string reciver = Encoding.Default.GetString(array).Replace('\0', ' ');
                            ViewerData viewer = JsonConvert.DeserializeObject<ViewerData>(reciver);
                            Task.Run(() => { OnClientRecive(this, viewer); });
                         
                        }
                    }

              
            }
            catch
            {
                Console.WriteLine("=============================================================================");
                Console.WriteLine("User > ID :{0}\nUserName:{1}\nIpAddress:{2}\nPort:{3}\nstatus:out\ntime:{4}\n ",this.ID,this.UserName,this.EndPoint.Address,this.EndPoint.Port,DateTime.Now.ToString());
                Console.WriteLine("=============================================================================");
               //we should delete the users
            }



        }

       

  
   
       
    }


   

   
}
