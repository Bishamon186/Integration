using System;
using System.Globalization;

namespace Lab2
{
    public class UI
    {
        public int SelectFunc()
        {
            bool SelectedFunc = false;
            int numbFunc = 0;
           
                while (!SelectedFunc)
                {
                    try
                    {
                        Console.WriteLine(
                            "Выберете действие:\n 1: Интегрирование f(x) = 2x^2 + 3x -1 \n 2: Интегрирование f(x) = sinx/((cosx)^2+1) \n 3- Интегрирование f(x) = x*(x^2+9)^(1/2)\n " +
                            "4- Выход\n");
                        numbFunc = Convert.ToInt32(Console.ReadLine());
                        if (numbFunc < 1 || numbFunc > 4)
                        {
                            Error(4);
                        }
                        else
                        {
                            SelectedFunc = true;
                        }

                    }
                    catch (FormatException)
                    {
                        Error(1);
                    }
                    catch (OverflowException)
                    {
                        Error(4);
                    }
                }
            return numbFunc ;
        }

        public void Confines(out double leftConfines, out double rightConfines)
        {
            bool ExitMethod = false;
            leftConfines = 0;
            rightConfines = 0;
            while (!ExitMethod)
            {
                try
                {
                    Console.WriteLine("Введите левую границу отрезка, разделитель целой и дробной части - запятая :\n");
                    leftConfines = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Введите правую границу отрезка, разделитель целой и дробной части - запятая:\n");
                    rightConfines = Convert.ToDouble(Console.ReadLine());
                    ExitMethod = true;
                }
                catch (FormatException)
                {
                    Error(1);
                }
                catch (OverflowException)
                {
                    Error(3);
                }
            }
            
        }

        public double Inaccuracy()
        {
            bool ExitMethod = false;
            double e = 0;
            while (!ExitMethod)
            {
                try
                {
                    Console.WriteLine("Введите точность, разделитель целой и дробной части - запятая:\n");
                    e = Convert.ToDouble(Console.ReadLine());
                    ExitMethod = true;
                }
                catch (FormatException)
                {
                    Error(1);
                }
                catch (OverflowException)
                {
                    Error(3);
                }
                
            }
            
            
            return e;
        }

        public static void Error(int numbError)
        {
            switch (numbError)
            {
                    case 1:
                        Console.WriteLine("ERROR: Введите ЧИСЛО, разделитель целой и дробной части - запятая");
                        break;
                case 3:
                    Console.WriteLine("ERROR: Введено слишком большое число!");
                    break;
                    case 4:
                        Console.WriteLine("ERROR: Введите число 1 или 2, или 3, или 4");
                        break;
                    default:
                        Console.WriteLine("ERROR: Неизвестная ошибка");
                        break;
            }
        }

        public static void By()
        {
            Console.WriteLine("Пока!");
        }

        public static void OutResult(double n)
        {
            Console.WriteLine("Методом левых прямоугольников: " + Result.leftRectangles + " Погрешность: " + Result.inaccuracyL);
            
            Console.WriteLine("\nМетодом правых прямоугольников: " + Result.rightRectangles  + " Погрешность: " + Result.inaccuracyR);
            
            Console.WriteLine("\nМетодом средних прямоугольников: " + Result.averagesRectangles  + " Погрешность: " + Result.inaccuracyA);
            
            Console.WriteLine("\nКолличество разбиений: " +n);
        }
    }
}