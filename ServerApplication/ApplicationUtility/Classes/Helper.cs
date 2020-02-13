using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApplicationUtility.Classes
{
   static class Helper<T>
    {
       public static T ReciveConvert(TcpClient soket)
       {
           byte[] array = new byte[soket.ReceiveBufferSize];
           soket.Client.Receive(array);
           T value = JsonConvert.DeserializeObject<T>(ASCIIEncoding.Default.GetString(array));
           return value;
          
       }
       public static void SendConvert(T obj, TcpClient soket)
       {
        string msg = JsonConvert.SerializeObject(obj);
        byte[] array =  ASCIIEncoding.Default.GetBytes(msg);
        soket.Client.Send(array);

       }


       public static void SendConvert(string message, TcpClient soket)
       {
          
           byte[] array = ASCIIEncoding.Default.GetBytes(message);
           soket.Client.Send(array);

       }
    }
}
