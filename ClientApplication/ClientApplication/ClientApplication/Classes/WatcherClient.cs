using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication.Classes
{
   public class WatcherClient
    {
       public WatcherClient()
       {
           history = new List<char>();
       }
       
        public string PlayerName { get; set; }
        public string Word { get; set; }
        public char Key { get; set; }
        public List<char> history { get; set; }
    }
}
