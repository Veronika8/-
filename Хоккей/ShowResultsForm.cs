using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Хоккей
{
    public partial class ShowResultsForm : Form
    {
        public void ShowByArray(Sportsman[] array)
        {
            //создаем колонки
            groupResultsDG.Columns.Add("SportsmanName", "Команда");
            groupResultsDG.Columns.Add("Result", "Очки");
            groupResultsDG.Columns.Add("Rollin", "Забитые шайбы");
            groupResultsDG.Columns.Add("Missed", "Пропущенные шайбы");

            //заполняем строки
            groupResultsDG.Rows.Add(array.Length);
            for(int i=0; i<array.Length; i++)
            {
                groupResultsDG["SportsmanName", i].Value = array[i].Name;
                groupResultsDG["Result", i].Value = array[i].win;
                groupResultsDG["Rollin", i].Value = array[i].sumrollin;
                groupResultsDG["Missed", i].Value = array[i].summissed;
            }
            Show(); //показать форму
        }

        public void ShowByArray1(Sportsman[] array)
        {
            //создаем колонки
            groupResultsDG.Columns.Add("SportsmanName", "Команда");
            groupResultsDG.Columns.Add("Result", "Очки");
            groupResultsDG.Columns.Add("Rollin", "Забитые шайбы");
            groupResultsDG.Columns.Add("Missed", "Пропущенные шайбы");

            //заполняем строки
            groupResultsDG.Rows.Add(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                groupResultsDG["SportsmanName", i].Value = array[i].Name;
                groupResultsDG["Result", i].Value = array[i].win1;
                groupResultsDG["Rollin", i].Value = array[i].sumroll;
                groupResultsDG["Missed", i].Value = array[i].summiss;
            }
            Show(); //показать форму
        }

            public ShowResultsForm()
        {
            InitializeComponent();
        }
    }
}
