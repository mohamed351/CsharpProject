using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication
{
  public  class RoomClient
    {

        public string ID { get; set; }
        public string RoomName { get; set; }
        public Guid Player1ID { get; set; }
        public string PlayerName1 { get; set; }
        public Guid Player2ID { get; set; }
        public string PlayerName2 { get; set; }
        public string IpAddressString { get; set; }
        public int Categories { get; set; }
        public int PortIndex { get; set; }
        public bool IsStarted { get; set; }

    }


}
