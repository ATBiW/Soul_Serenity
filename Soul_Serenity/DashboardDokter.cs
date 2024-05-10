using Microsoft.VisualBasic;
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
    public partial class DashboardDokter : Form
    {
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private DataSet ds;
        private DataTable dt;
        private string imgLocation;

        HashPass Hp = new HashPass();

        Koneksi koneksi = new Koneksi();
        // Struktur data untuk menyimpan riwayat pesan
        private Dictionary<string, List<string>> messageHistory = new Dictionary<string, List<string>>();
        public DashboardDokter()
        {
            InitializeComponent();
        }


        private void DashboardDokter_Load(object sender, EventArgs e)
        {
            UserItem();
        }

        private void UserItem()
        {
            SqlConnection conn = koneksi.GetConn();
            try
            {
                conn.Open();
                flowLayoutPanel1.Controls.Clear();
                SqlDataAdapter adapter;
                adapter = new SqlDataAdapter("select * from tbl_user", conn);

                // Set ConnectionTimeout di SqlDataAdapter
                adapter.SelectCommand.CommandTimeout = 1000;

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            UserControlUser chatControl = new UserControlUser(); // Buat instansi dari UserControlUser di sini
                            MemoryStream stream = new MemoryStream((byte[])dt.Rows[i]["gambar"]); // Gunakan dt.Rows[i] untuk mengakses setiap baris
                            chatControl.Icon = new Bitmap(stream);
                            chatControl.Title = dt.Rows[i]["username"].ToString();
                            chatControl.Click += new System.EventHandler(this.userControlUser1_Load_1); // Tambahkan event handler di sini
                            if (chatControl.Title == labelUser.Text)
                            {
                                flowLayoutPanel1.Controls.Remove(chatControl);
                            }
                            else
                            {
                                flowLayoutPanel1.Controls.Add(chatControl);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }



        private void btnKonsultasi_Click(object sender, EventArgs e)
        {
            UserItem();
            panelKonsultasi.Visible = true;

        }

        private void btnKirim_Click(object sender, EventArgs e)
        {
            SqlConnection conn = koneksi.GetConn();
            try
            {
                conn.Open();
                string q = "INSERT INTO tbl_chat(userone, usertwo, message, role) VALUES (@userone, @usertwo, @message, @sender_role)";
                cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@userone", labelUser.Text);
                cmd.Parameters.AddWithValue("@usertwo", labelUserChat.Text);
                cmd.Parameters.AddWithValue("@message", textBoxMessage.Text);
                cmd.Parameters.AddWithValue("@sender_role", "dokter"); // Penanda peran pengirim sebagai dokter
                cmd.ExecuteNonQuery();

                // Simpan pesan ke dalam struktur data
                string recipient = labelUserChat.Text;
                string message = textBoxMessage.Text;

                if (!messageHistory.ContainsKey(recipient))
                {
                    messageHistory.Add(recipient, new List<string>());
                }

                messageHistory[recipient].Add(message);

                // Tampilkan pesan di antarmuka pengguna
                UserControlChat chatControl2 = new UserControlChat();
                chatControl2.Title = message;
                flowLayoutPanelChat.Controls.Add(chatControl2);

                textBoxMessage.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private DataTable GetChatData(string selectedUsername)
        {
            DataTable chatData = new DataTable();
            try
            {
                using (SqlConnection conn = koneksi.GetConn())
                {
                    conn.Open();
                    string query = "SELECT * FROM tbl_chat WHERE ((userone = @userone AND usertwo = @usertwo) OR (userone = @usertwo AND usertwo = @userone)) AND role = 'user'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userone", labelUser.Text);
                        cmd.Parameters.AddWithValue("@usertwo", selectedUsername);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(chatData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return chatData;
        }


        private void labelCloseChat_Click(object sender, EventArgs e)
        {
            if (panelTopChat.Visible == true && panelMessage.Visible == true && flowLayoutPanelChat.Visible == true)
            {
                panelTopChat.Visible = false;
                panelMessage.Visible = false;
                flowLayoutPanelChat.Visible = false;
            }
        }

        private void RefreshChat(string selectedUsername)
        {
            flowLayoutPanelChat.Controls.Clear();

            DataTable chatData = GetChatData(selectedUsername);

            if (chatData != null && chatData.Rows.Count > 0)
            {
                foreach (DataRow row in chatData.Rows)
                {
                    string message = row["message"].ToString();
                    UserControlChat2 chatControl = new UserControlChat2(); // Gunakan UserControlChat2 untuk dokter
                    chatControl.Title = message;
                    chatControl.Icon = pictureProfileUserChat.Image;
                    flowLayoutPanelChat.Controls.Add(chatControl);

                    // Simpan pesan dari UserChatControl2 ke dalam struktur data messageHistory
                    string sender = row["userone"].ToString(); // Pengirim pesan dari UserChatControl2
                    if (!messageHistory.ContainsKey(sender))
                    {
                        messageHistory.Add(sender, new List<string>());
                    }
                    messageHistory[sender].Add(message);
                }
            }
        }

        private void userControlUser1_Load_1(object sender, EventArgs e)
        {
            if (panelTopChat.Visible == false && panelMessage.Visible == false && flowLayoutPanelChat.Visible == false)
            {
                panelTopChat.Visible = true;
                panelMessage.Visible = true;
                flowLayoutPanelChat.Visible = true;
            }

            UserControlUser control = (UserControlUser)sender;
            labelUserChat.Text = control.Title;
            pictureProfileUserChat.Image = control.Icon;

            string recipient = control.Title;

            // Memeriksa apakah riwayat pesan sudah tersedia dalam struktur data messageHistory
            if (messageHistory.ContainsKey(recipient))
            {
                // Memuat riwayat pesan dari struktur data
                foreach (string message in messageHistory[recipient])
                {
                    UserControlChat chatControl = new UserControlChat();
                    chatControl.Title = message;
                    flowLayoutPanelChat.Controls.Add(chatControl);
                }
            }
            else
            {
                // Memuat riwayat pesan dari database jika belum tersedia dalam struktur data
                RefreshChat(recipient);
            }
        }
    }
}
