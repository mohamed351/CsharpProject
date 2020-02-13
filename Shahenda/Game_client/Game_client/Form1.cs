using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_client
{
    public partial class Form1 : Form
    {
        byte[] bt;
        IPAddress localAddr;
        int port;
        TcpClient client = new TcpClient();
        private NetworkStream nStream;
        string receivedMsg;
        List<Label> labelsChar = new List<Label>();
        int count = 0;


        public Form1()
        {
            InitializeComponent();
            bt = new byte[] { 127, 0, 0, 1 };
            localAddr = new IPAddress(bt);
            port = 1028;

        }

        protected override void OnLoad(EventArgs e)
        {
            AddKeyboard();
        }

        //function to generate keyboard buttons
        private void AddKeyboard()
        {
            for (int i = 65; i < 91; i++)
            {
                Button bn = new Button();
                bn.Text = ((char)i).ToString();
                bn.Parent = flowLayoutPanel1;
                bn.Size = new Size(40, 40);
                bn.Click += button_click;   
            }

        }

        private void button_click(object sender, EventArgs e) //letters click 
        {
            Button btn = (Button)sender;
            //MessageBox.Show(btn.Text);
            btn.Enabled = false;
            string clickedButton = btn.Text.ToLower();
            CheckLetter(clickedButton.ToCharArray()[0]);
        }      private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //connect with server
        {
            client.Connect(localAddr, port);

            nStream = client.GetStream();
            //sending category to server
            byte[] sendingMsg = Encoding.ASCII.GetBytes(comboBox1.Text);
            nStream.Write(sendingMsg, 0, sendingMsg.Length);
            comboBox1.Enabled = false;

            //receive random word from server
            byte[] dataBuffer = new byte[client.ReceiveBufferSize];
            int byteStreams = nStream.Read(dataBuffer, 0, dataBuffer.Length);
            receivedMsg = Encoding.ASCII.GetString(dataBuffer, 0, byteStreams);
            //MessageBox.Show(receivedMsg);
            AddDashLines(receivedMsg);

        }

        private void AddDashLines(string guessWord)
        {
            int width = groupBox1.Width / guessWord.Length;
            for (int i=0; i < guessWord.Length; i++)
            {
                Label lb = new Label();
                lb.Text = "_";
                lb.Parent = groupBox1;
                lb.Location = new Point(30 + i * width, groupBox1.Height - 35);
                lb.BringToFront();
                lb.AutoSize = true;
                labelsChar.Add(lb);
            }

        }

        private void CheckLetter(char letter)
        {
            char[] randomWordChar = receivedMsg.ToCharArray();

            if (receivedMsg.Contains(letter))
            {
                for (int i=0; i< receivedMsg.Length; i++)
                {
                    if(randomWordChar[i] == letter)
                    {
                        labelsChar[i].Text = letter.ToString().ToUpper();
                        count++;
                    }

                }

                if (count == receivedMsg.Length)
                {
                    DialogResult result = MessageBox.Show("Congratulation, you win!! \n Do you want to play again?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if(result == DialogResult.OK)
                    {
                        

                    }
                }

            }
            else
            {
                flowLayoutPanel1.Enabled = false;
                radioButton1.Checked = false;
                groupBox1.Enabled = false;
                
            }

        }


    }
}
