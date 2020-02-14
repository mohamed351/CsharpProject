using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServerElemets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientApplication.Classes;
using System.Net;


namespace ClientApplication
{
    public partial class Roomsfrm : Form
    {
        List<Room> room = new List<Room>();
        List<RoomClient> roomClient = new List<RoomClient>();
        public Roomsfrm(Guid ID, string Name)
        {
            InitializeComponent();
            this.txtID.Text = ID.ToString();
            this.txtName.Text = Name;
        }
        public Roomsfrm()
        {

        }
        private void Roomsfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();

        }

        private void btnCreateRoom_Click(object sender, EventArgs e)
        {
            using (NewRoom frm = new NewRoom(Guid.Parse(txtID.Text),txtName.Text))
            {

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Room rom = new Room(frm.RoomName)
                    {
                        Player1 = new ConnectedUser() { ID = frm.PlayerAdminID, Name = frm.PlayerName },
                        TypeOfRequest = ServerElemets.TypeOfRequest.MakeRoom,
                      
                    };
                    rom.RequestNumber = (int)ServerElemets.TypeOfRequest.MakeRoom;
                    ViewerData viewer = new ViewerData()
                    {
                        Body = rom.Body,
                        RequestNumber = rom.RequestNumber,
                        TypeOfRequest = ServerElemets.TypeOfRequest.MakeRoom

                    };

                 UserInformation.ClientTcp.Client.Send(ASCIIEncoding.Default.GetBytes(JsonConvert.SerializeObject(viewer)));
                 RoomClient Client=  Helper<RoomClient>.ReciveConvert(UserInformation.ClientTcp);
                 Client.Categories = frm.Category;
                 Client.Player1ID = UserInformation.ID;
                 Client.PlayerName1 = UserInformation.Name;

                 UserInformation.ClientRoom = new System.Net.Sockets.TcpClient();
                 
                 UserInformation.ClientRoom.Connect(IPAddress.Parse(Client.IpAddressString), Client.PortIndex);

                 Helper<RoomClient>.SendConvert(Client, UserInformation.ClientRoom);
                    
                  
                  
                 GetRooms();
                 
               GameLogicfrm game = new GameLogicfrm(TypeOfPlayer.Player1);


                    game.ShowDialog();

                  
                
                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

            GetRooms();

            
            
            
        }

        private void GetRooms()
        {
            ViewerData data = new ViewerData();
            data.TypeOfRequest = ServerElemets.TypeOfRequest.GetRoomCollection;
            data.Body = "GetRooms";
            string serlization = JsonConvert.SerializeObject(data);
            UserInformation.ClientTcp.Client.Send(ASCIIEncoding.Default.GetBytes(serlization));
            byte[] array = new byte[UserInformation.ClientTcp.ReceiveBufferSize];
            UserInformation.ClientTcp.Client.Receive(array);
            string message = ASCIIEncoding.Default.GetString(array);
            listRooms.DataSource = JsonConvert.DeserializeObject<RoomClient[]>(message).ToList();
            listRooms.ValueMember = "ID";
            listRooms.DisplayMember = "RoomName";
        }

        private void Roomsfrm_Load(object sender, EventArgs e)
        {
            GetRooms();
        
        
          
            
            
           

        }

        private void joinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listRooms.SelectedItem != null)
            {
                RoomClient client = (RoomClient)listRooms.SelectedItem;
                if (client.PlayerName2 != null)
                {
                    MessageBox.Show("This Room is Full Please Select Another room or be watcher", "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                   DialogResult result =  MessageBox.Show("Do you want to send message to "+client.PlayerName1 +"\nID : "+client.Player1ID,"message",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                   if (result == System.Windows.Forms.DialogResult.Yes)
                   {
                       //send to Server 
                    
                       UserInformation.ClientRoom = new System.Net.Sockets.TcpClient();
                       UserInformation.ClientRoom.Connect(client.IpAddressString, client.PortIndex);
                       client.PlayerName2 = UserInformation.Name;
                       client.Player2ID = UserInformation.ID;
                       Helper<RoomClient>.SendConvert(client, UserInformation.ClientRoom);
                      var room =  Helper<RoomClient>.ReciveConvert(UserInformation.ClientRoom);
                      if (room.PlayerName2 != null)
                      {
                          GameLogicfrm frm = new GameLogicfrm(TypeOfPlayer.Player2, room);
                          frm.ShowDialog();
                      }
                       

                       
                   }
                }
            }
        }

        private void watchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //select RoomClient
            if (listRooms.SelectedItem != null)
            {
                var item = (RoomClient)listRooms.SelectedItem;
               item.typeOfUser = 1;
                item.WatcherID = UserInformation.ID;
                item.WatcherName = UserInformation.Name;
               UserInformation.ClientRoom = new System.Net.Sockets.TcpClient();
               UserInformation.ClientRoom.Connect(item.IpAddressString, item.PortIndex);
               Helper<RoomClient>.SendConvert(item, UserInformation.ClientRoom);

               Watchers frm = new Watchers(item);
               frm.ShowDialog();





            }

           


        }
    }
}

