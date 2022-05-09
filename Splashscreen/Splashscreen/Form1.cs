using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Splashscreen
{
    public partial class Form1 : Form
    {
        int counter = 0;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void SSLoadingBar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("DONT BE IMPATIENT", "DONT BE HASTY!!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timeLeft = 8;
            loadTimer.Enabled = true;
        }

        public int timeLeft { get; set; }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                Random r = new Random();
                int randomNumber = r.Next(1, 10);
                counter = counter + randomNumber;
                SSLoadingBar.Value = counter;
                
                timeLeft = timeLeft - 1;
            }

            else

            {
                SSLoadingBar.Value = 100;
                loadTimer.Stop();

                MessageBox.Show("ARE YOU READY?");

                this.Close();
            }

        }
    }
}
