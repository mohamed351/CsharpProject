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
using System.Net;
using ClientApplication.Classes;
namespace ClientApplication
{
    public enum TypeOfPlayer
    {
        Player1,
        Player2,
        Watcher
    }

    
    public partial class GameLogicfrm : Form
    {
      
        string receivedMsg;
    
        List<Label> labelsChar = new List<Label>();
        int count = 0;
        public TypeOfPlayer PlayerType { get; set; }
        public GameLogicfrm(TypeOfPlayer typeofplayer)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            PlayerType = typeofplayer;
            InitializeComponent();
            if (typeofplayer == TypeOfPlayer.Player1)
            {
                txtID.Text = UserInformation.ID.ToString();
                txtName.Text = UserInformation.Name;
                IPEndPoint point = (IPEndPoint)UserInformation.ClientRoom.Client.LocalEndPoint;
                txtIpAddress.Text = point.Address.ToString();
                txtPort.Text = point.Port.ToString();
            }
            else
            {
                txtID2.Text = UserInformation.ID.ToString();
                txtName2.Text = UserInformation.Name;
                IPEndPoint point = (IPEndPoint)UserInformation.ClientRoom.Client.LocalEndPoint;
                txtIpAddress2.Text= point.Address.ToString();
                txtPort2.Text = point.Port.ToString();

            }
   
            backgroundWorker1.RunWorkerAsync();

            
           
        }

        public GameLogicfrm(TypeOfPlayer typeofplayer , RoomClient client)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.PlayerType = typeofplayer;
            InitializeComponent();
            if (typeofplayer == TypeOfPlayer.Player2)
            {
                txtID2.Text = UserInformation.ID.ToString();
                txtName2.Text = UserInformation.Name;
                IPEndPoint point = (IPEndPoint)UserInformation.ClientRoom.Client.LocalEndPoint;
                txtIpAddress2.Text = point.Address.ToString();
                txtPort2.Text = point.Port.ToString();


                txtID.Text = client.Player1ID.ToString();
                txtName.Text = client.PlayerName1;
                txtIpAddress.Text = client.IpAddressString;
                txtPort.Text = client.PortIndex.ToString();


            }
            if (PlayerType == TypeOfPlayer.Player2)
            {
                this.customeKeyBoard1.Dimit = false;
            }
            backgroundWorker1.RunWorkerAsync();

        }

        private void GameLogicfrm_Load(object sender, EventArgs e)
        {
            if (PlayerType == TypeOfPlayer.Player2)
            {

                this.customeKeyBoard1.Dimit = false;     
              
            }
                 
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (PlayerType == TypeOfPlayer.Player1)
            {
                string message = Helper.ReciveConvert(UserInformation.ClientRoom.Client);

                DialogResult result = MessageBox.Show(message, "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                Helper.SendConvert(((int)result).ToString(), UserInformation.ClientRoom.Client);

                MessageBox.Show("Game Start ...");
               
                 
                    string keyboard = Helper.ReciveConvert(UserInformation.ClientRoom.Client);
                    keyboard = keyboard.Replace("\0", string.Empty);
                    receivedMsg = keyboard;
                    AddDashLines(keyboard);
                
             

           


            }
            else
            {
                MessageBox.Show("Game Start ...");
                string keyboard = Helper.ReciveConvert(UserInformation.ClientRoom.Client);
                MessageBox.Show(keyboard);
                keyboard = keyboard.Replace("\0", string.Empty);
                receivedMsg = keyboard;
                AddDashLines(keyboard);
                Task.Run(() =>
                {
                      string message="";
                      do
                      {

                         
                          message = Helper.ReciveConvert(UserInformation.ClientRoom.Client);
                          message = message.Replace("\0", string.Empty);
                          if (message.Length <= 1)
                          {
                              if (message != "false")
                              {
                                  receivedMsg = keyboard;
                                  CheckLetter(char.Parse(message));
                              }
                          }

                      } while (message != "false");

                      if (message == "false")
                      {
                          this.customeKeyBoard1.Dimit = true;
                      }
                });

             
             
               

                
            }

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Helper.SendConvert("A", UserInformation.ClientRoom.Client);


        }


        private void AddDashLines(string guessWord)
        {
            
            int width = groupBox1.Width / guessWord.Length;
            for (int i = 0; i < guessWord.Length; i++)
            {
                
               
                flowLayoutPanel1 .Invoke(new MethodInvoker(() =>
                {
                    Label lb = new Label();
                    lb.Text = "_";
                    flowLayoutPanel1.Controls.Add(lb);
                    lb.Location = new Point(30 + width * 20, groupBox1.Height - 35);
                    lb.BringToFront();
                    lb.AutoSize = true;
                    labelsChar.Add(lb);
                }));
            }
        }

        private void customeKeyBoard1_OnButtonClick(Button btn, CustomeKeyBoard.CustomeKeyBoard custome, char key)
        {
            try
            {
                if (!string.IsNullOrEmpty(receivedMsg))
                {


                    bool iswordTrue = CheckLetter(char.Parse(btn.Text));
                    if (!iswordTrue)
                    {
                        backgroundWorker2.RunWorkerAsync();
                    }


                }
                else
                {
                    MessageBox.Show("The Game didn't start you are waiting a new User", "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

            }

        }

        private char KnowTheWord(Button btn)
        {
            int index = receivedMsg.ToUpper().IndexOf(btn.Text);
            char ch = receivedMsg[index];
            receivedMsg.Remove(index);
            flowLayoutPanel1.Controls[index].Text = ch.ToString();
            return ch;
        }

        private void KnowTheWord(char btn)
        {
            int index = receivedMsg.IndexOf(btn);
            char ch = receivedMsg[index];
            receivedMsg.Remove(index);
            flowLayoutPanel1.Controls[index].Text = ch.ToString();
            
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (true)
                {
                    string message = Helper.ReciveConvert(UserInformation.ClientRoom.Client);
                    message = message.Replace("\0", string.Empty);
                    if (message != "false")
                    {
                        if (message.Length <= 1)
                        {
                            CheckLetter(char.Parse(message));
                        }
                    }
                    else
                    {
                        this.customeKeyBoard1.Dimit = true;
                    }
                }
            }
            catch
            {

            }
        }


        private bool CheckLetter(char letter)
        {
            char[] randomWordChar = receivedMsg.ToCharArray();
            bool isTrueOrFalse;
            if (receivedMsg.Contains(letter.ToString().ToLower()))
            {
                Helper.SendConvert(letter.ToString(), UserInformation.ClientRoom.Client);
                for (int i = 0; i < receivedMsg.Length; i++)
                {
                    if (randomWordChar[i] == Convert.ToChar( letter.ToString().ToLower()))
                    {
                        labelsChar[i].Text = letter.ToString().ToUpper();
                        count++;
                    }

                }



                if (count == receivedMsg.Length)
                {
                    bool flag =true;
               foreach (Label item in flowLayoutPanel1.Controls)
	           {
                   if (item.Text == "_")
                   {
                       flag = false;
                   }
	            }
               if (flag)
               {

                   DialogResult result = MessageBox.Show("Congratulation, you win!! \n Do you want to play again?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                   if (result == DialogResult.OK)
                   {

                      
                   }
                }
               }
                isTrueOrFalse = true;

            }
            else
            {
                //flowLayoutPanel1.Enabled = false;
                //radioButton1.Checked = false;
                //groupBox1.Enabled = false;
                customeKeyBoard1.Dimit = false;
                Helper.SendConvert("false", UserInformation.ClientRoom.Client);
                isTrueOrFalse = false;
            }

            return isTrueOrFalse;

        }
       

     


    }
}
