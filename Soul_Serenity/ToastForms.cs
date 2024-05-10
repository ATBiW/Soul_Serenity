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
    public partial class ToastForms : Form
    {
        int toastX, toastY;
        public ToastForms(string type, string message)
        {
            InitializeComponent();
            lblType.Text = type;
            lblMessage.Text = message;

            switch (type)
            {
                case "Daily Reminder":

                    break;
            }
        }

        private void toastTimer_Tick(object sender, EventArgs e)
        {
            toastY -= 1;
            this.Location = new Point(toastX, toastY);
            if (toastY <= 760)
            {
                toastTimer.Stop();
                toastHide.Start();
            }
        }
        int y = 100;
        private void toastHide_Tick(object sender, EventArgs e)
        {
            y--;
            if (y <= 0)
            {
                toastY += 1;
                this.Location = new Point(toastX, toastY += 10);
                if (toastY > 800)
                {
                    toastHide.Stop();
                    y = 100;
                    this.Close();
                }
            }
        }

        private void Position()
        {
            int ScreenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int ScreenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            toastX = ScreenWidth - this.Width - 5;
            toastY = ScreenHeight - this.Height - 5;

            this.Location = new Point(toastX, toastY);

        }

        private void ToastForms_Load(object sender, EventArgs e)
        {
            Position();
        }
    }
}
