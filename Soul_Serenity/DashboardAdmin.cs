using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soul_Serenity
{
    public partial class DashboardAdmin : Form
    {
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private DataSet ds;
        private DataTable dt;
        private byte[] selectedImageBytes;

        Koneksi koneksi = new Koneksi();
        HashPass Hp = new HashPass();

        public DashboardAdmin()
        {
            InitializeComponent();
        }

        void displayDokter()
        {
            SqlConnection conn = koneksi.GetConn();
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from tbl_dokter";
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewDokter.DataSource = dt;
            conn.Close();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUsername.Text) || string.IsNullOrEmpty(textBoxPassword.Text) || string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxKonfirmasi.Text))
            {
                MessageBox.Show("Peringatan", "Harap isi semua kolom!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBoxPassword.Text == textBoxKonfirmasi.Text)
                {
                    using (SqlConnection conn = koneksi.GetConn())
                    {
                        conn.Open();

                        // Periksa apakah username sudah digunakan
                        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM tbl_dokter WHERE username = @username", conn);
                        cmd.Parameters.AddWithValue("@username", textBoxUsername.Text);
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Peringatan", "Username Sudah Digunakan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            // Insert data user ke dalam database
                            cmd = new SqlCommand("INSERT INTO tbl_dokter (username, email, password, gambar, role) VALUES (@username, @email, @password, @gambar, @role)", conn);
                            cmd.Parameters.AddWithValue("@username", textBoxUsername.Text);
                            cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                            cmd.Parameters.AddWithValue("@password", Hp.PassHash(textBoxPassword.Text));
                            cmd.Parameters.AddWithValue("@gambar", selectedImageBytes); // Gunakan byte array gambar yang dipilih
                            cmd.Parameters.AddWithValue("@role", textBoxRoleDokter.Text);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Berhasil", "Akun Berhasil Terbuat!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            displayDokter();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Gagal", "Konfirmasi Password Anda Salah", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCariGambar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                // Baca file gambar ke dalam byte array
                selectedImageBytes = File.ReadAllBytes(imagePath);

                // Tampilkan gambar di pictureBox1
                pictureBoxDokter.Image = Image.FromFile(imagePath);
            }
        }

        private void DashboardAdmin_Load(object sender, EventArgs e)
        {
            displayDokter();
        }

        private void dataGridViewDokter_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewDokter.SelectedRows.Count > 0)
            {
                DataGridViewRow dgv = dataGridViewDokter.SelectedRows[0];
                textBoxUsername.Text = dgv.Cells["username"].Value.ToString();
                textBoxEmail.Text = dgv.Cells["email"].Value.ToString();
                textBoxPassword.Text = dgv.Cells["password"].Value.ToString();
                textBoxRoleDokter.Text = dgv.Cells["role"].Value.ToString();

                // Periksa apakah nilai gambar adalah DBNull sebelum mengambilnya
                object imageData = dgv.Cells["gambar"].Value;
                if (imageData != DBNull.Value)
                {
                    byte[] byteData = (byte[])imageData;
                    if (byteData != null && byteData.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(byteData))
                        {
                            pictureBoxDokter.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pictureBoxDokter.Image = null;
                    }
                }
                else
                {
                    pictureBoxDokter.Image = null; // Nilai default jika gambar adalah DBNull
                }
            }
        }
    }
}
