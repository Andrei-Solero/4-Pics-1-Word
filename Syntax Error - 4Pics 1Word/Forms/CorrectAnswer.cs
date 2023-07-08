using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Syntax_Error___4Pics_1Word
{
    public partial class CorrectAnswer : Form
    {

        public string correctanswer { get; set; }
        public int level { get; set; }
        public int AddCoins { get; set; }
        List<Guna2PictureBox> pictures = new List<Guna2PictureBox>();

        public CorrectAnswer(string forCorrectAnswer, int forLevel, int forAddCoins)
        {
            correctanswer = forCorrectAnswer;
            level = forLevel;
            AddCoins = forAddCoins;

            InitializeComponent();
        }

        public CorrectAnswer()
        {
            InitializeComponent();
        }

        private void CorrectAnswer_Load(object sender, EventArgs e)
        {
            LoadCorrectTile();
        }

        private void LoadCorrectTile()
        {

            AnswerLabel.Text = correctanswer;
            StageLabel.Text = level.ToString();
            NumberofCoins.Text = AddCoins.ToString();
            Gameboard.Audio("correct.wav");
            
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
        
    }
}
