using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestWork_ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1, y1, x2, y2, x3, y3, x4, y4, l1, l2, l3, l4, l5;
            int  numbPoint;
            string namePoint;
            bool RezVerif;
        
            Console.WriteLine("\r\n Введите количество вершин [3 или 4]");
            numbPoint = Convert.ToInt32(Console.ReadLine());
           
            Console.WriteLine("\r\n КООРДИНАТЫ ВЕРШИН многоугльника ВВОДЯТСЯ ПОСЛЕДОВАТЕЛЬНО по направлению обхода вершин");
            x1 = InputData(namePoint = "X вершины 1");
            y1 = InputData(namePoint = "Y вершины 1");
            x2 = InputData(namePoint = "X вершины 2");
            y2 = InputData(namePoint = "Y вершины 2");
            x3 = InputData(namePoint = "X вершины 3");
            y3 = InputData(namePoint = "Y вершины 3");

            l1 = LengthSize(x1, y1, x2, y2);        //сторона 1
            l2 = LengthSize(x2, y2, x3, y3);        //сторона 2
            l3 = LengthSize(x1, y1, x3, y3);        //сторона 3 треугольника или диагональ многоугольника

            switch (numbPoint)
            {
                case 3:
                    RezVerif = Verific(l1, l2, l3);             //работаем с треугольником

                    if (RezVerif == true)                       //если треугольник существует, вычисляем его площадь и периметр
                    {
                        Calculate(l1, l2, l3);
                    }
                break;

                case 4:
                    x4 = InputData(namePoint = "X вершины 4");
                    y4 = InputData(namePoint = "Y вершины 4");
                    l4 = LengthSize(x3, y3, x4, y4);        //сторона 3 многоугольника
                    l5 = LengthSize(x1, y1, x4, y4);        //сторона 4 многоугольника

                    RezVerif = Verific(l1, l2, l3, l4, l5);

                    if (RezVerif == true)        //если треугольник существует, вычисляем его площадь и периметр
                    {
                        Calculate(l1, l2, l3, l4, l5);
                    }
                break;
            }

           Console.ReadLine();
        }


        static double InputData(string name)        //ввод координат
        {
            Console.WriteLine("\r\n Введите координату " + name);
            return (Convert.ToDouble(Console.ReadLine()));
        }


       static public bool Verific(double Sizel1, double Sizel2, double Sizel3)           //проверка на существование треугольника
        {
            if (Sizel1 <= Math.Abs(Sizel2 - Sizel3) || (Sizel1 >= Sizel2 + Sizel3))
            {
                Console.WriteLine("\r\n Это не треугольник");
                return false;
            }
            else
            {
                return true;
            }
        }


        static bool Verific(double Sizel1, double Sizel2, double Sizel3, double Sizel4, double Sizel5)     //проверка на существование четырёхугольника
        {                                                                                                           //представляем как два виртуальных треугольника
            if ((Sizel1 <= Math.Abs(Sizel2 - Sizel3) || (Sizel1 >= Sizel2 + Sizel3)) || (Sizel4 <= Math.Abs(Sizel5 - Sizel3) || (Sizel4 >= Sizel5 + Sizel3)))
            {
                Console.WriteLine("\r\n Это не треугольник");
                return false;
            }
            else
            {
                return true;
            }
        }


        static double LengthSize(double xP1, double yP1, double xP2, double yP2)
        {
            return (Math.Sqrt(Math.Pow((xP1 - xP2), 2) + Math.Pow((yP1 - yP2), 2)));         //формула расстояние между двумя точкамиhttp://ru.onlinemschool.com/math/library/analytic_geometry/point_point_length/
        }


        static void Calculate(double Sizel1, double Sizel2, double Sizel3)          //вычисления для треугольника
        {
            double sq, pperim, prm;
            pperim = (Sizel1 + Sizel2 + Sizel3) / 2;                                               //полупериметр треугольника
            sq = Math.Sqrt(pperim * (pperim - Sizel1) * (pperim - Sizel2) * (pperim - Sizel3));    // формула Геронаhttp://www.math24.ru/scalene-triangle.html
            Console.WriteLine("\r\n Площадь треугольника равна " + sq);

            prm = Sizel1 + Sizel2 + Sizel3;                                         //периметр треугольника
            Console.WriteLine("\r\n Периметр треугольника равен " + prm);      
        }

        static void Calculate(double Sizel1, double Sizel2, double Sizel3, double Sizel4, double Sizel5)   //вычисления для четырёугольника
        {
            double sq, sq1, sq2, ppreim, pperim1, pperim2, prm;
                                                            
            pperim1 = (Sizel1 + Sizel2 + Sizel3) / 2;                                               //полупериметр треугольника 1
            sq1 = Math.Sqrt(pperim1 * (pperim1 - Sizel1) * (pperim1 - Sizel2) * (pperim1 - Sizel3));    // формула Геронаhttp://www.math24.ru/scalene-triangle.html

            pperim2 = (Sizel5 + Sizel4 + Sizel3) / 2;                                               //полупериметр треугольника 2
            sq2 = Math.Sqrt(pperim2 * (pperim2 - Sizel5) * (pperim2 - Sizel4) * (pperim2 - Sizel3));    // формула Геронаhttp://www.math24.ru/scalene-triangle.html

            sq = sq1 + sq2;                                     //площадь четырёхугольника
            Console.WriteLine("\r\n Площадь четырёхугольника равна " + sq);

            prm = Sizel1 + Sizel2 + Sizel4 + Sizel5;            //периметр четырёхугольника
            Console.WriteLine("\r\n Периметр четырёхугольника равен " + prm);   
        }

    }
}
