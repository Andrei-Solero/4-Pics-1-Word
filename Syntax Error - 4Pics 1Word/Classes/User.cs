using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Syntax_Error___4Pics_1Word
{
    public class User : DataAccesss
    {

        int coins;
        int stage;
        const int hintcost = 8;
        public int _hintCost { get { return hintcost; } }

        public int SetUserCoins()
        {
            coins = 0;
            coins = int.Parse(DBCommandReadData("SELECT * FROM [User]", "Coins"));
            return coins;
        }
        
        public bool UseHint(Control[] setButton, List<Control> getButton, Control coins)
        {
            Gameboard gb = new Gameboard();
            bool decision = true;
            Random ran = new Random();
            if(decision == true)
            {
                var answer = gb.GetLevel();
                int index = ran.Next(answer.Length);

                setButton[index].Text = answer[index].ToString();

                var remainingcoins = SetUserCoins();
                var cost = remainingcoins - hintcost;
                coins.Text = cost.ToString();
                DbExecuteCommand("UPDATE [User] SET [Coins] = " + cost);
            }
            return decision;
        }

        public int GetCurrentStage()
        {
            stage = 1;
            stage = int.Parse(DBCommandReadData("SELECT * FROM [Stages] where [IsAnswered] = No ORDER BY [Stage] ASC", "Stage"));
            return stage;
        }

        public string SetAnswer(Control[] ctrl)
        {
            string[] useranswer = new string[6];
            var answer = "";

            for (int i = 0; i < ctrl.Length; i++)
            {
                useranswer[i] = ctrl[i].Text.ToString();
            }

            answer = string.Join("", useranswer);
            return answer;
        }

    }
}
