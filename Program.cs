using System;
using System.Collections.Generic;
using System.Globalization;

namespace Lab2
{
    internal class Program
    {
        public delegate double FuncValue(double x); 
        public static void Main(string[] args)
        {
            FuncValue funcpointer = new FuncValue(Func1);
            int numb;
            double n = 0;
            double confines1, confines2, inaccuracy;
            RectangleMethod solution = new RectangleMethod();
            UI ui = new UI();
            
            numb = ui.SelectFunc();
            ui.Confines(out confines1,out confines2);
            inaccuracy = ui.Inaccuracy();

            switch (numb)
            {
                    case 1:
                        n = solution.work(confines1,confines2,inaccuracy,funcpointer);
                        break;
                    case  2:
                        funcpointer = Func2;
                        n = solution.work(confines1,confines2,inaccuracy,funcpointer);
                        break;
                    case 3:
                        funcpointer = Func3;
                        n = solution.work(confines1,confines2,inaccuracy,funcpointer);
                        break;
                     default:
                         UI.Err(4);
                         break;
            }
            UI.OutResult(n);
        }
        
        public static double Func1( double x)
        {
            return 2*Math.Pow(x,2) + 3*x - 1;
        }
        
        public static double Func2( double x)
        {
            return (Math.Sin(x))/(Math.Pow(Math.Cos(x),2)+1);
        }
        
        public static double Func3( double x)
        {
            return x* Math.Sqrt(Math.Pow(x,2)+9);
        }
        
    }
}