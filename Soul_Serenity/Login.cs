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
    public partial class Login : Form
    {
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private DataSet ds;
        private DataTable dt;
        private string imgLocation;

        HashPass Hp = new HashPass();

        Koneksi koneksi = new Koneksi();
        public Login()
        {
            InitializeComponent();
        }

        private void labelRegistrasi_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register reg = new Register();
            reg.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            string role = GetRole(username, password);

            if (!string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Login Berhasil", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (role.Equals("user", StringComparison.OrdinalIgnoreCase))
                {
                    DashboardUser du = new DashboardUser();

                    du.panelDetailProfile.Visible = false;
                    du.panelKomunitas.Visible = false;
                    du.panelDashboard.Visible = true;
                    du.panelTeraphy.Visible = false;
                    du.panelNotebook.Visible = false;
                    du.panelAI.Visible = false;
                    du.labelDashboard.ForeColor = Color.FromArgb(79, 149, 208);

                    du.labelUsername.Text = username;
                    du.labelUsernameCard.Text = username;
                    du.labelUsernameCard2.Text = username;


                    string email = GetEmail(username);
                    du.labelEmail.Text = email;


                    du.labelPassword.Text = password;

                    byte[] userImageBytes = GetProfileImage(username, role);
                    if (userImageBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(userImageBytes))
                        {
                            du.pictureBoxProfile.Image = Image.FromStream(ms);
                            du.pictureBoxProfileCard.Image = Image.FromStream(ms);
                        }
                    }
                    du.Show();
                    this.Hide();
                }
                else if (role.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    DashboardAdmin da = new DashboardAdmin();
                    da.Show();
                }
                else if (role.Equals("dokter", StringComparison.OrdinalIgnoreCase))
                {
                    DashboardDokter dd = new DashboardDokter();
                    dd.panelDashboard.Visible = true;
                    dd.panelKonsultasi.Visible = false;
                    dd.labelUser.Text = username;
                    byte[] userImageBytes = GetProfileImage(username, role);
                    if (userImageBytes != null)
                    {
                        using (MemoryStream ms = new MemoryStream(userImageBytes))
                        {
                            dd.pictureBoxProfile.Image = Image.FromStream(ms);
                        }
                    }
                    dd.Show();
                }
            }
            else
            {
                MessageBox.Show("Username atau password salah.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetRole(string username, string password)
        {
            string role = null;

            using (SqlConnection connection = koneksi.GetConn())
            {
                connection.Open();

                // Query untuk mendapatkan peran user
                string userQuery = "SELECT role FROM tbl_user WHERE username = @username AND password = @password";
                using (SqlCommand userCmd = new SqlCommand(userQuery, connection))
                {
                    userCmd.CommandTimeout = 600;
                    userCmd.Parameters.AddWithValue("@username", username);
                    userCmd.Parameters.AddWithValue("@password", Hp.PassHash(password));
                    object userRole = userCmd.ExecuteScalar();
                    if (userRole != null)
                    {
                        role = userRole.ToString();
                    }
                }

                // Jika tidak ditemukan peran user, coba cari peran admin
                if (role == null)
                {
                    string adminQuery = "SELECT role FROM tbl_admin WHERE username = @username AND password = @password";
                    using (SqlCommand adminCmd = new SqlCommand(adminQuery, connection))
                    {
                        adminCmd.CommandTimeout = 600;
                        adminCmd.Parameters.AddWithValue("@username", username);
                        adminCmd.Parameters.AddWithValue("@password", password);
                        object adminRole = adminCmd.ExecuteScalar();
                        if (adminRole != null)
                        {
                            role = adminRole.ToString();
                        }
                    }
                }

                // Jika tidak ditemukan peran admin, coba cari peran dokter
                if (role == null)
                {
                    string dokterQuery = "SELECT role FROM tbl_dokter WHERE username = @username AND password = @password";
                    using (SqlCommand dokterCmd = new SqlCommand(dokterQuery, connection))
                    {
                        dokterCmd.CommandTimeout = 600;
                        dokterCmd.Parameters.AddWithValue("@username", username);
                        dokterCmd.Parameters.AddWithValue("@password", Hp.PassHash(password));
                        object dokterRole = dokterCmd.ExecuteScalar();
                        if (dokterRole != null)
                        {
                            role = dokterRole.ToString();
                        }
                    }
                }
            }
            return role;
        }

        private byte[] GetProfileImage(string username, string role)
        {
            byte[] imageBytes = null;

            using (SqlConnection connection = koneksi.GetConn())
            {
                connection.Open();

                string query = "";
                if (role == "admin")
                {
                    query = "SELECT gambar FROM tbl_admin WHERE username = @username";
                }
                else if (role == "dokter")
                {
                    query = "SELECT gambar FROM tbl_dokter WHERE username = @username";
                }
                else // default to user
                {
                    query = "SELECT gambar FROM tbl_user WHERE username = @username";
                }

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        imageBytes = (byte[])result;
                    }
                }
            }

            return imageBytes;
        }

        private string GetEmail(string username)
        {
            string email = null;

            using (SqlConnection connection = koneksi.GetConn())
            {
                connection.Open();

                string query = "SELECT email FROM tbl_user WHERE username = @username";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        email = result.ToString();
                    }
                }
            }

            return email;
        }
    }
}
