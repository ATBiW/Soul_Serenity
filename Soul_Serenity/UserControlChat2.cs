using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soul_Serenity
{
    public partial class UserControlChat2 : UserControl
    {
        public UserControlChat2()
        {
            InitializeComponent();
        }

        private string _title;
        private Image _icon;

        public string Title { get { return _title; } set { _title = value; labelChat2.Text = value; } }
        public Image Icon { get { return _icon; } set { _icon = value; pictureBoxProfileChat.Image = value; AddHeightText(); } }

        private void UserControlChat2_Load(object sender, EventArgs e)
        {
            AddHeightText();
        }

        void AddHeightText()
        {
            UserControlChat user = new UserControlChat();
            user.BringToFront();
            labelChat2.Height = Uilist.GetTextHeight(labelChat2) + 10;
            user.Height = labelChat2.Top + labelChat2.Height;
            this.Height = user.Bottom + 10;
        }

        private void labelChat2_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
