using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Media;
using System.IO;
using System.Numerics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using System.Threading;

namespace Soul_Serenity
{
    public partial class TraphyForm : Form
    {
        System.Timers.Timer t;
        int h, m, s;
        private bool buangNafas = false;
        public TraphyForm()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void TraphyForm_Load(object sender, EventArgs e)
        {
        }

        private void InitializeTimer()
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
            this.FormClosing += TraphyForm_FormClosing;
        }

        private string[] kataKata = { "Tahan sejenak, biarkan nafasmu mengisi tubuhmu\ndengan energi yang segar", "Buangkan", "Tarik nafas dalam lagi..... rasakan udara memenuhi paru paru mu", "Lalu, perlahan-lahan lepaskan nafas, \nrasakan ketegangan perlahan memudar", "Tarik nafas baru dengan penuh kedamaian", "Tarik yang dalam.... \nbiarkan nafasmu membawa kedamaian pada setiap sel tubuh mu", "Lalu lepaskan, lepaskan segala ketegangan dengan nafas mu. \nBiarkan kegelisahan mu itu pergi", "Tarik nafas yang dalam lagi....", "Rasakan, rasakan ketegangan mengalir masuk \ndan hempuskan nafasmu dengan lega...", "" };
        private int kataIndex = 0; // Indeks untuk menunjukkan posisi saat ini dalam array kataKata
        private int[] durasiKata = { 5, 13, 5, 11, 10, 9, 9, 18, 20, 14 }; // Durasi waktu untuk setiap kata dalam detik

        private void OnTimeEvent(object? sender, ElapsedEventArgs e)
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

                // Memeriksa apakah waktu mencapai atau melebihi durasi kata terakhir
                if (kataIndex == kataKata.Length)
                {
                    lblNafas.Text = "Bagaimana perasaanmu sekarang?";
                }
                else
                {
                    // Mengubah teks label berdasarkan durasi waktu saat ini
                    if (s % durasiKata[kataIndex] == 0)
                    {
                        lblNafas.Text = kataKata[kataIndex];
                        kataIndex++; // Naikkan indeks setelah menetapkan teks label
                    }
                }

                lblTimer.Text = string.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));

                // Memeriksa apakah waktu telah mencapai 1 menit dan 8 detik, jika ya, hentikan timer
                if (m == 1 && s == 8)
                {
                    t.Stop();
                }
            }));
        }



        private void btnMulai_Click(object sender, EventArgs e)
        {
            btnMulai.Visible = false;
            lblNafas.Visible = true;
            PlayTherapyAudio();
            t.Start();
        }
        private void PlayTherapyAudio()
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.TherapySoundHot);
            player.Play();
        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }

        private void TraphyForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void TraphyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (t != null)
            {
                t.Stop();
            }
        }

        private void gradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
