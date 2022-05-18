using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Dictionary<int, List<string>> people = new Dictionary<int, List<string>>(25);
        public static int isvisited;
        struct MyStruct
        {
            public static int[] group;
            public static string[] learningto;
            public static string[] pname;
            public static string[] pol;
            public static int[] yearofenter;
            public static string[] nationality;
            public static int[] stipen;
            public static string[] dateTimes;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            MyStruct.pname = new string[] {
            "andrey Иванов",
            "Александра Смирнов",
            "Алена Кузнецов",
            "Алина Попов",
            "Алиса Васильев",
            "Алла Петров",
            "Анастасия Соколов",
            "Ангелина Михайлов",
            "Анна Новиков",
            "Антонина Федоров",
            "Арина Морозов",
            "Валентина Волков",
            "Валерия Алексеев",
            "Варвара Лебедев",
            "Василиса Семенов",
            "Вера Егоров",
            "Вероника Павлов",
            "Виктория Козлов",
            "Галина Степанов",
            "Дарья Николаев",
            "Ева Орлов",
            "Евгения Андреев",
            "Евдокия Макаров",
            "Екатерина Никитин",
            "Елена Захаров",
            "Елизавета Зайцев",
            "Жанна Соловьев",
            "Зинаида Борисов",
            "Злата Яковлев",
            "Зоя Григорьев",
            "Иванна Романов",
            "Ирина Воробьев",
            "Ия  Сергеев",
            "Кира Кузьмин",
            "Кристина Казаков",
            "Ксения Афанасьев",
            "Лидия Данилов",
            "Любовь Тимофеев",
            "Людмила Фомин",
            "Маргарита Чернов",
            "Марина Абрамов",
            "Мария Мартынов",
            "Милана Ефимов",
            "Надежда Федотов",
            "Наталья Щербаков",
            "Нина Назаров",
            "Ольга Калинин",
            "Полина Исаев",
            "Раиса Чернышев",
            "Светлана Быков",
            "София Маслов"
        };
            MyStruct.pol = new string[] { "мужской", "женской" };
            MyStruct.group = new int[] { 101, 102, 103, 104, 105, 106 };
            MyStruct.learningto = new string[] { "программная инженерия", "ПМиИТ", "ФМиИТ", "ИБ", "Химия Физика", "Приклодная Химия" };
            MyStruct.yearofenter = new int[] { 2018, 2019, 2020, 2021, 2022 };
            MyStruct.nationality = new string[] { "таджик", "туркмен", "русский", "узбек", "казах", "индейц", "китайц", "корейц" };
            MyStruct.stipen = new int[] { 2300, 1800, 2000, 2500 };
            MyStruct.dateTimes = new string[] { "1995,06,20", "1999,06,26", "2003,03,07", "2001,02,25", "2002,12,15", "2001,01,03", "2004,01,15" };
            dataGridView1.ColumnCount = 8;
            dataGridView1.Columns[0].Name = "ФИО";
            dataGridView1.Columns[1].Name = "Группа";
            dataGridView1.Columns[2].Name = "Направление подготовки";
            dataGridView1.Columns[3].Name = "Год поступление";
            dataGridView1.Columns[4].Name = "Пол";
            dataGridView1.Columns[5].Name = "Национальность";
            dataGridView1.Columns[6].Name = "Дата рождение";
            dataGridView1.Columns[7].Name = "Размер стипендии";
            var random = new Random();
            dataGridView1.RowCount = MyStruct.pname.Length;
            for (int item = 0; item < MyStruct.pname.Length; item++)
            {
                people.Add(item, new List<string> {
                    MyStruct.pname[item],
                    Convert.ToString( MyStruct.group[random.Next(0,MyStruct.group.Length)]),
                    MyStruct.learningto[random.Next(0, MyStruct.learningto.Length)],
                    Convert.ToString(MyStruct.yearofenter[random.Next(0, MyStruct.yearofenter.Length)]),
                    MyStruct.pol[random.Next(0, MyStruct.pol.Length)],
                    MyStruct.nationality[random.Next(0, MyStruct.nationality.Length)],
                    MyStruct.dateTimes[random.Next(0, MyStruct.dateTimes.Length)],
                    MyStruct.stipen[random.Next(0,MyStruct.stipen.Length)].ToString()
                });
                dataGridView1.Rows[item].Cells[0].Value = people[item][0];
                dataGridView1.Rows[item].Cells[1].Value = people[item][1];
                dataGridView1.Rows[item].Cells[2].Value = people[item][2];
                dataGridView1.Rows[item].Cells[3].Value = people[item][3];
                dataGridView1.Rows[item].Cells[4].Value = people[item][4];
                dataGridView1.Rows[item].Cells[5].Value = people[item][5];
                dataGridView1.Rows[item].Cells[6].Value = people[item][6];
                dataGridView1.Rows[item].Cells[7].Value = people[item][7];
            }
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex.ToString() == "0" && e.RowIndex >= 0)
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                isvisited = e.RowIndex;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox9.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                dataGridView1.Rows.Add(textBox2.Text);
                dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[1].Value = textBox3.Text;
                dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[2].Value = textBox4.Text;
                dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[3].Value = textBox5.Text;
                dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[4].Value = comboBox1.Text;
                dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[5].Value = textBox7.Text;
                dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[6].Value = textBox6.Text;
                dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[7].Value = textBox9.Text;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                dataGridView1.Rows.RemoveAt(isvisited);
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                dataGridView1.Rows[isvisited].Cells[1].Value = textBox3.Text;
                dataGridView1.Rows[isvisited].Cells[2].Value = textBox4.Text;
                dataGridView1.Rows[isvisited].Cells[3].Value = textBox5.Text;
                dataGridView1.Rows[isvisited].Cells[4].Value = comboBox1.Text;
                dataGridView1.Rows[isvisited].Cells[5].Value = textBox7.Text;
                dataGridView1.Rows[isvisited].Cells[6].Value = textBox6.Text;
                dataGridView1.Rows[isvisited].Cells[7].Value = textBox9.Text;
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                string searchword = Interaction.InputBox("напишите имя для поиска!");
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.RowCount = people.Count();
                dataGridView1.ColumnCount = 8;
                dataGridView1.Columns[0].Name = "ФИО";
                dataGridView1.Columns[1].Name = "Группа";
                dataGridView1.Columns[2].Name = "Направление подготовки";
                dataGridView1.Columns[3].Name = "Год поступление";
                dataGridView1.Columns[4].Name = "Пол";
                dataGridView1.Columns[5].Name = "Национальность";
                dataGridView1.Columns[6].Name = "Дата рождение";
                dataGridView1.Columns[7].Name = "Размер стипендии";
                int index = 0;
                if (searchword.IndexOf("group:") > -1)
                {
                    searchword = searchword.Remove(0, 6);
                    if (searchword.IndexOf("&") > -1 && searchword.IndexOf("<") < 0 && searchword.IndexOf(">") < 0)
                    {
                        int f = Convert.ToInt16(searchword.Split('&')[0]), s = Convert.ToInt16(searchword.Split('&')[1]);
                        if (f < s)
                        {
                            for (int i = 0; i < people.Count; i++)
                            {
                                if (Convert.ToInt16(people[i].ToList()[1]) >= f && Convert.ToInt16(people[i].ToList()[1]) <= s)
                                {
                                    dataGridView1.Rows[index].Cells[0].Value = people[i].ToList()[0];
                                    dataGridView1.Rows[index].Cells[1].Value = people[i].ToList()[1];
                                    dataGridView1.Rows[index].Cells[2].Value = people[i].ToList()[2];
                                    dataGridView1.Rows[index].Cells[3].Value = people[i].ToList()[3];
                                    dataGridView1.Rows[index].Cells[4].Value = people[i].ToList()[4];
                                    dataGridView1.Rows[index].Cells[5].Value = people[i].ToList()[5];
                                    dataGridView1.Rows[index].Cells[6].Value = people[i].ToList()[6];
                                    dataGridView1.Rows[index].Cells[7].Value = people[i].ToList()[7];
                                    isvisited = i;
                                    index++;
                                }
                            }
                        }
                    }
                    else if (searchword.IndexOf("<") < 0 && searchword.IndexOf(">") > -1 && searchword.IndexOf("&") < 0)
                    {
                        int f = Convert.ToInt16(searchword.Split('>')[1]);
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (Convert.ToInt16(people[i].ToList()[1]) >= f)
                            {
                                dataGridView1.Rows[index].Cells[0].Value = people[i].ToList()[0];
                                dataGridView1.Rows[index].Cells[1].Value = people[i].ToList()[1];
                                dataGridView1.Rows[index].Cells[2].Value = people[i].ToList()[2];
                                dataGridView1.Rows[index].Cells[3].Value = people[i].ToList()[3];
                                dataGridView1.Rows[index].Cells[4].Value = people[i].ToList()[4];
                                dataGridView1.Rows[index].Cells[5].Value = people[i].ToList()[5];
                                dataGridView1.Rows[index].Cells[6].Value = people[i].ToList()[6];
                                dataGridView1.Rows[index].Cells[7].Value = people[i].ToList()[7];
                                isvisited = i;
                                index++;
                            }
                        }
                    }
                    else if (searchword.IndexOf(">") < 0 && searchword.IndexOf("<") > -1 && searchword.IndexOf("&") < 0)
                    {
                        int f = Convert.ToInt16(searchword.Split('<')[1]);
                        for (int i = 0; i < people.Count; i++)
                        {
                            if (Convert.ToInt16(people[i].ToList()[1]) <= f)
                            {
                                dataGridView1.Rows[index].Cells[0].Value = people[i].ToList()[0];
                                dataGridView1.Rows[index].Cells[1].Value = people[i].ToList()[1];
                                dataGridView1.Rows[index].Cells[2].Value = people[i].ToList()[2];
                                dataGridView1.Rows[index].Cells[3].Value = people[i].ToList()[3];
                                dataGridView1.Rows[index].Cells[4].Value = people[i].ToList()[4];
                                dataGridView1.Rows[index].Cells[5].Value = people[i].ToList()[5];
                                dataGridView1.Rows[index].Cells[6].Value = people[i].ToList()[6];
                                dataGridView1.Rows[index].Cells[7].Value = people[i].ToList()[7];
                                isvisited = i;
                                index++;
                            }
                        }
                    }
                }
                else if (searchword.IndexOf("birthday:") > -1)
                {
                    searchword = searchword.Remove(0, 9);
                    if (searchword.IndexOf("<") < 0 && searchword.IndexOf(">") > -1 && searchword.IndexOf("&") < 0)
                    {
                        searchword = searchword.Remove(0, 1);
                        for (int i = 0; i < people.Count; i++)
                        {
                            string s = people[i].ToList()[6];
                            int y = Convert.ToInt32(s.Split(',')[0]), m = Convert.ToInt32(s.Split(',')[1]), d = Convert.ToInt32(s.Split(',')[2]);
                            int y1 = Convert.ToInt32(searchword.Split(',')[0]), m1 = Convert.ToInt32(searchword.Split(',')[1]), d1 = Convert.ToInt32(searchword.Split(',')[2]);
                            if (int.Parse(y.ToString() + m.ToString() + d.ToString()) >= int.Parse(y1.ToString() + m1.ToString() + d1.ToString()))
                            {
                                dataGridView1.Rows[index].Cells[0].Value = people[i].ToList()[0];
                                dataGridView1.Rows[index].Cells[1].Value = people[i].ToList()[1];
                                dataGridView1.Rows[index].Cells[2].Value = people[i].ToList()[2];
                                dataGridView1.Rows[index].Cells[3].Value = people[i].ToList()[3];
                                dataGridView1.Rows[index].Cells[4].Value = people[i].ToList()[4];
                                dataGridView1.Rows[index].Cells[5].Value = people[i].ToList()[5];
                                dataGridView1.Rows[index].Cells[6].Value = people[i].ToList()[6];
                                dataGridView1.Rows[index].Cells[7].Value = people[i].ToList()[7];
                                isvisited = i;
                                index++;
                            }

                        }
                    }
                    else if (searchword.IndexOf(">") < 0 && searchword.IndexOf("<") > -1 && searchword.IndexOf("&") < 0)
                    {
                        searchword = searchword.Remove(0, 1);
                        for (int i = 0; i < people.Count; i++)
                        {
                            string s = people[i].ToList()[6];
                            string tr = s.Split(',')[0] + s.Split(',')[1] + s.Split(',')[2], tr1 = searchword.Split(',')[0] + searchword.Split(',')[1] + searchword.Split(',')[2];
                            if (int.Parse(tr) <= int.Parse(tr1))
                            {
                                dataGridView1.Rows[index].Cells[0].Value = people[i].ToList()[0];
                                dataGridView1.Rows[index].Cells[1].Value = people[i].ToList()[1];
                                dataGridView1.Rows[index].Cells[2].Value = people[i].ToList()[2];
                                dataGridView1.Rows[index].Cells[3].Value = people[i].ToList()[3];
                                dataGridView1.Rows[index].Cells[4].Value = people[i].ToList()[4];
                                dataGridView1.Rows[index].Cells[5].Value = people[i].ToList()[5];
                                dataGridView1.Rows[index].Cells[6].Value = people[i].ToList()[6];
                                dataGridView1.Rows[index].Cells[7].Value = people[i].ToList()[7];
                                isvisited = i;
                                index++;
                            }

                        }
                    }
                    else if (searchword.IndexOf(">") < 0 && searchword.IndexOf("<") < 0 && searchword.IndexOf("&") > -1)
                    {
                        string f = searchword.Split('&')[0], s = searchword.Split('&')[1];
                        int nt = Convert.ToInt32(f.Split(',')[0] + f.Split(',')[1] + f.Split(',')[2]), nt1 = Convert.ToInt32(s.Split(',')[0] + s.Split(',')[1] + s.Split(',')[2]);
                        if (nt < nt1)
                        {
                            for (int i = 0; i < people.Count; i++)
                            {
                                if (Convert.ToInt32(people[i].ToList()[6].Split(',')[0] + people[i].ToList()[6].Split(',')[1] + people[i].ToList()[6].Split(',')[2]) >= nt && Convert.ToInt32(people[i].ToList()[6].Split(',')[0] + people[i].ToList()[6].Split(',')[1] + people[i].ToList()[6].Split(',')[2]) <= nt1)
                                {
                                    dataGridView1.Rows[index].Cells[0].Value = people[i].ToList()[0];
                                    dataGridView1.Rows[index].Cells[1].Value = people[i].ToList()[1];
                                    dataGridView1.Rows[index].Cells[2].Value = people[i].ToList()[2];
                                    dataGridView1.Rows[index].Cells[3].Value = people[i].ToList()[3];
                                    dataGridView1.Rows[index].Cells[4].Value = people[i].ToList()[4];
                                    dataGridView1.Rows[index].Cells[5].Value = people[i].ToList()[5];
                                    dataGridView1.Rows[index].Cells[6].Value = people[i].ToList()[6];
                                    dataGridView1.Rows[index].Cells[7].Value = people[i].ToList()[7];
                                    isvisited = i;
                                    index++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        if (MyStruct.pname[i].IndexOf(searchword) > -1 && searchword != "")
                        {
                            dataGridView1.Rows[index].Cells[0].Value = people[i].ToList()[0];
                            dataGridView1.Rows[index].Cells[1].Value = people[i].ToList()[1];
                            dataGridView1.Rows[index].Cells[2].Value = people[i].ToList()[2];
                            dataGridView1.Rows[index].Cells[3].Value = people[i].ToList()[3];
                            dataGridView1.Rows[index].Cells[4].Value = people[i].ToList()[4];
                            dataGridView1.Rows[index].Cells[5].Value = people[i].ToList()[5];
                            dataGridView1.Rows[index].Cells[6].Value = people[i].ToList()[6];
                            dataGridView1.Rows[index].Cells[7].Value = people[i].ToList()[7];
                            isvisited = i;
                            index++;
                        }
                        else if (searchword == "")
                        {
                            dataGridView1.Rows[i].Cells[0].Value = people[i].ToList()[0];
                            dataGridView1.Rows[i].Cells[1].Value = people[i].ToList()[1];
                            dataGridView1.Rows[i].Cells[2].Value = people[i].ToList()[2];
                            dataGridView1.Rows[i].Cells[3].Value = people[i].ToList()[3];
                            dataGridView1.Rows[i].Cells[4].Value = people[i].ToList()[4];
                            dataGridView1.Rows[i].Cells[5].Value = people[i].ToList()[5];
                            dataGridView1.Rows[i].Cells[6].Value = people[i].ToList()[6];
                            dataGridView1.Rows[i].Cells[7].Value = people[i].ToList()[7];
                            isvisited = i;
                        }

                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ischoosed = comboBox3.SelectedIndex;
            switch (ischoosed)
            {
                case 0:
                    dataGridView2.Columns.Clear();
                    dataGridView2.Rows.Clear();
                    dataGridView2.RowCount = 1;
                    double sred = 0, countp = 0;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[7].Value != null) { sred += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value); countp++; } else break;
                    }
                    dataGridView2.Columns[0].Name = "средная стипендия";
                    dataGridView2.Rows[0].Cells[0].Value = sred / countp;
                    break;

                case 1:

                    dataGridView2.Rows.Clear();
                    dataGridView2.RowCount = 2;
                    dataGridView2.ColumnCount = 10;

                    int countw = 0, countm = 0;
                    for (int i = 0; i < MyStruct.nationality.Length; i++)
                    {
                        countw = 0; countm = 0;
                        for (int j = 0; j < dataGridView1.RowCount; j++)
                        {
                            string s1 = dataGridView1.Rows[j].Cells[5].Value.ToString(), s2 = MyStruct.nationality[i];
                            if (s1 == s2 && i != j)
                            {
                                if (dataGridView1.Rows[j].Cells[4].Value.ToString() == "мужской")
                                    countm++;
                                else if (dataGridView1.Rows[j].Cells[4].Value.ToString() == "женской")
                                    countw++;

                            }

                        }
                        dataGridView2.Columns[i + 1].Name = MyStruct.nationality[i];
                        dataGridView2.Rows[0].Cells[i + 1].Value = countm;
                        dataGridView2.Rows[1].Cells[i + 1].Value = countw;
                    }
                    dataGridView2.Columns[0].Name = "Пол";
                    dataGridView2.Rows[0].Cells[0].Value = "мужской";
                    dataGridView2.Rows[1].Cells[0].Value = "женской";
                    break;

                case 2:
                    dataGridView2.Rows.Clear();
                    dataGridView2.ColumnCount = 2;
                    dataGridView2.RowCount = MyStruct.group.Length;
                    for (int i = 0; i < MyStruct.group.Length; i++)
                    {
                        int count = 0;
                        int j = 0;
                        while (dataGridView1.Rows[j].Cells[1].Value != null)
                        {
                            if (MyStruct.group[i].ToString() == dataGridView1.Rows[j].Cells[1].Value.ToString())
                            {
                                count++;
                            }
                            j++;
                        }
                        dataGridView2.Columns[0].Name = "группа";
                        dataGridView2.Columns[1].Name = "кол-ва учеников";
                        dataGridView2.Rows[i].Cells[0].Value = MyStruct.group[i].ToString();
                        dataGridView2.Rows[i].Cells[1].Value = count;
                    }
                    break;

                case 3:
                    dataGridView2.Rows.Clear();
                    dataGridView2.Columns.Clear();
                    dataGridView2.RowCount = 7;
                    dataGridView2.ColumnCount = 3;
                    dataGridView2.Columns[0].Name = "размер стипендии";
                    dataGridView2.Columns[1].Name = "кол-ва учеников";
                    dataGridView2.Columns[2].Name = "процент";
                    dataGridView2.Rows[0].Cells[0].Value = "<500";
                    dataGridView2.Rows[1].Cells[0].Value = "500-1000";
                    dataGridView2.Rows[2].Cells[0].Value = "1001-1500";
                    dataGridView2.Rows[3].Cells[0].Value = "1501-2000";
                    dataGridView2.Rows[4].Cells[0].Value = "2001-2500";
                    dataGridView2.Rows[5].Cells[0].Value = ">2500";
                    dataGridView2.Rows[6].Cells[0].Value = "всего";

                    int l_500 = 1, l_500to1000 = 2, l_1001to1500 = 3, l_1501to2000 = 4, l_2001to2500 = 5, l_2500 = 6;

                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        int st = (int)dataGridView1.Rows[i].Cells[7].Value;
                        if (st < 500)
                        {
                            l_500++;
                        }
                        else if (500 < st && st < 1000)
                        {
                            l_500to1000++;
                        }
                        else if (1001 < st && st < 1500)
                        {
                            l_1001to1500++;
                        }
                        else if (1501 < st && st < 2000)
                        {
                            l_1501to2000++;
                        }
                        else if (2001 < st && st < 2500)
                        {
                            l_2001to2500++;
                        }
                        else if (2500 < st)
                        {
                            l_2500++;
                        }
                    }
                    dataGridView2.Rows[0].Cells[1].Value = l_500.ToString();
                    dataGridView2.Rows[1].Cells[1].Value = l_500to1000.ToString();
                    dataGridView2.Rows[2].Cells[1].Value = l_1001to1500.ToString();
                    dataGridView2.Rows[3].Cells[1].Value = l_1501to2000.ToString();
                    dataGridView2.Rows[4].Cells[1].Value = l_2001to2500.ToString();
                    dataGridView2.Rows[5].Cells[1].Value = l_2500.ToString();
                    break;
                default:
                    break;
            }
        }

  
    }
}