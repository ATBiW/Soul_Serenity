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
    public partial class UserControlChat : UserControl
    {
        public UserControlChat()
        {
            InitializeComponent();
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; labelChat.Text = value; AddHeightText(); }
        }

        void AddHeightText()
        {
            UserControlChat user = new UserControlChat();
            user.BringToFront();
            labelChat.Height = Uilist.GetTextHeight(labelChat) + 10;
            user.Height = labelChat.Top + labelChat.Height;
            this.Height = user.Bottom + 10;
        }

        private void UserControlChat_Load(object sender, EventArgs e)
        {
            AddHeightText();
        }
    }
}
