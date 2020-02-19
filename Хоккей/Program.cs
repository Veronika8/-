using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Хоккей
{
    static class Program
    {
        public static int smcount=16;
        public static int ecount=4;
        public static int ecount1 = 6;
        public static Sportsman[] groupA;
        public static Sportsman[] groupB;
        public static Sportsman[] groupC;
        public static Sportsman[] groupD;
        public static Sportsman[] group1;
        public static Sportsman[] group2;
        public static Sportsman[] group;
        public static Sportsman[] final;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
