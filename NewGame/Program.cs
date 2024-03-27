using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewGame
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        public static ApplicationContext main_form;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new PlayScreen());
            main_form = new ApplicationContext();
            main_form.MainForm = new PlayScreen();
            Application.Run(main_form);
        }

        public static void DisplayPlayScreen()
        {
            main_form.MainForm = new PlayScreen();
            main_form.MainForm.Show();
        }
        //5,Form1に切り替える処理
        public static void DisplayResultScreen()
        {
            main_form.MainForm = new ResultScreen();
            main_form.MainForm.Show();
        }
    }
}
