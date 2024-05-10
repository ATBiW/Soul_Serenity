using System;
using System.Data.SqlClient;
using System.Data;
using Utilities.BunifuCheckBox.Transitions;
using System.Timers;
using System.Windows.Forms;
using System.Media;

namespace Soul_Serenity
{
    public partial class DashboardUser : Form
    {
        Koneksi koneksi = new Koneksi();

        private SqlCommand cmd;
        private string imgLocation;
        //NOTIFICATION

        int h, m, s;
        int toastCounter = 0;
        string[] randomMessages = { "Ini adalah pesan acak 1", "Ini adalah pesan acak 2", "Ini adalah pesan acak 3", "Ini adalah pesan acak 4" };

        private void UpdateLabelsMoodPercentageAndTopMoodAndWords()
        {
            string countQuery = @"
        SELECT mood, COUNT(*) AS count
        FROM MoodTracker
        GROUP BY mood";

            using (SqlConnection connection = koneksi.GetConn())
            {
                connection.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(countQuery, connection))
                {
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);

                    var moodCounts = dataset.Tables[0].AsEnumerable().ToDictionary(row => row.Field<string>("mood"), row => row.Field<int>("count"));

                    // Jika tidak ada entri di tabel
                    if (moodCounts.Count == 0)
                    {
                        lblBad.Text = "0%";
                        lblGood.Text = "0%";
                        lblVeryG.Text = "0%";
                        lblTopMood.Text = "No data";
                        lblKata.Text = "No data";
                        return;
                    }

                    var topMood = moodCounts.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

                    lblTopMood.Text = topMood;

                    string topMoodWords = GetWordsForMood(topMood);

                    lblKata.Text = topMoodWords;

                    int totalEntries = moodCounts.Values.Sum();

                    double badPercentage = moodCounts.ContainsKey("Bad") ? (double)moodCounts["Bad"] / totalEntries * 100 : 0;
                    double goodPercentage = moodCounts.ContainsKey("Good") ? (double)moodCounts["Good"] / totalEntries * 100 : 0;
                    double veryGoodPercentage = moodCounts.ContainsKey("Very Good") ? (double)moodCounts["Very Good"] / totalEntries * 100 : 0;

                    // Menampilkan persentase masing-masing mood di label-label
                    lblBad.Text = $"{badPercentage:F2}%";
                    lblGood.Text = $"{goodPercentage:F2}%";
                    lblVeryG.Text = $"{veryGoodPercentage:F2}%";
                }
            }
        }

        private string GetWordsForMood(string mood)
        {
            switch (mood)
            {
                case "Bad":
                    return "Dalam satu minggu ini kamu sedang sering sedih";
                case "Good":
                    return "Dalam satu minggu ini kamu merasa bahagia";
                case "Very Good":
                    return "Dalam satu minggu ini kamu merasa sangat bahagia";
                default:
                    return "Tidak ada kata-kata yang sesuai";
            }
        }

        private void InsertMood(string mood)
        {
            // Tanggal sekarang
            string tanggal = DateTime.Now.ToString("yyyy-MM-dd");

            // Memeriksa apakah entri dengan tanggal yang sama sudah ada
            if (EntryExistsForDate(tanggal))
            {
                MessageBox.Show("Anda hanya bisa memasukkan mood sekali sehari.");
                return;
            }

            // Query SQL untuk menyisipkan data
            string insertQuery = $"INSERT INTO MoodTracker (tanggal, mood) VALUES ('{tanggal}', '{mood}')";

            // Membuat koneksi
            using (SqlConnection connection = koneksi.GetConn())
            {
                // Membuka koneksi
                connection.Open();

                // Membuat perintah SQL
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // Menjalankan perintah SQL
                    int rowsAffected = command.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} baris telah disisipkan ke dalam tabel MoodTracker!");
                }
            }
        }

        private bool EntryExistsForDate(string date)
        {
            // Query SQL untuk memeriksa apakah entri dengan tanggal yang sama sudah ada
            string checkQuery = $"SELECT COUNT(*) FROM MoodTracker WHERE tanggal = '{date}'";

            // Membuat koneksi
            using (SqlConnection connection = koneksi.GetConn())
            {
                // Membuka koneksi
                connection.Open();

                // Membuat perintah SQL
                using (SqlCommand command = new SqlCommand(checkQuery, connection))
                {
                    // Menjalankan perintah SQL dan mengambil jumlah entri
                    int count = (int)command.ExecuteScalar();

                    // Jika jumlah entri lebih dari 0, berarti entri dengan tanggal yang sama sudah ada
                    return count > 0;
                }
            }
        }

        private void UpdateLabelMood()
        {
            // Query SQL untuk menghitung jumlah masing-masing mood
            string countQuery = @"
                SELECT mood, COUNT(*) AS count
                FROM MoodTracker
                GROUP BY mood";

            // Membuat koneksi
            using (SqlConnection connection = koneksi.GetConn())
            {
                // Membuka koneksi
                connection.Open();

                // Membuat adapter dan dataset
                using (SqlDataAdapter adapter = new SqlDataAdapter(countQuery, connection))
                {
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);

                    // Mengubah hasil query menjadi dictionary
                    var moodCounts = dataset.Tables[0].AsEnumerable()
                        .ToDictionary(row => row.Field<string>("mood"), row => row.Field<int>("count"));

                    // Jika tidak ada entri di tabel
                    if (moodCounts.Count == 0)
                    {
                        lblMood.Text = "Belum ada data";
                        return;
                    }

                    // Menghitung total entri
                    int totalEntries = moodCounts.Values.Sum();

                    // Mencari mood dengan persentase terbesar
                    var largestMood = moodCounts.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

                    // Menghitung persentase mood terbesar
                    double largestPercentage = (double)moodCounts[largestMood] / totalEntries * 100;

                    // Menampilkan mood dengan persentase terbesar di label
                    lblMood.Text = $"{largestPercentage:F2}%";
                }
            }

        }

        private void UpdateLabelsMoodPercentageAndTopMood()
        {
            // Query SQL untuk menghitung jumlah masing-masing mood
            string countQuery = @"
        SELECT mood, COUNT(*) AS count
        FROM MoodTracker
        GROUP BY mood";

            // Membuat koneksi
            using (SqlConnection connection = koneksi.GetConn())
            {
                // Membuka koneksi
                connection.Open();

                // Membuat adapter dan dataset
                using (SqlDataAdapter adapter = new SqlDataAdapter(countQuery, connection))
                {
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);

                    // Mengubah hasil query menjadi dictionary
                    var moodCounts = dataset.Tables[0].AsEnumerable().ToDictionary(row => row.Field<string>("mood"), row => row.Field<int>("count"));

                    // Jika tidak ada entri di tabel
                    if (moodCounts.Count == 0)
                    {
                        lblBad.Text = "0%";
                        lblGood.Text = "0%";
                        lblVeryG.Text = "0%";
                        lblTopMood.Text = "No data";
                        return;
                    }

                    // Menghitung nama mood dengan jumlah terbanyak
                    var topMood = moodCounts.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

                    // Menampilkan nama mood dengan jumlah terbanyak di label lblTopMood
                    if (topMood == "Bad")
                    {
                        lblTopMood.Text = "Sedih";
                    }
                    else if (topMood == "Good")
                    {
                        lblTopMood.Text = "Normal";
                    }
                    else
                    {
                        lblTopMood.Text = "Sangat Senang";
                    }

                    // Menghitung total entri
                    int totalEntries = moodCounts.Values.Sum();

                    // Menghitung persentase masing-masing mood
                    double badPercentage = moodCounts.ContainsKey("Bad") ? (double)moodCounts["Bad"] / totalEntries * 100 : 0;
                    double goodPercentage = moodCounts.ContainsKey("Good") ? (double)moodCounts["Good"] / totalEntries * 100 : 0;
                    double veryGoodPercentage = moodCounts.ContainsKey("Very Good") ? (double)moodCounts["Very Good"] / totalEntries * 100 : 0;

                    // Menampilkan persentase masing-masing mood di label-label
                    lblBad.Text = $"{badPercentage:F2}%";
                    lblGood.Text = $"{goodPercentage:F2}%";
                    lblVeryG.Text = $"{veryGoodPercentage:F2}%";
                }
            }
        }
        private void CheckAndResetData()
        {
            // Query SQL untuk menghitung jumlah entri dalam tabel
            string countEntriesQuery = "SELECT COUNT(*) FROM MoodTracker";

            // Membuat koneksi
            using (SqlConnection connection = koneksi.GetConn())
            {
                // Membuka koneksi
                connection.Open();

                // Membuat perintah SQL
                using (SqlCommand command = new SqlCommand(countEntriesQuery, connection))
                {
                    // Menjalankan perintah SQL dan mengambil jumlah entri
                    int countEntries = (int)command.ExecuteScalar();

                    // Jika jumlah entri melebihi 7 (satu minggu)
                    if (countEntries > 7)
                    {
                        // Mengurutkan entri berdasarkan tanggal secara menaik
                        string deleteQuery = @"
                            DELETE FROM MoodTracker
                            WHERE ID IN (
                                SELECT TOP (@countToDelete) ID
                                FROM MoodTracker
                                ORDER BY tanggal ASC
                            )";

                        // Membuat perintah SQL untuk menghapus entri-entri tertua
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                            // Menentukan jumlah entri yang akan dihapus (total entri - 7)
                            int countToDelete = countEntries - 7;
                            deleteCommand.Parameters.AddWithValue("@countToDelete", countToDelete);

                            // Menjalankan perintah SQL untuk menghapus entri-entri tertua
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void UpdateLabelsMoodPercentage()
        {
            // Query SQL untuk menghitung jumlah masing-masing mood
            string countQuery = @"
                SELECT mood, COUNT(*) AS count
                FROM MoodTracker
                GROUP BY mood";

            // Membuat koneksi
            using (SqlConnection connection = koneksi.GetConn())
            {
                // Membuka koneksi
                connection.Open();

                // Membuat adapter dan dataset
                using (SqlDataAdapter adapter = new SqlDataAdapter(countQuery, connection))
                {
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);

                    // Mengubah hasil query menjadi dictionary
                    var moodCounts = dataset.Tables[0].AsEnumerable()
                        .ToDictionary(row => row.Field<string>("mood"), row => row.Field<int>("count"));

                    // Jika tidak ada entri di tabel
                    if (moodCounts.Count == 0)
                    {
                        lblBad.Text = "0%";
                        lblGood.Text = "0%";
                        lblVeryG.Text = "0%";
                        return;
                    }

                    // Menghitung total entri
                    int totalEntries = moodCounts.Values.Sum();

                    // Menghitung persentase masing-masing mood
                    double badPercentage = moodCounts.ContainsKey("Bad") ? (double)moodCounts["Bad"] / totalEntries * 100 : 0;
                    double goodPercentage = moodCounts.ContainsKey("Good") ? (double)moodCounts["Good"] / totalEntries * 100 : 0;
                    double veryGoodPercentage = moodCounts.ContainsKey("Very Good") ? (double)moodCounts["Very Good"] / totalEntries * 100 : 0;

                    // Menampilkan persentase masing-masing mood di label-label
                    lblBad.Text = $"{badPercentage:F2}%";
                    lblGood.Text = $"{goodPercentage:F2}%";
                    lblVeryG.Text = $"{veryGoodPercentage:F2}%";
                }
            }
        }


        private void ShowToast(string type, string message)
        {
            ToastForms toast = new ToastForms(type, message);
            toast.Show();
        }

        private void OnTimeEvent(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                s += 1;
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }

                toastCounter++;

                if (toastCounter == 7200)
                {
                    Random rnd = new Random();
                    int index = rnd.Next(randomMessages.Length);
                    string randomMessage = randomMessages[index];

                    ShowToast("Daily Reminder", randomMessage);
                    toastCounter = 0;
                    SoundPlayer player = new SoundPlayer(Properties.Resources.mixkit_software_interface_start_2574);
                    player.Stop();
                    player.Play();
                }

                if (h == 2)
                {
                    h = 0;
                    m = 0;
                    s = 0;
                }
            }));
        }

        //NOTIFICATION
        HashPass Hp = new HashPass();

        public DashboardUser()
        {
            InitializeComponent();
        }

        private void btnProfile_Paint(object sender, PaintEventArgs e)
        {
            panelAI.Visible = false;
            panelDetailProfile.Visible = true;
            panelKomunitas.Visible = false;
            panelDashboard.Visible = false;
            panelKonsultasi.Visible = false;
            panelTeraphy.Visible = false;
            panelNotebook.Visible = false;
            panelAI.Visible = false;
        }

        private void iconSetting_Click(object sender, EventArgs e)
        {
            panelAI.Visible = false;
            panelDetailProfile.Visible = true;
            panelKomunitas.Visible = false;
            panelDashboard.Visible = false;
            panelKonsultasi.Visible = false;
            panelTeraphy.Visible = false;
            panelNotebook.Visible = false;
            panelAI.Visible = false;
            labelSetting.ForeColor = Color.FromArgb(79, 149, 208);
            labelKonsultasi.ForeColor = Color.Black;
        }

        private void labelSetting_Click(object sender, EventArgs e)
        {
            panelAI.Visible = false;
            panelDetailProfile.Visible = true;
            panelKomunitas.Visible = false;
            panelDashboard.Visible = false;
            panelKonsultasi.Visible = false;
            panelTeraphy.Visible = false;
            panelNotebook.Visible = false;
            panelAI.Visible = false;
            labelSetting.ForeColor = Color.FromArgb(79, 149, 208);
            labelKonsultasi.ForeColor = Color.Black;
            labelCatatan.ForeColor = Color.White;
            labelDashboard.ForeColor = Color.Black;
        }

        private void labelDashboard_Click(object sender, EventArgs e)
        {
            panelAI.Visible = false;
            panelDetailProfile.Visible = false;
            panelKomunitas.Visible = false;
            panelDashboard.Visible = true;
            panelKonsultasi.Visible = false;
            panelTeraphy.Visible = false;
            panelNotebook.Visible = false;
            panelAI.Visible = false;
            labelDashboard.ForeColor = Color.FromArgb(79, 149, 208);
            labelSetting.ForeColor = Color.White;
            labelCatatan.ForeColor = Color.White;
            labelKonsultasi.ForeColor = Color.White;
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            UpdateProfile up = new UpdateProfile();
            up.DashboardUserInstance = this;
            up.textBoxUsername.Text = labelUsernameCard2.Text;
            up.textBoxEmail.Text = labelEmail.Text;
            up.textBoxPassword.Text = labelPassword.Text;
            up.pictureBoxProfileUpdate.Image = pictureBoxProfileCard.Image;
            up.Show();
        }

        private void labelKonsultasi_Click(object sender, EventArgs e)
        {
            panelAI.Visible = false;
            panelDetailProfile.Visible = false;
            panelKomunitas.Visible = false;
            panelDashboard.Visible = false;
            panelKonsultasi.Visible = true;
            panelTeraphy.Visible = false;
            panelNotebook.Visible = false;
            panelAI.Visible = false;
            labelSetting.ForeColor = Color.Black;
            labelDashboard.ForeColor = Color.Black;
            labelCatatan.ForeColor = Color.White;
            labelKonsultasi.ForeColor = Color.FromArgb(79, 149, 208);
        }

        private void labelTeraphy_Click(object sender, EventArgs e)
        {
            panelSelectCard.BringToFront();
            panelAI.Visible = false;
            panelDetailProfile.Visible = false;
            panelKomunitas.Visible = false;
            panelDashboard.Visible = false;
            panelKonsultasi.Visible = false;
            panelTeraphy.Visible = true;
            panelNotebook.Visible = false;
            panelAI.Visible = false;
            labelTeraphy.ForeColor = Color.FromArgb(79, 149, 208);
            labelSetting.ForeColor = Color.White;
            labelDashboard.ForeColor = Color.White;
            labelKonsultasi.ForeColor = Color.White;
            labelCatatan.ForeColor = Color.White;
        }

        private void labelCatatan_Click(object sender, EventArgs e)
        {
            panelAI.Visible = false;
            panelDetailProfile.Visible = false;
            panelKomunitas.Visible = false;
            panelDashboard.Visible = false;
            panelKonsultasi.Visible = false;
            panelTeraphy.Visible = false;
            panelNotebook.Visible = true;
            panelAI.Visible = false;
            labelTeraphy.ForeColor = Color.White;
            labelSetting.ForeColor = Color.White;
            labelDashboard.ForeColor = Color.White;
            labelKonsultasi.ForeColor = Color.White;
            labelCatatan.ForeColor = Color.FromArgb(79, 149, 208);
        }

        private void labelKomunitas_Click(object sender, EventArgs e)
        {
            panelAI.Visible = false;
            panelDetailProfile.Visible = false;
            panelKomunitas.Visible = true;
            panelDashboard.Visible = false;
            panelKonsultasi.Visible = false;
            panelTeraphy.Visible = false;
            panelNotebook.Visible = false;
            panelAI.Visible = false;
            labelTeraphy.ForeColor = Color.FromArgb(79, 149, 208);
            labelSetting.ForeColor = Color.White;
            labelDashboard.ForeColor = Color.White;
            labelKonsultasi.ForeColor = Color.White;
            labelCatatan.ForeColor = Color.White;

        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            panelDetailProfile.Visible = false;
            panelKomunitas.Visible = false;
            panelDashboard.Visible = false;
            panelKonsultasi.Visible = false;
            panelTeraphy.Visible = true;
            panelEvent.BringToFront();
            panelNotebook.Visible = false;
            labelTeraphy.ForeColor = Color.FromArgb(79, 149, 208);
            labelSetting.ForeColor = Color.White;
            labelDashboard.ForeColor = Color.White;
            labelKonsultasi.ForeColor = Color.White;
            labelCatatan.ForeColor = Color.White;
        }

        private void DashboardUser_Load(object sender, EventArgs e)
        {
            UserItem();
            TampilkanNote();
            TampilkanPostingan();
            TampilkanEvent();
            // Mengatur properti ScrollViewer.VerticalScrollBarVisibility
            panelDashboard.VerticalScroll.Visible = false;

            //NOTIFIKASI
            TimerManager timerManager = new TimerManager();
            timerManager.Elapsed += OnTimeEvent;
            timerManager.Start();

            UpdateLabelsMoodPercentage();
            UpdateLabelMood();
            UpdateLabelsMoodPercentageAndTopMood();
            UpdateLabelsMoodPercentageAndTopMoodAndWords();
        }

        private void UserItem()
        {
            SqlConnection conn = koneksi.GetConn();
            try
            {
                conn.Open();
                flowLayoutPanel1.Controls.Clear();
                SqlDataAdapter adapter;
                adapter = new SqlDataAdapter("select * from tbl_dokter", conn);

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
                            chatControl.Click += new System.EventHandler(this.userControlUser1_Load); // Tambahkan event handler di sini
                            if (chatControl.Title == labelUsername.Text)
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

        private DataTable GetChatData(string selectedUsername)
        {
            DataTable chatData = new DataTable();
            try
            {
                using (SqlConnection conn = koneksi.GetConn())
                {
                    conn.Open();
                    string query = "SELECT * FROM tbl_chat WHERE ((userone = @userone AND usertwo = @usertwo) OR (userone = @usertwo AND usertwo = @userone)) AND role = 'dokter'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userone", labelUsername.Text);
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

        private void RefreshChat(string selectedUsername)
        {
            flowLayoutPanelChat.Controls.Clear();

            DataTable chatData = GetChatData(selectedUsername);

            if (chatData != null && chatData.Rows.Count > 0)
            {
                foreach (DataRow row in chatData.Rows)
                {
                    UserControlChat2 chatControl = new UserControlChat2(); // Gunakan UserControlChat untuk user
                    chatControl.Title = row["message"].ToString();
                    chatControl.Icon = pictureProfileUserChat.Image;
                    flowLayoutPanelChat.Controls.Add(chatControl);
                }
            }
        }

        private void userControlUser1_Load(object sender, EventArgs e)
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
            RefreshChat(control.Title);
        }

        private void btnKirim_Click(object sender, EventArgs e)
        {
            SqlConnection conn = koneksi.GetConn();
            try
            {
                conn.Open();
                string q = "INSERT INTO tbl_chat(userone, usertwo, message, role) VALUES (@userone, @usertwo, @message, @sender_role)";
                cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@userone", labelUsername.Text);
                cmd.Parameters.AddWithValue("@usertwo", labelUserChat.Text);
                cmd.Parameters.AddWithValue("@message", textBoxMessage.Text);
                cmd.Parameters.AddWithValue("@sender_role", "user"); // Penanda peran pengirim sebagai user
                cmd.ExecuteNonQuery();

                // Menambahkan pesan ke dalam chat dokter sebagai UserControlChat
                UserControlChat chatControl = new UserControlChat();
                chatControl.Title = textBoxMessage.Text;
                flowLayoutPanelChat.Controls.Add(chatControl);

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

        private void cardSadness_Click(object sender, EventArgs e)
        {
            TraphyForm tf = new TraphyForm();
            tf.Show();
        }

        private void btnTambahNote_Click(object sender, EventArgs e)
        {
            panelListNoteBook.Visible = false;
            panelInsertNoteBook.Visible = true;

        }

        //CODE YANG INI POST NOTE
        private void btnTambahkanCatatan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxJudul.Text) || string.IsNullOrEmpty(textBoxDeskripsi.Text) || textBoxTanggal.Value == null || (!checkBoxBaik.Checked && !checkBoxBuruk.Checked))
            {
                MessageBox.Show("Peringatan", "Harap isi semua kolom!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (SqlConnection conn = koneksi.GetConn())
                {
                    conn.Open();
                    // Insert data user ke dalam database
                    cmd = new SqlCommand("INSERT INTO tbl_catatan (judul, deskripsi, tanggal, jenis) VALUES (@judul, @deskripsi, @tanggal, @jenis)", conn);
                    cmd.Parameters.AddWithValue("@judul", textBoxJudul.Text);
                    cmd.Parameters.AddWithValue("@deskripsi", textBoxDeskripsi.Text);
                    cmd.Parameters.AddWithValue("@tanggal", textBoxTanggal.Value);

                    // Set nilai parameter jenis berdasarkan status centang pada checkBoxBaik dan checkBoxBuruk
                    string jenis = "";
                    if (checkBoxBaik.Checked)
                    {
                        jenis = "baik";
                    }
                    if (checkBoxBuruk.Checked)
                    {
                        jenis = "buruk";
                    }
                    cmd.Parameters.AddWithValue("@jenis", jenis);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Berhasil Menambahkan Catatan", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TampilkanNote();
                    panelInsertNoteBook.Visible = false;
                    panelListNoteBook.Visible = true;

                    conn.Close();
                }
            }
        }

        private void TampilkanPostingan()
        {
            SqlConnection conn = koneksi.GetConn();
            try
            {
                conn.Open();
                flowLayoutPanelPost.Controls.Clear();
                SqlDataAdapter adapter;
                adapter = new SqlDataAdapter("select * from tbl_postingan", conn);

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
                            UserControlPostingan chatControl = new UserControlPostingan();
                            MemoryStream stream = new MemoryStream((byte[])dt.Rows[i]["foto_profile"]);
                            chatControl.Image = new Bitmap(stream);
                            MemoryStream stream2 = new MemoryStream((byte[])dt.Rows[i]["foto"]);
                            chatControl.Image2 = new Bitmap(stream2);
                            chatControl.User = dt.Rows[i]["username"].ToString();
                            chatControl.Date = dt.Rows[i]["waktu_postingan"].ToString();
                            chatControl.Description = dt.Rows[i]["deskripsi"].ToString();
                            chatControl.Click += new System.EventHandler(this.userControlPostingan1_Load);

                            // Menambahkan UserControlPostingan ke flowLayoutPanelPost
                            flowLayoutPanelPost.Controls.Add(chatControl);
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
        private void TampilkanNote()
        {
            SqlConnection conn = koneksi.GetConn();
            try
            {
                conn.Open();
                flowLayoutPanelNote.Controls.Clear();
                SqlDataAdapter adapter;
                adapter = new SqlDataAdapter("select * from tbl_catatan", conn);

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
                            UserControlNotebook chatControl = new UserControlNotebook();


                            chatControl.Margin = new Padding(0, 0, 30, 30);
                            chatControl.Title = dt.Rows[i]["judul"].ToString();
                            chatControl.Description = dt.Rows[i]["deskripsi"].ToString();
                            chatControl.Jenis = dt.Rows[i]["jenis"].ToString();
                            chatControl.Tanggal = dt.Rows[i]["tanggal"].ToString();
                            chatControl.Click += new System.EventHandler(this.userControlNotebook1_Load); // Tambahkan event handler di sini

                            flowLayoutPanelNote.Controls.Add(chatControl);
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

        private void TampilkanEvent()
        {
            SqlConnection conn = koneksi.GetConn();
            try
            {
                conn.Open();
                flowLayoutPanelEvent.Controls.Clear();
                SqlDataAdapter adapter;
                adapter = new SqlDataAdapter("select * from tbl_event", conn);

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
                            UserControlEvent chatControl = new UserControlEvent();
                            MemoryStream stream = new MemoryStream((byte[])dt.Rows[i]["gambar"]);
                            chatControl.Image = new Bitmap(stream);
                            chatControl.Title = dt.Rows[i]["nama_event"].ToString();
                            chatControl.Description = dt.Rows[i]["deskripsi_event"].ToString();
                            chatControl.Mulai = dt.Rows[i]["tanggal_mulai"].ToString();
                            chatControl.Selesai = dt.Rows[i]["tanggal_selesai"].ToString();
                            chatControl.Tempat = dt.Rows[i]["tempat"].ToString();
                            chatControl.Click += new System.EventHandler(this.userControlEvent1_Load);

                            // Menambahkan UserControlPostingan ke flowLayoutPanelPost
                            flowLayoutPanelEvent.Controls.Add(chatControl);
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






        private void btnBuruk_Click(object sender, EventArgs e)
        {
            InsertMood("Bad");
            UpdateLabelMood();
            CheckAndResetData();
            UpdateLabelsMoodPercentage();
            UpdateLabelsMoodPercentageAndTopMood();
            UpdateLabelsMoodPercentageAndTopMoodAndWords();
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            InsertMood("Good");
            UpdateLabelMood();
            CheckAndResetData();
            UpdateLabelsMoodPercentage();
            UpdateLabelsMoodPercentageAndTopMood();
            UpdateLabelsMoodPercentageAndTopMoodAndWords();
        }

        private void btnGood_Click(object sender, EventArgs e)
        {
            InsertMood("Very Good");
            UpdateLabelMood();
            CheckAndResetData();
            UpdateLabelsMoodPercentage();
            UpdateLabelsMoodPercentageAndTopMood();
            UpdateLabelsMoodPercentageAndTopMoodAndWords();
        }

        private void DashboardUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private void userControlNotebook1_Load(object sender, EventArgs e)
        {

        }

        private void panelEvent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pppn_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChatAI_Click(object sender, EventArgs e)
        {

        }

        private void panelDashboard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userControlEvent1_Load(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBuatEvent_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNamaEvent.Text) || string.IsNullOrEmpty(textBoxDeskripsiEvent.Text) || string.IsNullOrEmpty(textBoxTempatEvent.Text))
            {
                MessageBox.Show("Peringatan", "Harap isi semua kolom!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (gambarEvent.Image == null)
            {
                MessageBox.Show("Peringatan", "Harap pilih sebuah gambar!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (SqlConnection conn = koneksi.GetConn())
                {
                    conn.Open();

                    byte[] fotoProfilBytes = ImageToByteArray(gambarEvent.Image);

                    // Insert data user ke dalam database
                    cmd = new SqlCommand("INSERT INTO tbl_event (nama_event, deskripsi_event, tanggal_mulai, tanggal_selesai, tempat, gambar) VALUES (@nama, @deskripsi, @mulai, @selesai, @tempat, @gambar)", conn);
                    cmd.Parameters.AddWithValue("@nama", textBoxNamaEvent.Text);
                    cmd.Parameters.AddWithValue("@deskripsi", textBoxDeskripsiPost.Text);
                    cmd.Parameters.AddWithValue("@mulai", tanggalMulai.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@selesai", tanggalSelesai.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@tempat", Convert.ToString(textBoxTempatEvent.Text));
                    cmd.Parameters.AddWithValue("@gambar", fotoProfilBytes);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Berhasil Menambahkan Event", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TampilkanEvent();
                    conn.Close();
                }
            }
        }

        private void btnPosting_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxDeskripsiPost.Text) || dateTimePost.Value == null)
            {
                MessageBox.Show("Peringatan", "Harap isi semua kolom!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (pictureBoxPost.Image == null)
            {
                MessageBox.Show("Peringatan", "Harap pilih sebuah gambar!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (SqlConnection conn = koneksi.GetConn())
                {
                    conn.Open();

                    // Konversi gambar postingan ke dalam byte array
                    byte[] fotoPostBytes = ImageToByteArray(pictureBoxPost.Image);

                    // Konversi gambar profil ke dalam byte array
                    byte[] fotoProfilBytes = ImageToByteArray(pictureBoxProfile.Image);

                    // Insert data user ke dalam database
                    cmd = new SqlCommand("INSERT INTO tbl_postingan (username, foto_profile, waktu_postingan, deskripsi, foto) VALUES (@username, @profile, @waktu, @deskripsi, @foto)", conn);
                    cmd.Parameters.AddWithValue("@username", labelUsername.Text);
                    cmd.Parameters.AddWithValue("@profile", fotoProfilBytes); // Menggunakan gambar profil
                    cmd.Parameters.AddWithValue("@waktu", dateTimePost.Value);
                    cmd.Parameters.AddWithValue("@deskripsi", textBoxDeskripsiPost.Text);
                    cmd.Parameters.AddWithValue("@foto", fotoPostBytes);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Berhasil Menambahkan Postingan", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    panelInsertNoteBook.Visible = false;
                    panelListNoteBook.Visible = true;
                    TampilkanPostingan();
                    conn.Close();
                }
            }
        }

        private void btnTambahkanFoto_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();

                // Memuat gambar ke pictureBoxPost
                pictureBoxPost.ImageLocation = imgLocation;

                // Memuat gambar ke pictureBoxProfile
                pictureBoxProfile.ImageLocation = imgLocation;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();

                // Memuat gambar ke pictureBoxPost
                gambarEvent.ImageLocation = imgLocation;

                // Memuat gambar ke pictureBoxProfile
                gambarEvent.ImageLocation = imgLocation;
            }
        }

        private void userControlPostingan1_Load(object sender, EventArgs e)
        {

        }

        private void panelListNoteBook_Paint(object sender, PaintEventArgs e)
        {

        }
    }


    public class TimerManager
    {
        private System.Timers.Timer timer;

        public event EventHandler Elapsed;

        public TimerManager()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000; // Satuan waktu dalam milidetik
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Elapsed?.Invoke(sender, e);
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}