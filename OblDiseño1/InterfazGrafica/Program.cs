using InterfazGrafica.InterfazIngreso;
using System;
using System.Windows.Forms;
using OblDiseño1;

namespace InterfazGrafica
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
                Application.Run(new InterfazIngresoSistema());
            
            //catch (System.data.sqlclient.sqlexception)
            //{

            //}
        }
    }
}
