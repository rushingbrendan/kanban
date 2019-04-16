using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


//<add key="databaseConnectionString" value="Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;Password=Conestoga1;Initial Catalog=asqlKanban" />

namespace OrderCreator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
