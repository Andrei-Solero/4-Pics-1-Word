using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Drawing;

namespace Syntax_Error___4Pics_1Word
{
    public class Gameboard : Stage
    {
        User player = new User();
        const int AddedCoins = 10;
        Control coins;
        Control stage;
        Control pictures;
        Control letters;
        
        public Gameboard(Control forcoins, Control forstage, Control forpictures, Control forletters)
        {
            coins = forcoins;
            stage = forstage;
            pictures = forpictures;
            letters = forletters;
        }

        public Gameboard()
        {

        }

        public static void Audio(string filename)
        {
            string path = Application.StartupPath + @"\Audio\" + filename;
            System.Media.SoundPlayer audio = new System.Media.SoundPlayer(path.ToString());
            audio.Play();   //Plays the audio when the button is clicked   
            
        }

        public bool CheckUserAnswer(string userAnswer)
        {
            bool status;
            var correctAnswer = GetLevel();
            if (userAnswer.Equals(correctAnswer))
            {
                var remainingCoins = player.SetUserCoins();
                int addCoins = remainingCoins + AddedCoins;

                DbExecuteCommand("UPDATE [Stages] SET [IsAnswered] = Yes where [Stage] = " + player.GetCurrentStage()); //Update the database to make word answered.
                DbExecuteCommand("UPDATE [User] SET [Coins] = " + addCoins);

                status = true;
            }
            else
            {
                Audio("Secondwrong.wav");
                status = false;
            }

            return status;
        }

        private void LoadUserCoins()
        {
            var usercoins = player.SetUserCoins();
            coins.Text = usercoins.ToString();
        }

        private void LoadStage()
        {
            var playerstage = player.GetCurrentStage();
            stage.Text = playerstage.ToString();   
        }

        public void LoadTile()
        {
            LoadUserCoins();
            LoadStage();
            LoadImage(pictures);
            LoadRumbledWord(letters);
        }

    }
}
