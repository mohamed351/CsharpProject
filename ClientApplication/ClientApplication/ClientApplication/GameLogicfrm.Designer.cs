namespace ClientApplication
{
    partial class GameLogicfrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.Player1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIpAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Player2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPort2 = new System.Windows.Forms.TextBox();
            this.txtIpAddress2 = new System.Windows.Forms.TextBox();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.txtID2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.customeKeyBoard1 = new CustomeKeyBoard.CustomeKeyBoard();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.Player1.SuspendLayout();
            this.Player2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID :";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(99, 38);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(244, 20);
            this.txtID.TabIndex = 1;
            // 
            // Player1
            // 
            this.Player1.Controls.Add(this.label4);
            this.Player1.Controls.Add(this.label3);
            this.Player1.Controls.Add(this.label2);
            this.Player1.Controls.Add(this.txtPort);
            this.Player1.Controls.Add(this.txtIpAddress);
            this.Player1.Controls.Add(this.txtName);
            this.Player1.Controls.Add(this.txtID);
            this.Player1.Controls.Add(this.label1);
            this.Player1.Location = new System.Drawing.Point(12, 12);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(451, 201);
            this.Player1.TabIndex = 2;
            this.Player1.TabStop = false;
            this.Player1.Text = "Player1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Port :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "IpAddress :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name : ";
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(99, 146);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(244, 20);
            this.txtPort.TabIndex = 1;
            // 
            // txtIpAddress
            // 
            this.txtIpAddress.Enabled = false;
            this.txtIpAddress.Location = new System.Drawing.Point(99, 111);
            this.txtIpAddress.Name = "txtIpAddress";
            this.txtIpAddress.Size = new System.Drawing.Size(244, 20);
            this.txtIpAddress.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(99, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(244, 20);
            this.txtName.TabIndex = 1;
            // 
            // Player2
            // 
            this.Player2.Controls.Add(this.label5);
            this.Player2.Controls.Add(this.label6);
            this.Player2.Controls.Add(this.label7);
            this.Player2.Controls.Add(this.txtPort2);
            this.Player2.Controls.Add(this.txtIpAddress2);
            this.Player2.Controls.Add(this.txtName2);
            this.Player2.Controls.Add(this.txtID2);
            this.Player2.Controls.Add(this.label8);
            this.Player2.Location = new System.Drawing.Point(482, 12);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(451, 201);
            this.Player2.TabIndex = 2;
            this.Player2.TabStop = false;
            this.Player2.Text = "Player2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Port :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "IpAddress :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(49, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Name : ";
            // 
            // txtPort2
            // 
            this.txtPort2.Enabled = false;
            this.txtPort2.Location = new System.Drawing.Point(99, 146);
            this.txtPort2.Name = "txtPort2";
            this.txtPort2.Size = new System.Drawing.Size(244, 20);
            this.txtPort2.TabIndex = 1;
            // 
            // txtIpAddress2
            // 
            this.txtIpAddress2.Enabled = false;
            this.txtIpAddress2.Location = new System.Drawing.Point(99, 111);
            this.txtIpAddress2.Name = "txtIpAddress2";
            this.txtIpAddress2.Size = new System.Drawing.Size(244, 20);
            this.txtIpAddress2.TabIndex = 1;
            // 
            // txtName2
            // 
            this.txtName2.Enabled = false;
            this.txtName2.Location = new System.Drawing.Point(99, 75);
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(244, 20);
            this.txtName2.TabIndex = 1;
            // 
            // txtID2
            // 
            this.txtID2.Enabled = false;
            this.txtID2.Location = new System.Drawing.Point(99, 38);
            this.txtID2.Name = "txtID2";
            this.txtID2.Size = new System.Drawing.Size(244, 20);
            this.txtID2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(69, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "ID :";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // customeKeyBoard1
            // 
            this.customeKeyBoard1.Dimit = true;
            this.customeKeyBoard1.Location = new System.Drawing.Point(48, 407);
            this.customeKeyBoard1.Name = "customeKeyBoard1";
            this.customeKeyBoard1.Size = new System.Drawing.Size(907, 155);
            this.customeKeyBoard1.TabIndex = 4;
            this.customeKeyBoard1.OnButtonClick += new CustomeKeyBoard.HandleKeyBoard(this.customeKeyBoard1_OnButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(320, 271);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 101);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Guess The Word";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 29);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(434, 51);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(141, 240);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // GameLogicfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 608);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customeKeyBoard1);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Name = "GameLogicfrm";
            this.Text = "GameLogicfrm";
            this.Load += new System.EventHandler(this.GameLogicfrm_Load);
            this.Player1.ResumeLayout(false);
            this.Player1.PerformLayout();
            this.Player2.ResumeLayout(false);
            this.Player2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.GroupBox Player1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIpAddress;
        private System.Windows.Forms.GroupBox Player2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPort2;
        private System.Windows.Forms.TextBox txtIpAddress2;
        private System.Windows.Forms.TextBox txtName2;
        private System.Windows.Forms.TextBox txtID2;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CustomeKeyBoard.CustomeKeyBoard customeKeyBoard1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}