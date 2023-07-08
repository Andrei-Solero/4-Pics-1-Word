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
    public partial class Game : Form
    {
        int counter = 0;
        Gameboard gb = new Gameboard();
        User player = new User();
        CorrectAnswer c = new CorrectAnswer();

        public Game()
        {
            InitializeComponent();
        }

        public Control[] ChoiceButton()
        {
            Guna2Button[] btn = { firstTextButton, secondTextButton, thirdTextButton, fourthTextButton, fifthTextButton, sixthTextButton };
            return btn;
        }

        public List<Control> AnswerButton()
        {
            List<Control> choices = choicePanel.Controls.OfType<Control>().ToList();
            return choices;
        }

        private void SetText(Control btn)
        {
            Control[] textbutton = ChoiceButton();
            if (textbutton[0].Text.Equals(""))
            {
                textbutton[0].Text = btn.Text;
            }
            else if (textbutton[1].Text.Equals(""))
            {
                textbutton[1].Text = btn.Text;
            }
            else if (textbutton[2].Text.Equals(""))
            {
                textbutton[2].Text = btn.Text;
            }
            else if (textbutton[3].Text.Equals(""))
            {
                textbutton[3].Text = btn.Text;
            }
            else if (textbutton[4].Text.Equals(""))
            {
                textbutton[4].Text = btn.Text;
            }
            else if (textbutton[5].Text.Equals(""))
            {
                textbutton[5].Text = btn.Text;
            }
        }

        private void AnswerClick(object sender, EventArgs e)
        {
            Gameboard.Audio("removeletters.wav");
            ((Guna2Button)sender).Text = string.Empty;
            var sample = AnswerButton();
        }
  
        private void ChoicesClick(object sender, EventArgs e)
        {
            Control[] btn = ChoiceButton();
            try
            {   
                SetText(((Guna2GradientButton)sender));
                Gameboard.Audio("selectLetters.wav");
                
                if (btn[0].Text != "" && btn[1].Text != "" && btn[2].Text != "" && btn[3].Text != "" && btn[4].Text != "" && btn[5].Text != "")
                {
                    var useranswer = player.SetAnswer(btn);
                    var check = gb.CheckUserAnswer(useranswer);

                    if (check == true)
                    {
                        CorrectAnswer c = new CorrectAnswer(useranswer, int.Parse(StageLabel.Text), int.Parse(NumberofCoins.Text));
                        Thread.Sleep(500);
                        Hide();
                        c.ShowDialog();
                        NextStage();
                    }
                }
            }
            catch
            {   
                Gameboard.Audio("Secondwrong.wav");
            }

        }

        private void Play()
        {
            Gameboard gb = new Gameboard(NumberofCoins, StageLabel, picturesPanel, choicePanel);
            gb.LoadTile();
        }

        private void NextStage()
        {
            Controls.Clear();
            InitializeComponent();

            counter = 0;
            try
            {
                Show();
                Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void UseHint()
        {
            if(player.SetUserCoins() > player._hintCost)
            {
                var btn = ChoiceButton();
                var choices = AnswerButton();

                HintPrompt hint = new HintPrompt(player.SetUserCoins().ToString());
                hint.ShowDialog();

                if (HintPrompt.decision == true)
                {
                    player.UseHint(btn, choices, NumberofCoins);
                }
            }
            else
            {
                MessageBox.Show("Insufficient coins :((", "4Pics 1Word", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void Game_Load(object sender, EventArgs e)
        {
           Play();    
        }

        private void HintButton_Click(object sender, EventArgs e)
        {
            UseHint();  
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Dispose();
            SplashScreen startmain = new SplashScreen();
            startmain.Show();
        }
    }
}
