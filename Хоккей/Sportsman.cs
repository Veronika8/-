using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Хоккей
{
    public class Sportsman
    {
        public string Name;
        public int[] rollin; //забитые на 1 этапе шайбы
        public int[] missed; //пропущенные на 1 этапе шайбы
        public int win = 0;    //очки на 1 этапе
        public int sumrollin = 0;
        public int summissed = 0;
        public int id;
        public int[] roll; //забитые на 2 этапе шайбы
        public int[] miss; //пропущенные на 2 этапе шайбы
        public int win1 = 0; //очки на 2 этапе
        public int sumroll = 0;
        public int summiss = 0;
        public int rubber = 0;
        public int res = 0;
        public int fin = 0;

        //метод для вычисления количества набранных очков и сумм забитых и пропущенных шайб на 1 этапе
        public void CalcWin()
        {
            for (int i = 0; i < rollin.Length; i++)
            {
                if (rollin[i] > missed[i])
                    win++;
            }
            for (int i = 0; i < Program.ecount; i++)
            {
                sumrollin += rollin[i];
                summissed += missed[i];
            }
        }

        //метод для вычисления количества набранных очков и сумм забитых и пропущенных шайб на 2 этапе
        public void CalcWin1()
        {
            for (int i = 0; i < roll.Length; i++)
            {
                if (roll[i] > miss[i])
                    win1++;
            }
            for (int i = 0; i < Program.ecount1 ; i++)
            {
                sumroll += roll[i];
                summiss += miss[i];
            }

        }

        public static int compareSM(Sportsman a, Sportsman b)
        {
            //сравниваем по количеству набранных очков:
            if (a.win > b.win)
                return -1;
            else if (a.win < b.win)
                return 1;
            //сравниваем по лучшей разницы забитых и пропущенных шайб во всех играх:
            else
            {
                int differenceA = a.sumrollin - a.summissed;
                int differenceB = b.sumrollin - b.summissed;
                if (differenceA > differenceB)
                    return -1;
                else if (differenceA < differenceB)
                    return 1;

                //по результатам игр между собой
                else if (a.rollin[b.id] > b.rollin[a.id])
                    return -1;
                else if (a.rollin[b.id] < b.rollin[a.id])
                    return 1;

                //сравниваем по наибольшему числу забитых шайб во всех играх:
                else if (a.sumrollin > b.sumrollin)
                    return -1;
                else if (a.sumrollin < b.sumrollin)
                    return 1;
                else
                    return 0;
            }
        }

        public static int compareT(Sportsman a, Sportsman b)
        {
            //сравниваем по количеству набранных очков:
            if (a.win1 > b.win1)
                return -1;
            else if (a.win1 < b.win1)
                return 1;
            //сравниваем по лучшей разницы забитых и пропущенных шайб во всех играх:
            else
            {
                int difference1 = a.sumroll - a.summiss;
                int difference2 = b.sumroll - b.summiss;
                if (difference1 > difference2)
                    return -1;
                else if (difference1 < difference2)
                    return 1;
                else
                    return 0;
            }
        }
    }
}
