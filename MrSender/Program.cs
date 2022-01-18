using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MrSender
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            //using (SingleProgramInstance spi = new SingleProgramInstance("m8s3nd3r"))
            //{
            //    if (spi.IsSingleInstance)
            //    {
            //        Application.Run(new Form1());
            //    }
            //    else
            //    {
            //        spi.RaiseOtherProcess();
            //    }
            //}

            if (!SingleInstance.Start())
            {
                SingleInstance.ShowFirstInstance();
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new Form1());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            SingleInstance.Stop();


        }
    }
}
