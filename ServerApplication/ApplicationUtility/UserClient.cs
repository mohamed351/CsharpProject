using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ServerElemets;
namespace ApplicationUtility
{
    public class UserClient
    {
        public Guid ID { get; set; }

        public string UserName { get; set; }
        [JsonIgnore]
        public IPEndPoint EndPoint { get; set; }

        public string Name { get; set; }

        public string IpAddress { get; set; }

        public string Port { get; set; }

        public TypeOfRequest TypeOfRequest { get; set; }


        ~UserClient()
        {
            UserName = null;
            EndPoint = null;
            Name = null;
            IpAddress = null;
            Port = null;
            GC.Collect();

        }

    }
}
