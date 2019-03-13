using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mo_lab3
{
    public partial class Form1 : Form
    {
        double c1, c2, c3, c4, c5, c6;

        private void button3_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);

            textBox8.AppendText("y[" + Convert.ToString(x) + "] = " + Convert.ToString(((x * x - 5) / (x - 3))) + "\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search s = new Search(-1000, 1000, -1);
            Search s2 = new Search(-1000, 1000, 1);

            for (int i = 0; i < 20; i++)
            {
                textBox8.AppendText("x[" + Convert.ToString(i) + "] = " + Convert.ToString(s.iter()) + "\n");
            }

            for (int i = 0; i < 20; i++)
            {
                textBox8.AppendText("x[" + Convert.ToString(i) + "] = " + Convert.ToString(s2.iter()) + "\n");
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        double func(double x1, double x2, double x3, double x4, double x5, double x6, int i, double r) //Расчет значения вектора в заданной точке пространства
        {
            double res = 0;

            switch(i)
            {
                case 0:
                    {
                        res = (c1 * r) + (c2 * x2) + (c3 * x3) + (c4 * x4) + (c5 * x5) + (c6 * x6);
                        break;
                    }
                case 1:
                    {
                        res = (c1 * x1) + (c2 * r) + (c3 * x3) + (c4 * x4) + (c5 * x5) + (c6 * x6);
                        break;
                    }
                case 2:
                    {
                        res = (c1 * x1) + (c2 * x2) + (c3 * r) + (c4 * x4) + (c5 * x5) + (c6 * x6);
                        break;
                    }
                case 3:
                    {
                        res = (c1 * x1) + (c2 * x2) + (c3 * x3) + (c4 * r) + (c5 * x5) + (c6 * x6);
                        break;
                    }
                case 4:
                    {
                        res = (c1 * x1) + (c2 * x2) + (c3 * x3) + (c4 * x4) + (c5 * r) + (c6 * x6);
                        break;
                    }
                case 5:
                    {
                        res = (c1 * x1) + (c2 * x2) + (c3 * x3) + (c4 * x4) + (c5 * x5) + (c6 * r);
                        break;
                    }
                default:
                    {
                        res = (c1 * x1) + (c2 * x2) + (c3 * x3) + (c4 * x4) + (c5 * x5) + (c6 * x6);
                        break;
                    }
            }

            return res; //((c1 * x1) + (c2 * x2) + (c3 * x3) + (c4 * x4) + (c5 * x5) + (c6 * x6))
        }

        void getC() //Считывание коэффициентов
        {
            c1 = Convert.ToDouble(textBox1.Text);
            c2 = Convert.ToDouble(textBox2.Text);
            c3 = Convert.ToDouble(textBox3.Text);
            c4 = Convert.ToDouble(textBox4.Text);
            c5 = Convert.ToDouble(textBox5.Text);
            c6 = Convert.ToDouble(textBox6.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false; //Было ли найдено решение
            double r, prev = 0;
            double eps = Convert.ToDouble(textBox7.Text);
            double min; //Минимальное найденное значение функции
            List<double> x = new List<double>(); //Список коэффициентов при элементах вектора
            List<Search> s = new List<Search>(); //Список объектов класса Search для поиска значений x методом дихотомии

            {
                double a, b; //Запись значений коэффициентов x и диапазона для поиска минимума или максимума
                a = Convert.ToDouble(textBox9.Text);
                b = Convert.ToDouble(textBox10.Text);

                Search p = new Search(a, b, Convert.ToDouble(textBox1.Text));
                s.Add(p);

                p = new Search(a, b, Convert.ToDouble(textBox2.Text));
                s.Add(p);

                p = new Search(a, b, Convert.ToDouble(textBox3.Text));
                s.Add(p);

                p = new Search(a, b, Convert.ToDouble(textBox4.Text));
                s.Add(p);

                p = new Search(a, b, Convert.ToDouble(textBox5.Text));
                s.Add(p);

                p = new Search(a, b, Convert.ToDouble(textBox6.Text));
                s.Add(p);
            }


            for(int i = 0; i < 6; i++)
            {
                x.Add(1);
            }

            getC();

            min = func(x[0], x[1], x[2], x[3], x[4], x[5], -1, -1);
            prev = func(x[0], x[1], x[2], x[3], x[4], x[5], -1, -1);

            int k = 0; //Количество итераций
            int c = 0; //Количество вычислений

            while (k < 1000 && !flag)
            {
                k++;
                for(int i = 0; i < 6; i++)
                {
                    //Random rand = new Random(i + k + Convert.ToInt32(DateTime.Now.Millisecond)); //Генерация случайного числа из диапазона
                    //r = rand.Next(-1000, 1000);
                    //Random rand2 = new Random(i + k + Convert.ToInt32(DateTime.Now.Millisecond)); ;
                    //r += rand.Next(0, 100) / 100.00;
                    //x[i] = r;

                    x[i] = s[i].iter(); //Итерация поиска максимума или минимума из заданного диапазона с учетом коэффициента при x[i]
                    min = func(x[0], x[1], x[2], x[3], x[4], x[5], -1, -1);

                    c += 2;
                    if (Math.Abs(prev - min) <= eps) //Если решение найдено, прекращаем поиск
                    {
                        flag = true;
                        break;
                    }
                }

                prev = min; //Запоминиаем предыдущее значение
            }

            textBox8.Text = "";
            textBox8.AppendText("Количество итераций: " + k + "\n");
            textBox8.AppendText("Количество вычислений: " + c + "\n");
            textBox8.AppendText("Полученное минимальное значение функции: " + Convert.ToString(func(x[0], x[1], x[2], x[3], x[4], x[5], -1, -1)) + "\n");
            textBox8.AppendText("Предыдущее минимальное значение: " + Convert.ToString(prev) + "\n");

            for (int i = 0; i < 6; i++)
            {
                textBox8.AppendText("x" + Convert.ToString(i + 1) + " = " + Convert.ToString(x[i]) + "; \n");
            }
        }
    }
}
