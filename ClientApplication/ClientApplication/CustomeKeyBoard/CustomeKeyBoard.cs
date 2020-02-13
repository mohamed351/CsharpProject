using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomeKeyBoard
{
    public delegate void HandleKeyBoard(Button btn,CustomeKeyBoard custome, char key);
    public class CustomeKeyBoard:UserControl
    {
        bool _dimit;
        /// <summary>
        /// This is Property Used to Enable and disabled the Buttons
        /// if dimit is true the Controls will be enabled and if disabled  
        ///it will be false
        /// </summary>
        public bool Dimit
        {
            get { return _dimit; }
            set
            {
                if (value == true)
                {
                    foreach (Button item in flowLayoutPanel1.Controls)
                    {
                        item.Enabled = true;
                    }
                    _dimit = value;
                }
                else
                {
                    foreach (Button item in flowLayoutPanel1.Controls)
                    {
                        item.Enabled = false;
                    }
                    _dimit = value;

                }
            }
        }

        private FlowLayoutPanel flowLayoutPanel1;

        public CustomeKeyBoard()
        {
         
            InitializeComponent();
            Design();
            _dimit = true;
        }
        public event HandleKeyBoard OnButtonClick;
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(527, 244);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // CustomControl
            // 
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "CustomControl";
            this.Size = new System.Drawing.Size(527, 244);
            this.ResumeLayout(false);

        }
        private void Design()
        {

            for (int i = 65; i < 91; i++)
            {
                Button btn = new Button();
                btn.Size = new System.Drawing.Size(50, 50);
                btn.Name = "btn"+((char)i).ToString();
                btn.Text = ((char)i).ToString();
                btn.Enabled = true;
                btn.Click += (a, b) =>
                {
                    if (OnButtonClick != null)
                    {
                        OnButtonClick(btn, this, ((char)i));

                    }
                };
                flowLayoutPanel1.Controls.Add(btn);

            }
        }
    }
}
