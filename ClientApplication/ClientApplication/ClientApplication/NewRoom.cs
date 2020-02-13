using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerElemets;
using ClientApplication.Classes;
namespace ClientApplication
{
    public enum Category
    {
        Animals,
        Color,
        Fruits

    }

    public partial class NewRoom : Form
    {

        public Guid PlayerAdminID { get; set; }
        public string PlayerName { get; set; }
        public string RoomName { get; set; }

        public int Category { get; set; }
       
        public NewRoom(Guid id, string playerName)
        {
            InitializeComponent();

            PlayerAdminID = id;
            PlayerName = playerName;
    
            this.txtID.Text = PlayerAdminID.ToString();
            this.txtName.Text = PlayerName;
            this.txtNameOfRoom.Text = RoomName;

            comboCategory.DataSource = new List<Categories>()
            {
                new Categories(){ID =0, Name ="Aimal"},
                new Categories(){ID=1, Name ="Color"},
                new Categories(){ ID =2 , Name ="Fruits"}
            }; 
            comboCategory.ValueMember = "ID";
            comboCategory.DisplayMember = "Name";



        

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            PlayerAdminID = Guid.Parse(txtID.Text);
            PlayerName = txtName.Text;
            RoomName = txtNameOfRoom.Text;
            Category = (int)comboCategory.SelectedValue;
           


        }
    }
}
