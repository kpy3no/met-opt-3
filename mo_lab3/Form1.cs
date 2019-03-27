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

        double func(double x1, double x2, double x3, double x4, double x5, double x6) //Расчет значения функция
        {
            return (c1 * x1 * x2) + (c2 * x2) + (c3 * x3) + (c4 * x4) + (c5 * x5) + (c6 * x6);
        }

        double func2(double x1, double x2) //Расчет значения функция
        {
            return Math.Pow(x1*x1 + x2 - 11, 2) + Math.Pow(x1 + x2*x2 - 7, 2);
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
            int n = 2;
            bool flag = false; //Было ли найдено решение
            double r, prev = 0;
            double eps = Convert.ToDouble(txtBoxE.Text);
            double min; //Минимальное найденное значение функции
            List<double> x = new List<double>(); //Список коэффициентов при элементах вектора
            List<Search> s = new List<Search>(); //Список объектов класса Search для поиска значений x методом дихотомии

            {
                double a, b; //Запись значений коэффициентов x и диапазона для поиска минимума или максимума
                a = Convert.ToDouble(txtBoxA.Text);
                b = Convert.ToDouble(txtBoxB.Text);

                Search p = new Search(a, b, Convert.ToDouble(textBox1.Text));
                s.Add(p);

                p = new Search(a, b, Convert.ToDouble(textBox2.Text));
                s.Add(p);
            }


            for(int i = 0; i < 2; i++)
            {
                x.Add(1);
            }

            getC();

            min = func2(x[0], x[1]);
            prev = min;

            int k = 0; //Количество итераций
            int c = 0; //Количество вычислений

            while (k < 1000 && !flag)
            {
                k++;
                for(int i = 0; i < n; i++)
                {

                    x[i] = s[i].iter(); //Итерация поиска максимума или минимума из заданного диапазона с учетом коэффициента при x[i]
                    min = func2(x[0], x[1]);

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
            textBox8.AppendText("Полученное минимальное значение функции: " + Convert.ToString(func2(x[0], x[1])) + "\n");
            textBox8.AppendText("Предыдущее минимальное значение: " + Convert.ToString(prev) + "\n");

            for (int i = 0; i < 6; i++)
            {
                textBox8.AppendText("x" + Convert.ToString(i + 1) + " = " + Convert.ToString(x[i]) + "; \n");
            }
        }
    }
}
