using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mo_lab3
{
    class Search
    {
        bool flag; //False - поиск минимума, true - поиск максимума
        double a, b;
        double d = 0.001;
        double x_1, x_2;
        public double xn;

        public Search()
        {

        }

        public Search(double a, double b, double xn)
        {
            this.a = a;
            this.b = b;
            this.xn = xn;

            if(xn > 0) //Если коэффициент больше нуля, ищем минимум функции, иначе ищем максимум
            {
                flag = false;
            }
            else if(xn < 0)
            {
                flag = true;
            }
        }

        public double iter()
        {
            if (xn != 0)
            {
                if (flag == false) //Поиск минимума
                {
                    x_1 = ((a + b) - d) / 2;
                    x_2 = ((a + b) + d) / 2;

                    if (x_1 < x_2)
                    {
                        b = x_2;
                    }
                    else
                    {
                        a = x_1;
                    }
                }
                else if (flag == true) //Поиск максимума
                {
                    x_1 = ((a + b) + d) / 2;
                    x_2 = ((a + b) - d) / 2;

                    if (x_1 < x_2)
                    {
                        b = x_2;
                    }
                    else
                    {
                        a = x_1;
                    }
                }
            }

            return ((a + b) / 2);
        }
    }
}
