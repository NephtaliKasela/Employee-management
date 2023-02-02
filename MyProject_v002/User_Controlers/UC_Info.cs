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
    public partial class UC_Info : UserControl
    {
        public UC_Info()
        {
            InitializeComponent();
        }

        private void UC_Info_Load(object sender, EventArgs e)
        {
            lblCreatorInfo.Text = "'STEFF Control' was created by NEPHTALI KASELA TSHINYENGO and he is from Congo DRC. Student at the university YKSUG (Yanka kupala State University of Grodno) in Belarus.";
            guna2cpicbxCreator.Load("Images/IMG_20221102_205710_307.jpg");
            guna2PicBxBacground.Load("Images/wp1867861.jpg");
            guna2cbtnWhatsApp.Image = Image.FromFile("Logos/whatsapp.png");
            guna2cbtnFacebook.Image = Image.FromFile("Logos/25187.png");
            guna2cbtnInstagram.Image = Image.FromFile("Logos/free-instagram-icon-2165-thumb.png");
            guna2cbtnTelegram.Image = Image.FromFile("Logos/telegram-icon-512x512-1s8w0tx0.png");
            guna2cbtnEmail.Image = Image.FromFile("Logos/email-icon-svg-15.jpg"); 
        }

        private void guna2cbtnWhatsApp_Click(object sender, EventArgs e)
        {
            guna2txtContact.Text = "+375 257256675";
        }

        private void guna2cbtnFacebook_Click(object sender, EventArgs e)
        {
            guna2txtContact.Text = "Nephtali nephtali kass";
        }

        private void guna2cbtnInstagram_Click(object sender, EventArgs e)
        {
            guna2txtContact.Text = "Nephtali Kas";
        }

        private void guna2cbtnTelegram_Click(object sender, EventArgs e)
        {
            guna2txtContact.Text = "+375 257256675";
        }

        private void guna2cbtnEmail_Click(object sender, EventArgs e)
        {
            guna2txtContact.Text = "nephtalikasela04@gmail.com"; 
        }
    }
}
