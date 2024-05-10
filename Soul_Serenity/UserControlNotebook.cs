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
    public partial class UserControlNotebook : UserControl
    {
        public UserControlNotebook()
        {
            InitializeComponent();
        }

        private string _title;
        private string _description;
        private string _jenis;
        private string _tanggal;

        private void UserControlNotebook_Load(object sender, EventArgs e)
        {

        }

        public string Title { get { return _title; } set { _title = value; labelTitle.Text = value; } }
        public string Description { get { return _description; } set { _description = value; labelDescription.Text = value; } }
        public string Jenis { get { return _jenis; } set { _jenis = value; labelJenis.Text = value; } }
        public string Tanggal { get { return _tanggal; } set { _tanggal = value; labelTanggal.Text = value; } }


    }
}
