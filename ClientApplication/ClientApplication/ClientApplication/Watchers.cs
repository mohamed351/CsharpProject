using ClientApplication.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApplication
{
    public partial class Watchers : Form
    {
        public Watchers(RoomClient client)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
           
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();

            //txtID1.Text = client.Player1ID.ToString();
            //txtID2.Text = client.Player2ID.ToString();
            //txtName1.Text = client.PlayerName1;
            //txtName2.Text = client.PlayerName2;


        }
        string receivedMsg = "";
        List<Label> labelsChar = new List<Label>();
        int count = 0;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                WatcherClient message = Helper<WatcherClient>.ReciveConvert(UserInformation.ClientRoom);
             
                if (string.IsNullOrWhiteSpace(receivedMsg))
                {
                    receivedMsg = message.Word;
                    AddDashLines(receivedMsg);
                    CheckLetter(message.Key);
                    Player.Text = message.PlayerName;
                    foreach (var item in message.history)
                    {
                        CheckLetter(item);

                    }
                    
                }
                else
                {
                    CheckLetter(message.Key);

                }
              


                
            }
        }

        private void  CheckLetter(char letter)
        {
            char[] randomWordChar = receivedMsg.ToCharArray();
          
            if (receivedMsg.Contains(letter.ToString().ToLower()))
            {
                Helper.SendConvert(letter.ToString(), UserInformation.ClientRoom.Client);
                for (int i = 0; i < receivedMsg.Length; i++)
                {
                    if (randomWordChar[i] == Convert.ToChar(letter.ToString().ToLower()))
                    {
                        labelsChar[i].Text = letter.ToString().ToUpper();
                        count++;
                    }

                }



                if (count == receivedMsg.Length)
                {
                    bool flag = true;
                    foreach (Label item in flowLayoutPanel1.Controls)
                    {
                        if (item.Text == "_")
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {

                        
                    }
                }
             

            }
            else
            {
              
          
              
            }

           

        }

        private void AddDashLines(string guessWord)
        {

         
            for (int i = 0; i < guessWord.Length; i++)
            {


                flowLayoutPanel1.Invoke(new MethodInvoker(() =>
                {
                    Label lb = new Label();
                    lb.Text = "_";
                    flowLayoutPanel1.Controls.Add(lb);
              
                    lb.BringToFront();
                    lb.AutoSize = true;
                    labelsChar.Add(lb);
                }));
            }
        }
    }
}
