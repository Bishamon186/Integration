using System;
using System.Globalization;

namespace Lab2
{
    public class UI
    {
        public int SelectFunc()
        {
            int numb;
            Console.WriteLine("Выберете функцию для интегрирования:\n 1: 2x^2 + 3x -1 \n 2: sinx/((cosx)^2+1) \n 3- x*(x^2+9)^(1/2)\n");
            return  numb = Convert.ToInt32(Console.ReadLine());
        }

        public void Confines(out double confines1, out double confines2)
        {
            Console.WriteLine("Введите левую границу отрезка:\n");
            confines1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите правую границу отрезка:\n");
            confines2 = Convert.ToDouble(Console.ReadLine());
        }

        public double Inaccuracy()
        {
            Console.WriteLine("Введите погрешность:\n");
            return Convert.ToDouble(Console.ReadLine());
        }

        public static void Err(int numbError)
        {
            switch (numbError)
            {
                    case 4:
                     Console.WriteLine("Введите число 1 или 2, или 3");
                        break;
            }
        }

        public static void OutResult(double n)
        {
            Console.WriteLine("Методом левых треугольников: " + Result.leftRectangles + " Погрешность: " + Result.inaccuracyL);
            
            Console.WriteLine("\nМетодом правых треугольников: " + Result.rightRectangles  + " Погрешность: " + Result.inaccuracyR);
            
            Console.WriteLine("\nМетодом средних треугольников: " + Result.averagesRectangles  + " Погрешность: " + Result.inaccuracyA);
            
            Console.WriteLine("\nКолличество разбиений: " +n);
        }
    }
}