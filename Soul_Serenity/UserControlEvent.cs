using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class UserControlEvent : UserControl
    {
        public UserControlEvent()
        {
            InitializeComponent();
        }


        private string _title;
        private string _description;
        private string _lokasi;
        private string _harga;
        private Image _image;
        private string _tanggalMulai;
        private string _tanggalSelesai;
        private string _tempat;
        private string _kategori;

        private void UserControlEvent_Load(object sender, EventArgs e)
        {
        }

        private void labelTanggalMulaiEvent_Click(object sender, EventArgs e)
        {

        }

        public string Title { get { return _title; } set { _title = value; labelJudulEvent.Text = value; } }
        public string Description { get { return _description; } set { _description = value; labelDeskripsiEvent.Text = value; } }
        public string Lokasi { get { return _lokasi; } set { _lokasi = value; labelLokasiEvent.Text = value; } }
        public string Harga { get { return _harga; } set { _harga = value; labelHargaEvent.Text = value; } }
        public Image Image { get { return _image; } set { _image = value; gambarEvent.Image = value; } }
        public string Mulai { get { return _tanggalMulai; } set { _tanggalMulai = value; labelTanggalMulaiEvent.Text = value; } }
        public string Selesai { get { return _tanggalSelesai; } set { _tanggalSelesai = value; labelTanggalSelesaiEvent.Text = value; } }
        public string Tempat { get { return _tempat; } set { _tempat = value; labelLokasiEvent.Text = value; } }
        public string Kategori { get { return _kategori; } set { _kategori = value; labelKategori.Text = value; } }
    }
}
