using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication
{
   public static class UserInformation
    {
       /// <summary>
       /// This is current use for Connection between server and User
       /// </summary>
       public static TcpClient ClientTcp { get; set; }
       /// <summary>
       ///This is current user for Connection between server and Room
       /// </summary>
       public static TcpClient ClientRoom { get; set; }

       /// <summary>
       /// Current UserName or Name
       /// </summary>
       public static string Name { get; set; }
       /// <summary>
       /// Current GUID
       /// </summary>
       public static Guid ID { get; set; }
    }
}
