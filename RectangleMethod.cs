using System;

namespace Lab2
{
    internal class RectangleMethod
    {
        public double work(double confines1, double  confines2, double UserInaccuracy ,Program.FuncValue funcpointer)
        {
            double leftRectangles1 = 0, rightRectangles1 = 0, averagesRectangles1 = 0 ,step, RealInaccuracy = 0,tmp,n=1;
            int sing = 1;
            if (confines1 > confines2) //если левая граница больше правой, меняем их местами и меняем знак 
            {
                tmp = confines1;
                confines1 = confines2;
                confines2 = tmp;
                sing = -1;
            }
            
            do
            {
                n *= 2; //разбиения In
                step = (confines2 - confines1) / n; //h для In
                leftRectangles1 = CalculationIntegral(confines1, confines2, step, funcpointer,1); //значение In методом левых треугольников
                rightRectangles1 = CalculationIntegral(confines1, confines2, step, funcpointer,2); //значение In методом правых треугольников
                averagesRectangles1 = CalculationIntegral(confines1, confines2, step, funcpointer,3);//значение In методом средних треуголников
                
                n *= 2;//разбиения I2n (в 2 разабольше, чем In)
                step = (confines2 - confines1) / n; //h для I2n
                Result.leftRectangles = CalculationIntegral(confines1, confines2, step, funcpointer,1); //значение I2n методом левых треугольников
                Result.rightRectangles = CalculationIntegral(confines1, confines2, step, funcpointer,2);//значение I2n методом правых треугольников
                Result.averagesRectangles = CalculationIntegral(confines1, confines2, step, funcpointer,3);//значение I2n методом средних треуголников

                Result.inaccuracyA = 0.3 * Math.Abs(Result.averagesRectangles - averagesRectangles1);//вычисление погрешности методом Рунге для средних треугольников
                Result.inaccuracyL = 0.3* Math.Abs(Result.leftRectangles - leftRectangles1);//вычисление погрешности методом Рунге для левых треугольников
                Result.inaccuracyR = 0.3* Math.Abs(Result.rightRectangles - rightRectangles1);//вычисление погрешности методом Рунге для правых треугольников 

                RealInaccuracy = MaximumError();//выбираем самую большую погрешность из трех методов

            } while (RealInaccuracy > UserInaccuracy);//делаем вот это все пока какая-либо погрешность из 3х методов будет больше заданной пользователем

            if (sing == -1) //если левая граница больше правой, меняем знак результата 
            {
                Result.leftRectangles = -Result.leftRectangles;
                Result.rightRectangles = -Result.rightRectangles;
                Result.averagesRectangles = -Result.averagesRectangles;
            }
            
            return n; //кол-во разбиений
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
