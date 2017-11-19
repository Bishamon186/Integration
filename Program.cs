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
            int m = 0;
            int numbFunc;
            double ValueIntegral = 0;
            double leftConfines, rightConfines, inaccuracy;
            RectangleMethod solution = new RectangleMethod();
            UI ui = new UI();
            bool ExitProgram = false;

            while (!ExitProgram)
            {
                numbFunc = ui.SelectFunc();

                switch (numbFunc)
                {
                    case 1:
                        ui.Confines(out leftConfines,out rightConfines);
                        inaccuracy = ui.Inaccuracy();
                        ValueIntegral = solution.MainRectangleMethod(leftConfines,rightConfines,inaccuracy,funcpointer);
                        m = 1;
                        UI.OutResult(ValueIntegral);
                        break;
                    case  2:
                        ui.Confines(out leftConfines,out rightConfines);
                        inaccuracy = ui.Inaccuracy();
                        funcpointer = Func2;
                        ValueIntegral = solution.MainRectangleMethod(leftConfines,rightConfines,inaccuracy,funcpointer);
                        UI.OutResult(ValueIntegral);
                        break;
                    case 3:
                        ui.Confines(out leftConfines,out rightConfines);
                        inaccuracy = ui.Inaccuracy();
                        funcpointer = Func3;
                        ValueIntegral = solution.MainRectangleMethod(leftConfines,rightConfines,inaccuracy,funcpointer);
                        UI.OutResult(ValueIntegral);
                        break;
                    case  4:
                        ExitProgram = true;
                        UI.By();
                        break;
                    default:
                        UI.Error(4);
                        break;
                }
                
            }
            
            
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