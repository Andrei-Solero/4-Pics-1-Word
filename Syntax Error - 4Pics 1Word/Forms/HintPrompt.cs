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
    public partial class HintPrompt : Form
    {

        public static bool decision { get; set; }
        public string coins { get; set; }

        public HintPrompt(string forcoins)
        {
            coins = forcoins;
            InitializeComponent();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            decision = true;
            Gameboard.Audio("kerching.wav");
            Dispose();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void HintPrompt_Load(object sender, EventArgs e)
        {
            remainingCoins.Text = coins;
        }
    }
}
