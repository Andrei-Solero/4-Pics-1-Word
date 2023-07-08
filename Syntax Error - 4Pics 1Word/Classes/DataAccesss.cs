using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Syntax_Error___4Pics_1Word
{
    public abstract class DataAccesss
    {
        public string cnnString = "PROVIDER=MICROSOFT.ACE.OLEDB.12.0;Data Source = " + Application.StartupPath + @"\4Pics1WordDB.accdb";
        public OleDbConnection cn = new OleDbConnection();
        public OleDbCommand command;
        public OleDbDataReader reader;
       
        public dynamic DBCommandReadData(string query, string data)
        {
            var word = "";
            cn.ConnectionString = cnnString;
            if(cn.State == ConnectionState.Closed)
            {
                cn.Open();
                command = new OleDbCommand();
                command.Connection = cn;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                reader = command.ExecuteReader();
                if (reader.Read() == true)
                {
                    word = reader[data].ToString().ToUpper();
                }
            }
            
            cn.Close();
            command.Dispose();

            return word;
        }

        public void DbExecuteCommand(string query)
        {
            cn.ConnectionString = cnnString;
            if(cn.State == ConnectionState.Closed)
            {
                cn.Open();
                command = new OleDbCommand();
                command.Connection = cn;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.ExecuteNonQuery();
            }

            cn.Close();
        }

    }
}
