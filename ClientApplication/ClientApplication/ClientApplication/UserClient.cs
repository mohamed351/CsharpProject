using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClientApplication
{
    public enum TypeOfRequest
    {
        CreateNewUser = 1,
        MakeRoom = 2,

    }
    public class UserClient
    {
        public UserClient()
        {
            this.EndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 0);
        }
        public Guid ID { get; set; }

        public string UserName { get; set; }
         [JsonIgnore]
        public IPEndPoint EndPoint { get; set; }

         public string Name { get; set; }

         public string IpAddress { get; set; }

         public string Port { get; set; }
       
        public TypeOfRequest TypeOfRequest { get; set; }

       

    }
}
