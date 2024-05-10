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
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel3.Width += 3;
            if (panel3.Width >= 916)
            {
                timer1.Stop();
                SplashScreen1 splashScreen1 = new SplashScreen1();
                splashScreen1.Show();
                this.Hide();
            }
        }
    }
}
