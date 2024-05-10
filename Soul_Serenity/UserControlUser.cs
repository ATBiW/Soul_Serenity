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
    public partial class UserControlUser : UserControl
    {
        public UserControlUser()
        {
            InitializeComponent();
        }

        private string _title;
        private Image _icon;

        private void textChat_Click(object sender, EventArgs e)
        {

        }

        public string Title { get { return _title; } set { _title = value; textChat.Text = value; } }
        public Image Icon { get { return _icon; } set { _icon = value; guna2CirclePictureBox1.Image = value; } }
    }
}
