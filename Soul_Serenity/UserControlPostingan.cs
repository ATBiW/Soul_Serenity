using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soul_Serenity
{
    public partial class UserControlPostingan : UserControl
    {
        public UserControlPostingan()
        {
            InitializeComponent();
        }
        private string _user;
        private string _description;
        private Image _image;
        private Image _image2;
        private string _date;

        public string User { get { return _user; } set { _user = value; labelUserPost.Text = value; } }
        public string Description { get { return _description; } set { _description = value; labelDescriptionPost.Text = value; } }
        public Image Image { get { return _image; } set { _image = value; pcitureBoxPost.Image = value; } }
        public Image Image2 { get { return _image2; } set { _image2 = value; profilePost.Image = value; } }
        public string Date { get { return _date; } set { _date = value; labelTimePost.Text = value; } }

        private void UserControlPostingan_Load(object sender, EventArgs e)
        {

        }

        private void pcitureBoxPost_Click(object sender, EventArgs e)
        {

        }
    }
}
