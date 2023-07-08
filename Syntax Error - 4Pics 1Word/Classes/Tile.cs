using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using System.Drawing;
using System.IO;

namespace Syntax_Error___4Pics_1Word
{
    public abstract class Tile : DataAccesss
    {
        public string tag { get; set; }
        public string imagepath {
            get { return Application.StartupPath + @"\Images\" + tag + @"\"; }
        }

        public abstract void LoadImage(Control panelname);
        public abstract void LoadRumbledWord(Control panelname);

     }
}
