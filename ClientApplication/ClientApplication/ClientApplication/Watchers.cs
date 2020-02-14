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
            
            InitializeComponent();
            backgroundWorker1.RunWorkerAsync();

        }
        string receivedMsg = "";
        List<Label> labelsChar = new List<Label>();
        int count = 0;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
               string message =  Helper.ReciveConvert(UserInformation.ClientRoom.Client);
               textBox1.Text += message +"\n";
               if (message.Contains(":"))
               {
                   string[] s = message.Split(':');
                   Player.Text = s[0];
               }
               else
               {

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
    }
}
