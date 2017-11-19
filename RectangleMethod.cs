using System;

namespace Lab2
{
    internal class RectangleMethod
    {
        public double MainRectangleMethod(double leftConfines, double  rightConfines, double UserInaccuracy ,Program.FuncValue funcpointer)
        {
            double leftRectangles1 = 0, rightRectangles1 = 0, averagesRectangles1 = 0 ,step, RealInaccuracy = 0,tmp, numberSeparation=1;
            int sign = 1;
            if (leftConfines > rightConfines) //если левая граница больше правой, меняем их местами и меняем знак 
            {
                tmp = leftConfines;
                leftConfines = rightConfines;
                rightConfines = tmp;
                sign = -1;
            }
            
            do
            {
                numberSeparation *= 2; //разбиения In
                step = (rightConfines - leftConfines) / numberSeparation; //h для In
                Result.leftRectangles =  CalculationIntegral(leftConfines, rightConfines, step, funcpointer,1); //значение In методом левых прямоугольников
                Result.rightRectangles =CalculationIntegral(leftConfines, rightConfines, step, funcpointer,2); //значение In методом правых прямоугольников
                Result.averagesRectangles = CalculationIntegral(leftConfines, rightConfines, step, funcpointer,3);//значение In методом средних прямоугольников
                
                numberSeparation *= 2;//разбиения I2n (в 2 разабольше, чем In)
                step = (rightConfines- leftConfines) / numberSeparation; //h для I2n
                leftRectangles1 = CalculationIntegral(leftConfines, rightConfines, step, funcpointer,1); //значение I2n методом левых прямоугольников
                rightRectangles1 = CalculationIntegral(leftConfines, rightConfines, step, funcpointer,2);//значение I2n методом правых прямоугольников
                averagesRectangles1 = CalculationIntegral(leftConfines, rightConfines, step, funcpointer,3);//значение I2n методом средних прямоугольников

                Result.inaccuracyA = 0.3 * Math.Abs(averagesRectangles1 - Result.averagesRectangles  );//вычисление погрешности методом Рунге для средних прямоугольников
                Result.inaccuracyL = 0.3* Math.Abs(leftRectangles1 - Result.leftRectangles  );//вычисление погрешности методом Рунге для левых прямоугольников
                Result.inaccuracyR = 0.3 *Math.Abs(rightRectangles1 - Result.rightRectangles);//вычисление погрешности методом Рунге для правых прямоугольников

                RealInaccuracy = MaximumError();//выбираем самую большую погрешность из трех методов

            } while (RealInaccuracy > UserInaccuracy);//делаем вот это все пока какая-либо погрешность из 3х методов будет больше заданной пользователем

            if (sign == -1) //если левая граница больше правой, меняем знак результата 
            {
                Result.leftRectangles = -Result.leftRectangles;
                Result.rightRectangles = -Result.rightRectangles;
                Result.averagesRectangles = -Result.averagesRectangles;
            }
            
            return numberSeparation/2; //кол-во разбиений
        }

        public double MaximumError()//выбираем самую большую погрешность из трех методов
        {
            double RealInaccuracy;
            if (Result.inaccuracyA >= Result.inaccuracyL) 
            {
                if (Result.inaccuracyA >= Result.inaccuracyR)
                {
                    RealInaccuracy = Result.inaccuracyA;
                }
                else
                {
                    RealInaccuracy = Result.inaccuracyR;
                }
            }
            else
            {
                if (Result.inaccuracyL >= Result.inaccuracyR)
                {
                    RealInaccuracy = Result.inaccuracyL;
                }
                else
                {
                    RealInaccuracy = Result.inaccuracyR;
                }
            }
            return RealInaccuracy;
        }

        public double CalculationIntegral(double confines1, double confines2, double step,Program.FuncValue funcpointer, int type)//высчитываем значение заданного интеграла
        {
            double result = 0;
            double forRight = 0, forLeft = 0, forAverages = 0;
            switch (type) //в зависимости от метода изменяем параметры 
            {
                    case 1:
                        forLeft = step;
                    break;
                    case 2:
                        forRight = step;
                    break;
                    case 3:
                        forAverages = step / 2;
                    break;
                    default:
                        break;
            }
            for (double x = confines1 + forRight; x < confines2 - forLeft; x += step)
            {
                result += funcpointer(x + forAverages) * step;

            }
            return result;
        }
            
        }
    }
