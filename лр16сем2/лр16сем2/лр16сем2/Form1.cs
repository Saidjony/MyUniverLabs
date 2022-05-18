using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лр16сем2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        struct MyDateTime
        {
            public static string hours, minutes, seconds, h1, m1, s1;
            public static string gettime() { return $"{hours}:{minutes}:{seconds} {ampm}"; }
            public static string ampm;
            public static string difftime;
            public static string timelevel;
            public static int converttodate;
            public static string conv_int_to_date;
            public static string crement;
        }
        class MyClass
        {

            public int hour = Convert.ToInt32(MyDateTime.hours), minute = Convert.ToInt32(MyDateTime.minutes), second = Convert.ToInt32(MyDateTime.seconds);
            public int hour1 = Convert.ToInt32(MyDateTime.h1), minute1 = Convert.ToInt32(MyDateTime.m1), second1 = Convert.ToInt32(MyDateTime.s1);

            public void correcttime()
            {

                if (hour >= 0 && hour <= 12) { MyDateTime.ampm = "am"; } else { MyDateTime.ampm = "pm"; MyDateTime.hours = (hour - 12).ToString(); }
                if (hour.ToString().Length < 2) MyDateTime.hours = "0" + MyDateTime.hours;
                if (minute.ToString().Length < 2) MyDateTime.minutes = "0" + MyDateTime.minutes;
                if (second.ToString().Length < 2) MyDateTime.seconds = "0" + MyDateTime.seconds;

                if (hour1.ToString().Length < 2) MyDateTime.h1 = "0" + MyDateTime.h1;
                if (minute1.ToString().Length < 2) MyDateTime.m1 = "0" + MyDateTime.m1;
                if (second1.ToString().Length < 2) MyDateTime.s1 = "0" + MyDateTime.s1;

                if (MyDateTime.crement.Split(':')[0].Length < 2) MyDateTime.crement = MyDateTime.crement.Insert(0, "0");
                if (MyDateTime.crement.Split(':')[1].Length < 2) MyDateTime.crement = MyDateTime.crement.Insert(3, "0");
                if (MyDateTime.crement.Split(':')[2].Length < 2) MyDateTime.crement = MyDateTime.crement.Insert(6, "0");

            }
            public void findtimelevel()
            {
                int h = hour;
                if (MyDateTime.ampm == "am" && h > 5 && h < 10) MyDateTime.timelevel = "утро";
                else if (MyDateTime.ampm == "am" && h > 16 && h < 20) MyDateTime.timelevel = "вечер";
                else if (MyDateTime.ampm == "pm") MyDateTime.timelevel = "ночь";

            }
            public void differ()
            {
                MyDateTime.difftime = diff(hour, minute, second, hour1, minute1, second1);
                int h = MyDateTime.converttodate / 3600; MyDateTime.converttodate %= 3600;
                int m = MyDateTime.converttodate / 60; MyDateTime.converttodate %= 60;
                int s = MyDateTime.converttodate;
                MyDateTime.conv_int_to_date = $"{h}:{m}:{s}";
            }

            public void crem()
            {
                MyDateTime.crement = crement(hour, minute, second);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyClass myClass = new MyClass();
            string date = textBox1.Text, date2 = textBox2.Text;
            MyDateTime.hours = date.Split()[0]; MyDateTime.minutes = date.Split()[1]; MyDateTime.seconds = date.Split()[2];
            MyDateTime.h1 = date2.Split()[0]; MyDateTime.m1 = date2.Split()[1]; MyDateTime.s1 = date2.Split()[2];
            MyDateTime.converttodate = int.Parse(textBox3.Text);
            myClass.hour = Convert.ToInt32(date.Split()[0]); myClass.minute = Convert.ToInt32(date.Split()[1]); myClass.second = Convert.ToInt32(date.Split()[2]);
            myClass.hour1 = Convert.ToInt32(date2.Split()[0]); myClass.minute1 = Convert.ToInt32(date2.Split()[1]); myClass.second1 = Convert.ToInt32(date2.Split()[2]);

            myClass.differ();
            myClass.findtimelevel();
            myClass.crem();
            myClass.correcttime();
            label6.Text = "разница часов   " + MyDateTime.difftime;
            label3.Text = $"время1     {MyDateTime.hours}:{MyDateTime.minutes}:{MyDateTime.seconds}";
            label5.Text = $"время2 {MyDateTime.h1}:{MyDateTime.m1}:{MyDateTime.s1}";
            label10.Text = compare(Convert.ToInt32(MyDateTime.hours), Convert.ToInt32(MyDateTime.minutes), Convert.ToInt32(MyDateTime.seconds), Convert.ToInt32(MyDateTime.h1), Convert.ToInt32(MyDateTime.m1), Convert.ToInt32(MyDateTime.s1));
            label9.Text = "время суток " + MyDateTime.timelevel + "  " + MyDateTime.ampm;
            label12.Text = "сложение времени     " + summ(Convert.ToInt32(MyDateTime.hours), Convert.ToInt32(MyDateTime.minutes), Convert.ToInt32(MyDateTime.seconds), Convert.ToInt32(MyDateTime.h1), Convert.ToInt32(MyDateTime.m1), Convert.ToInt32(MyDateTime.s1));
            label11.Text = "время после инкремента   " + MyDateTime.crement;

            label8.Text = "время   " + MyDateTime.conv_int_to_date;

        }
        public static string diff(int h, int m, int s, int h1, int m1, int s1)
        {
            int contos = h * 3600 + m * 60 + s, contos1 = h1 * 3600 + m1 * 60 + s1;
            int diff = contos - contos1;
            int hour = diff / 3600; diff %= 3600;
            int minute = diff / 60; diff %= 60;
            int sec = diff;
            return $"{hour}:{minute}:{sec}";
        }
        public static string compare(int h, int m, int s, int h1, int m1, int s1)
        {
            if (h > h1) return ">"; else if (h < h1) return "<";
            if (m > m1) return ">"; else if (m < m1) return "<";
            if (s > s1) return ">"; else if (s < s1) return "<";

            return "=";
        }
        public static string crement(int h, int m, int s)
        {
            int h1 = h + 1;
            int m1 = m + 1;
            int s1 = s + 1;
            if (s1 > 59) { s1 -= 60; m1++; }
            if (m1 > 59) { m1 -= 60; h1++; }
            if (h1 > 23) { h1 -= 24; }
            return $"{h1}:{m1}:{s1}";
        }
        public static string summ(int h, int m, int s, int h1, int m1, int s1)
        {
            h += h1;
            m += m1;
            s += s1;
            if (s > 59) { s -= 60; m++; }
            if (m > 59) { m -= 60; h++; }
            if (h > 23) { h -= 24; }
            return $"{h} {m} {s}";
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
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        public class myclass
        {
            public int agewhenenter(int yearofenter,int birth )
            {
               return yearofenter-birth;
            }
            public int sumstipen(int yearofenter,int stipen)
            {
                return (2022 - yearofenter) * stipen * 9;
            }
            public int currrentsemestr(int yearofinter)
            {
                return 2022 - yearofinter;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myclass myclass = new myclass();
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
            dataGridView1.ColumnCount = 11;
            dataGridView1.Columns[0].Name = "ФИО";
            dataGridView1.Columns[1].Name = "Группа";
            dataGridView1.Columns[2].Name = "Направление подготовки";
            dataGridView1.Columns[3].Name = "Год поступление";
            dataGridView1.Columns[4].Name = "Пол";
            dataGridView1.Columns[5].Name = "Национальность";
            dataGridView1.Columns[6].Name = "Дата рождение";
            dataGridView1.Columns[7].Name = "Размер стипендии";
            dataGridView1.Columns[8].Name = "Возраст на момент поступления";
            dataGridView1.Columns[9].Name = "Сумма на выплату стипендии за все годы обучения";
            dataGridView1.Columns[10].Name = "Текущий семестр";

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
                dataGridView1.Rows[item].Cells[8].Value =  myclass.agewhenenter(int.Parse(dataGridView1.Rows[item].Cells[3].Value.ToString()),int.Parse(dataGridView1.Rows[item].Cells[6].Value.ToString().Split(',')[0])).ToString();
                dataGridView1.Rows[item].Cells[9].Value = myclass.sumstipen(int.Parse(dataGridView1.Rows[item].Cells[3].Value.ToString()), int.Parse(dataGridView1.Rows[item].Cells[7].Value.ToString())).ToString();
                dataGridView1.Rows[item].Cells[10].Value = myclass.currrentsemestr(int.Parse(dataGridView1.Rows[item].Cells[3].Value.ToString()))+1;
            }
        }
    }
}