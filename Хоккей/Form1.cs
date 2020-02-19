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
    public partial class MainForm : Form
    {
        int curGroupNum, curSMNum1, curSMNum2, point1, point2;
        int GroupNum, it, jt, pi, pj;
        int ik, jk, gr;
        int z, x, y;
        public MainForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string inName = nameBox.Text.Trim();
            if (inName != "")
            {
                allNamesBox.Items.Add(inName);
                nameBox.Clear();
                nameBox.Focus();
            }
            if (allNamesBox.Items.Count==Program.smcount)
            {
                nameBox.Enabled = false;
                AddButton.Enabled = false;
                splitGroups.Visible = true;
            }
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void nameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                AddButton_Click(sender, e);
        }


        private void splitGroups_Click(object sender, EventArgs e)
        {
            int groupAcount = allNamesBox.Items.Count / 4;
            int groupBcount = allNamesBox.Items.Count -3*groupAcount;
            int groupCcount = allNamesBox.Items.Count - 2 * groupAcount - groupBcount;
            int GroupDcount = allNamesBox.Items.Count - groupAcount - groupBcount - groupCcount;
            Program.groupA = new Sportsman[groupAcount];
            Program.groupB = new Sportsman[groupBcount];
            Program.groupC = new Sportsman[groupCcount];
            Program.groupD = new Sportsman[GroupDcount];
            for (int i=0; i<Program.groupA.Length; i++)
            {
                Program.groupA[i] = new Sportsman();
                Program.groupA[i].id = i;
                Program.groupA[i].rollin = new int[Program.ecount];
                Program.groupA[i].missed = new int[Program.ecount];
                Program.groupA[i].Name = allNamesBox.Items[i].ToString();
            }
            for (int i = 0; i < Program.groupB.Length; i++)
            {
                Program.groupB[i] = new Sportsman();
                Program.groupB[i].id = i;
                Program.groupB[i].rollin = new int[Program.ecount];
                Program.groupB[i].missed = new int[Program.ecount];
                Program.groupB[i].Name = allNamesBox.Items[groupAcount + i].ToString();
            }
            for (int i = 0; i < Program.groupC.Length; i++)
            {
                Program.groupC[i] = new Sportsman();
                Program.groupC[i].id = i;
                Program.groupC[i].rollin = new int[Program.ecount];
                Program.groupC[i].missed = new int[Program.ecount];
                Program.groupC[i].Name = allNamesBox.Items[groupAcount + groupBcount + i].ToString();
            }
            for (int i = 0; i < Program.groupD.Length; i++)
            {
                Program.groupD[i] = new Sportsman();
                Program.groupD[i].id = i;
                Program.groupD[i].rollin = new int[Program.ecount];
                Program.groupD[i].missed = new int[Program.ecount];
                Program.groupD[i].Name = allNamesBox.Items[groupAcount + groupBcount + groupCcount + i].ToString();
            }
            mainTabs.SelectedIndex++;
            splitGroups.Enabled = false;
            curGroupNum = 0;
            curSMNum1 = 0;
            curSMNum2 = 1;
            point1 = 1;
            point2 = 0;
            sportsmenNameLabel1.Text = Program.groupA[curSMNum1].Name;
            sportsmenNameLabel2.Text = Program.groupA[curSMNum2].Name;
        }


        private void nextSportsmen_Click(object sender, EventArgs e)
        {
            {
                if (curGroupNum == 0)
                {
                    Program.groupA[curSMNum1].rollin[point1] = (int)resultUpDown1.Value;
                    Program.groupA[curSMNum1].missed[point1] = (int)resultUpDown2.Value;
                    Program.groupA[curSMNum2].rollin[point2] = (int)resultUpDown2.Value;
                    Program.groupA[curSMNum2].missed[point2] = (int)resultUpDown1.Value;
                }
                else
                    if (curGroupNum == 1)
                {
                    Program.groupB[curSMNum1].rollin[point1] = (int)resultUpDown1.Value;
                    Program.groupB[curSMNum1].missed[point1] = (int)resultUpDown2.Value;
                    Program.groupB[curSMNum2].rollin[point2] = (int)resultUpDown2.Value;
                    Program.groupB[curSMNum2].missed[point2] = (int)resultUpDown1.Value;
                }
                else
                    if (curGroupNum == 2)
                {
                    Program.groupC[curSMNum1].rollin[point1] = (int)resultUpDown1.Value;
                    Program.groupC[curSMNum1].missed[point1] = (int)resultUpDown2.Value;
                    Program.groupC[curSMNum2].rollin[point2] = (int)resultUpDown2.Value;
                    Program.groupC[curSMNum2].missed[point2] = (int)resultUpDown1.Value;
                }
                else
                    if (curGroupNum == 3)
                {
                    Program.groupD[curSMNum1].rollin[point1] = (int)resultUpDown1.Value;
                    Program.groupD[curSMNum1].missed[point1] = (int)resultUpDown2.Value;
                    Program.groupD[curSMNum2].rollin[point2] = (int)resultUpDown2.Value;
                    Program.groupD[curSMNum2].missed[point2] = (int)resultUpDown1.Value;
                }
                if (curSMNum2 < 3)
                {
                    curSMNum2++;
                    point1++;
                }
                else
                    if (curSMNum2 == 3)
                {
                    if (curSMNum1 < 2)
                    {
                        curSMNum1++;
                        curSMNum2 = curSMNum1 + 1;
                        point2++;
                        point1 = 2;
                        {
                            if (curSMNum1 == 2) point1 = 3;
                        }
                    }
                    else
                    {
                        curSMNum1 = 0;
                        curSMNum2 = 1;
                        point1 = 1;
                        point2 = 0;
                        curGroupNum++;
                    }
                }
            }
            if (curGroupNum <= 3)
            {
                if (curGroupNum == 0)
                {
                    groupNameLabel.Text = "Группа A";
                    sportsmenNameLabel1.Text = Program.groupA[curSMNum1].Name;
                    sportsmenNameLabel2.Text = Program.groupA[curSMNum2].Name;
                }
                else
                    if (curGroupNum == 1)
                {
                    groupNameLabel.Text = "Группа B";
                    sportsmenNameLabel1.Text = Program.groupB[curSMNum1].Name;
                    sportsmenNameLabel2.Text = Program.groupB[curSMNum2].Name;
                }
                else
                    if (curGroupNum == 2)
                {
                    groupNameLabel.Text = "Группа C";
                    sportsmenNameLabel1.Text = Program.groupC[curSMNum1].Name;
                    sportsmenNameLabel2.Text = Program.groupC[curSMNum2].Name;
                }
                else
                    if (curGroupNum == 3)
                {
                    groupNameLabel.Text = "Группа D";
                    sportsmenNameLabel1.Text = Program.groupD[curSMNum1].Name;
                    sportsmenNameLabel2.Text = Program.groupD[curSMNum2].Name;
                }
            }
            else
            {
                nextSportsmen.Enabled = false;
                calcResultButton.Visible = true;
            }
        }

        private void calcResultButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.groupA.Length; i++)
                Program.groupA[i].CalcWin();
            for (int i = 0; i < Program.groupB.Length; i++)
                Program.groupB[i].CalcWin();
            foreach (Sportsman sm in Program.groupC)
                sm.CalcWin();
            foreach (Sportsman sm in Program.groupD)
                sm.CalcWin();

            Array.Sort(Program.groupA, new Comparison<Sportsman>(Sportsman.compareSM));
            Array.Sort(Program.groupB, new Comparison<Sportsman>(Sportsman.compareSM));
            Array.Sort(Program.groupC, new Comparison<Sportsman>(Sportsman.compareSM));
            Array.Sort(Program.groupD, new Comparison<Sportsman>(Sportsman.compareSM));

            showGroup1Button.Visible = true;
            showGroup2Button.Visible = true;
            showGroup3Button.Visible = true;
            showGroup4Button.Visible = true;
            nextRoundbutton.Visible = true;
            calcResultButton.Enabled = false;

        }

        private void winnerFinalBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void resultButton_Click(object sender, EventArgs e)
        {
            ShowResultsForm frm2 = new ShowResultsForm();

            if (sender == showGroup1Button)
                frm2.ShowByArray(Program.groupA);
            else if (sender == showGroup2Button)
                frm2.ShowByArray(Program.groupB);
            else if (sender == showGroup3Button)
                frm2.ShowByArray(Program.groupC);
            else if (sender == showGroup4Button) 
                frm2.ShowByArray(Program.groupD);
            else if (sender == showGroupButton1)
                frm2.ShowByArray1(Program.group1);
            else if (sender == showGroupButton2)
                frm2.ShowByArray1(Program.group2);
        }

        private void nextRoundbutton_Click(object sender, EventArgs e)
        {
            Program.group1 = new Sportsman[6];
            Program.group2 = new Sportsman[6];
            Program.group1[0] = Program.groupA[0];
            Program.group1[1] = Program.groupA[1];
            Program.group1[2] = Program.groupA[2];
            Program.group1[3] = Program.groupB[0];
            Program.group1[4] = Program.groupB[1];
            Program.group1[5] = Program.groupB[2];

            Program.group2[0] = Program.groupC[0];
            Program.group2[1] = Program.groupC[1];
            Program.group2[2] = Program.groupC[2];
            Program.group2[3] = Program.groupD[0];
            Program.group2[4] = Program.groupD[1];
            Program.group2[5] = Program.groupD[2];

            for (int i = 0; i < Program.group1.Length; i++)
            {
                Program.group1[i].roll = new int[Program.ecount1 ];
                Program.group1[i].miss = new int[Program.ecount1 ];
            }
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                    {
                        if (j == k) continue;
                        Program.group1[j].roll[k] = Program.group1[j].rollin[Program.group1[k].id];
                    }
            for (int j = 3; j < 6; j++)
                for (int k = 3; k < 6; k++)
                {
                    if (j == k) continue;
                    Program.group1[j].roll[k] = Program.group1[j].rollin[Program.group1[k].id];
                }
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                    {
                        if (j == k) continue;
                        Program.group1[ j].miss[k] = Program.group1[j].missed[Program.group1[k].id];
                    }
            for (int j = 3; j < 6; j++)
                for (int k = 3; k < 6; k++)
                {
                    if (j == k) continue;
                    Program.group1[j].miss[k] = Program.group1[j].missed[Program.group1[k].id];
                }
            for (int i = 0; i < Program.group2.Length; i++)
            {
                Program.group2[i].roll = new int[Program.ecount1 ];
                Program.group2[i].miss = new int[Program.ecount1 ];
            }
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                    {
                        if (j == k) continue;
                        Program.group2[ j].roll[k] = Program.group2[ j].rollin[Program.group2[k].id];
                    }
            for (int j = 3; j < 6; j++)
                for (int k = 3; k < 6; k++)
                {
                    if (j == k) continue;
                    Program.group2[j].roll[k] = Program.group2[j].rollin[Program.group2[k].id];
                }
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                    {
                        if (j == k) continue;
                        Program.group2[j].miss[k] = Program.group2[ j].missed[Program.group2[k].id];
                    }
            for (int j = 3; j < 6; j++)
                for (int k = 3; k < 6; k++)
                {
                    if (j == k) continue;
                    Program.group2[j].miss[k] = Program.group2[j].missed[Program.group2[k].id];
                }
            mainTabs.SelectedIndex++;
            GroupNum = 0;
            it = 0;
            jt = 3;
            pi = 3;
            pj = 0;
            group2NameLabel.Text = "Группа 1";
            teamNameLabel1.Text = Program.group1[it].Name;
            teamNameLabel2.Text = Program.group1[jt].Name;
        }

        private void nextTeam_Click(object sender, EventArgs e)
        {
            {
                if (GroupNum == 0)
                {
                    Program.group1[it].roll[pi] = (int)result1UpDown1.Value;
                    Program.group1[it].miss[pi] = (int)result1UpDown2.Value;
                    Program.group1[jt].roll[pj] = (int)result1UpDown2.Value;
                    Program.group1[jt].miss[pj] = (int)result1UpDown1.Value;
                }
                else
                {
                    Program.group2[it].roll[pi] = (int)result1UpDown1.Value;
                    Program.group2[it].miss[pi] = (int)result1UpDown2.Value;
                    Program.group2[jt].roll[pj] = (int)result1UpDown2.Value;
                    Program.group2[jt].miss[pj] = (int)result1UpDown1.Value;
                }
                if (jt < 5)
                {
                    jt++;
                    pi++;
                }
                else
                    if (jt == 5)
                {
                    if (it < 2)
                    {
                        it++;
                        jt = 3;
                        pi = 3;
                        pj++;
                    }
                    else
                    {
                        it = 0;
                        jt = 3;
                        pi = 3;
                        pj = 0;
                        GroupNum++;
                    }
                }
            }
            if (GroupNum<=1)
            {
                if(GroupNum==0)
                {
                    group2NameLabel.Text = "Группа 1";
                    teamNameLabel1.Text = Program.group1[it].Name;
                    teamNameLabel2.Text = Program.group1[jt].Name;
                }
                else
                {
                    group2NameLabel.Text = "Группа 2";
                    teamNameLabel1.Text = Program.group2[it].Name;
                    teamNameLabel2.Text = Program.group2[jt].Name;
                }
            }
            else
            {
                nextTeam.Enabled = false;
                calcResult1Button.Visible = true;
            }
        }

        private void calcResult1Button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Program.group1.Length; i++)
                Program.group1[i].CalcWin1();
            for (int i = 0; i < Program.group2.Length; i++)
                Program.group2[i].CalcWin1();

            Array.Sort(Program.group1, new Comparison<Sportsman>(Sportsman.compareT));
            Array.Sort(Program.group2, new Comparison<Sportsman>(Sportsman.compareT));

            calcResult1Button.Enabled = false;
            showGroupButton1.Visible = true;
            showGroupButton2.Visible = true;
            nextRoundButton1.Visible = true;
        }

        private void nextRoundButton1_Click(object sender, EventArgs e)
        {
            mainTabs.SelectedIndex++;
            ik = 0;
            jk = 3;
            gr = 0;
            teamName1Label1.Text = Program.group1[ik].Name;
            teamName1Label2.Text = Program.group2[jk].Name;
        }

        private void nextTeam1_Click(object sender, EventArgs e)
        {
            {
                if(gr==0)
                {
                    Program.group1[ik].rubber = (int)result2UpDown1.Value;
                    Program.group2[jk].rubber = (int)result2UpDown2.Value;
                }
                if (ik < 3 && jk > 0)
                {
                    ik++;
                    jk--;
                }
                else gr++;
            }
                if (gr == 0)
                {
                    teamName1Label1.Text = Program.group1[ik].Name;
                    teamName1Label2.Text = Program.group2[jk].Name;
                }
                else
                {
                    nextTeam1.Enabled = false;
                    calcResult2Button.Visible = true;
                }
        }

        private void calcResult2Button_Click(object sender, EventArgs e)
        {
            Program.group = new Sportsman[4];
            if (Program.group1[0].rubber > Program.group2[3].rubber)
            {
                Program.group[0] = Program.group1[0];
                winner1Box.Text = Program.group1[0].Name;
            }
            else
            {
                Program.group[0] = Program.group2[3];
                winner1Box.Text = Program.group2[3].Name;
            }
            if (Program.group1[1].rubber > Program.group2[2].rubber)
            {
                Program.group[1] = Program.group1[1];
                winner2Box.Text = Program.group1[1].Name;
            }
            else
            {
                Program.group[1] = Program.group2[2];
                winner2Box.Text = Program.group2[2].Name;
            }
            if (Program.group1[2].rubber > Program.group2[1].rubber)
            {
                Program.group[2] = Program.group1[2];
                winner3Box.Text = Program.group1[2].Name;
            }
            else
            {
                Program.group[2] = Program.group2[1];
                winner3Box.Text = Program.group2[1].Name;
            }
            if (Program.group1[3].rubber > Program.group2[0].rubber)
            {
                Program.group[3] = Program.group1[3];
                winner4Box.Text = Program.group1[3].Name;
            }
            else
            {
                Program.group[3] = Program.group2[0];
                winner4Box.Text = Program.group2[0].Name;
            }
            winnersBox.Visible = true;
            nextRoundButton2.Visible = true;
        }

        private void nextRoundButton2_Click(object sender, EventArgs e)
        {
            mainTabs.SelectedIndex++;
            Random rnd = new Random();
            int rndNumber1, rndNumber2;
            Sportsman swap;

            for (int i = 0; i < 100; i++)
            {
                rndNumber1 = rnd.Next(0, 4);
                do rndNumber2 = rnd.Next(0, 4); while (rndNumber1 == rndNumber2);
                swap = Program.group[rndNumber1];
                Program.group[rndNumber1] = Program.group[rndNumber2];
                Program.group[rndNumber2] = swap;
            }
            z = 0; x = 0; y = 1;
            teamName2Label1.Text = Program.group[x].Name;
            teamName2Label2.Text = Program.group[y].Name;
        }

        private void nextTeam2_Click(object sender, EventArgs e)
        {
            {
                if (z == 0)
                {
                    Program.group[x].res = (int)result3UpDown1.Value;
                    Program.group[y].res = (int)result3UpDown2.Value;
                }
                if (x < 2 && y < 3)
                {
                    x=2;
                    y=3;
                }
                else
                    z++;
            }
            if (z == 0)
            {
                teamName2Label1.Text = Program.group[x].Name;
                teamName2Label2.Text = Program.group[y].Name;
            }
            else
            {
                nextTeam2.Enabled = false;
                calcResult3Button.Visible = true;
            }
        }

        private void calcResult3Button_Click(object sender, EventArgs e)
        {
            winnersBox1.Visible = true;
            nextRoundButton3.Visible = true;
            Program.final = new Sportsman[2];
            if (Program.group[0].res > Program.group[1].res)
            {
                Program.final[0] = Program.group[0];
                winnerBox1.Text = Program.group[0].Name;
            }
            else
            {
                Program.final[0] = Program.group[1];
                winnerBox1.Text = Program.group[1].Name;
            }
            if (Program.group[2].res > Program.group[3].res)
            {
                Program.final[1] = Program.group[2];
                winnerBox2.Text = Program.group[2].Name;
            }
            else
            {
                Program.final[1] = Program.group[3];
                winnerBox2.Text = Program.group[3].Name;
            }
        }

        private void nextRoundButton3_Click(object sender, EventArgs e)
        {
            mainTabs.SelectedIndex++;
            teamName3Label1.Text = Program.final[0].Name;
            teamName3Label2.Text = Program.final[1].Name;
        }

        private void result_Click(object sender, EventArgs e)
        {
            Program.final[0].fin = (int)result4UpDown1.Value;
            Program.final[1].fin = (int)result4UpDown2.Value;
            WINNERbox.Visible = true;
            if (Program.final[0].fin > Program.final[1].fin)
                winnerFinalBox.Text = Program.final[0].Name;
            else
                winnerFinalBox.Text = Program.final[1].Name;
        }
    }
}
