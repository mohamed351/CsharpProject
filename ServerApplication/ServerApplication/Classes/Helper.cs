using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServerApplication.Classes
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
       public static void SendConvert(T obj, TcpClient tcpclient)
       {
        string msg = JsonConvert.SerializeObject(obj);
        byte[] array =  ASCIIEncoding.Default.GetBytes(msg);
        tcpclient.Client.Send(array);

       }

       public static void SendConvert(T obj, Socket soket)
       {
           string msg = JsonConvert.SerializeObject(obj);
           byte[] array = ASCIIEncoding.Default.GetBytes(msg);
           soket.Send(array);

       }


       
    }
  public static class Helper
   {
       public static void SendConvert(string message, Socket soket)
       {

           byte[] array = ASCIIEncoding.Default.GetBytes(message);
           soket.Send(array);

       }
       public static string ReciveConvert(Socket soket)
       {

           byte[] array  = new byte[soket.ReceiveBufferSize];
           soket.Receive(array);
          return ASCIIEncoding.Default.GetString(array);
       }

    

   }
}
