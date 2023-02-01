using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject_v002.User_Controlers
{
    public partial class UC_Home : UserControl
    {
        public UC_Home()
        {
            InitializeComponent();
        }

        private void UC_Home_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int image = rand.Next(0, 2);
            if (image == 0) guna2PictureBox.Load("Images/woman-g71eeba979_1920.jpg");
            else guna2PictureBox.Load("Images/networks-g94003ad24_1920.jpg");
        }
    }
}
