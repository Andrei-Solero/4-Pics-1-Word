using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Syntax_Error___4Pics_1Word
{
    public partial class SplashScreen : Form
    {

        Gameboard gb = new Gameboard();

        public SplashScreen()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Gameboard.Audio("selectletters.wav");
            Game gameboard = new Game();
            gameboard.Show();
            Hide();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\tSYNTAX ERROR\t\n\n\t-Abaja, Rollin Jhay\t\n\t-Solero, Adrian\t\t\n\t-Tafalla, Joana Marie\t\t", "About 4Pics 1Word", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
