using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HangmanServer
{
    class Program
    {
        public static string randomWord;
        static void Main(string[] args)
        {
            byte[] bt = new byte[] { 127, 0, 0, 1 };
            IPAddress localAddr = new IPAddress(bt);
            int port = 1028;
            NetworkStream nStream;
            TcpListener server = new TcpListener(localAddr, port);
            server.Start();
            Console.WriteLine("Start listening");
            
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                nStream = client.GetStream();
                //Receive request from client with category
                byte[] dataBuffer = new byte[client.ReceiveBufferSize];
                int byteStreams = nStream.Read(dataBuffer, 0, dataBuffer.Length);
                string receivedMsg = Encoding.ASCII.GetString(dataBuffer, 0, byteStreams);
                Console.WriteLine("Received Category: " + receivedMsg);
                ReadFromFile(receivedMsg);
                //send random word to client
                byte[] sendingMsg = Encoding.ASCII.GetBytes(randomWord);
                nStream.Write(sendingMsg, 0, sendingMsg.Length);
            }
          

        }

        //function to read categories from file and select random word the send it to client 
        private static void ReadFromFile(string category)
        {
            string path = category + ".txt";
            string[] wordsFile = File.ReadAllLines(path);
            Random random = new Random();
            randomWord = wordsFile[random.Next(wordsFile.Length)];
            Console.WriteLine("Random Word is " + randomWord);

        }
    }
}
