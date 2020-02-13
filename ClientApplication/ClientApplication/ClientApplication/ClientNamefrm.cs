using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace ClientApplication
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            TcpClient _client = new TcpClient();
            UserInformation.ClientTcp = _client;

        }
       
        private void btnConnect_Click(object sender, EventArgs e)
        {
            UserInformation.ClientTcp.Connect("127.0.0.1", 9000);
            UserInformation.ClientTcp.NoDelay = true;
            UserClient client = new UserClient
            {
                ID = Guid.NewGuid(),
                UserName = txtClient.Text,
                TypeOfRequest = TypeOfRequest.CreateNewUser,
              

            };

            UserInformation.ClientTcp.Client.Send(Encoding.Default.GetBytes( JsonConvert.SerializeObject(client)));
            byte[] array = new byte[200];
            UserInformation.ClientTcp.Client.Receive(array);
            string info = Encoding.Default.GetString(array);
         
            UserClient Iam = JsonConvert.DeserializeObject<UserClient>(info.Replace('\0', ' '));

            if (Iam != null)
            {
                UserInformation.ID = Iam.ID;
                UserInformation.Name = Iam.Name;
                Roomsfrm frm = new Roomsfrm(Iam.ID, Iam.UserName);
                frm.Show();
                this.Hide();
            }
           
          

           
             
           


            
        }
    }
}
