using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.IO;
using System.Drawing;

namespace Syntax_Error___4Pics_1Word
{
    public class Stage : Tile
    {

        public string GetLevel()
        {
            var words = "";
            words = DBCommandReadData("SELECT * FROM [Stages] where [IsAnswered] = No ORDER BY [Stage] ASC", "Word");
            return words;
        }

        private string[] RandomWord()
        {
            var word = GetLevel();
            int upperBound = 12;
            if (word.Length > upperBound)
                throw new Exception("Character count cannot be more than the upper bound");
            var newWord = new string[upperBound];
            var letters = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(',');

            for (int i = 0; i < upperBound; i++)
            {
                try
                {
                    newWord[i] = word[i].ToString();
                }
                catch
                {
                    var random = new Random().Next(0, (letters.Length - 1));
                    newWord[i] = letters[random];
                }
            }

            return newWord
                .Select(w => new { Id = Guid.NewGuid(), letters = w, }).OrderBy(x => x.Id).Select(x => x.letters.ToUpper()).ToArray();
        }

        public override void LoadImage(Control panelname)
        {
            var sample = GetLevel();
            tag = sample;
            string[] images = Directory.GetFiles(imagepath, "*.*", SearchOption.AllDirectories);
            List<Guna2PictureBox> picturebox = panelname.Controls.OfType<Guna2PictureBox>().ToList();

            for (int i = 0; i < picturebox.Count; i++)
            {
                picturebox[i].Image = Image.FromFile(images[i]);
            }
        }

        public override void LoadRumbledWord(Control panelname)
        {
            List<Guna2GradientButton> buttons = panelname.Controls.OfType<Guna2GradientButton>().ToList();
            var RandomizedWord = RandomWord();

            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Text = RandomizedWord[i].ToString().ToUpper();
            }
        }

    }
}
