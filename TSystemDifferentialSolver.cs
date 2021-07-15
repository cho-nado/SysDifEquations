// Решение/работа с системой дифференциальных уравнений с n переменными и n неизвестными 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*********************************************************
namespace StandartHelperLibrary.MathHelper
{
    /// <summary>
    /// Решение/работа с системой дифференциальных уравнений с n переменными и n неизвестными 
    /// </summary>
    public class TSystemDifferentialSolver
    {
//------------------------------------------------------------
        /// <summary>
        /// Решение системы дифференциальных уравнений с n переменными и n неизвестными  методом Рунге-Кутты 4ого порядка 
        /// </summary>
        /// <param name="Equation">Решаемая система уравнений и настройки решателя</param>
        /// <returns>Результат решения</returns>
        public static TSystemResultDifferential SolveSystemFourRungeKutta(ISystemDifferentialEquation Equation, double[] InitArray)
        {
            TSystemResultDifferential ResultSystemDifferential = new TSystemResultDifferential();
            // Рабочие переменные
            double X = Equation.Min_X;// Крайняя левая точка диапазона "х" 
            int CountEquation = Equation.CountEquatiuon;// кол-во урвнений
            double [] Y = new double [CountEquation];//Массив всех Y
            double h = Equation.Step;// Шаг сетки "h" 
            int t = Equation.Rounding;// Округление до нужного знака, после запятой 
            int countOfIterations = Equation.CountIterations;        // Количество итераций  
            double[,] Res = new double[CountEquation +1 , countOfIterations];// задаем размер матрицы ответов с незав. перем.
            double[] Coefs1 = new double[CountEquation];// число 1-ыx коэф. метода по числу уравнений
            double[] Coefs2 = new double[CountEquation];// число 2-ыx коэф. метода по числу уравнений
            double[] Coefs3 = new double[CountEquation];// число 3-иx коэф. метода по числу уравнений
            double[] Coefs4 = new double[CountEquation];// число 4-ыx коэф. метода по числу уравнений
            double []Y2 = new double[CountEquation]; // число переменных для 2-го коэф. включая независимую
            double []Y3 = new double[CountEquation];// число переменных для 3-го коэф. включая независимую
            double[]Y4 = new double[CountEquation];// число переменных для 4-го коэф. включая независимую
            for (int k = 0; k < InitArray.Length ; k++)
            {
                Y[k] = InitArray[k];
            }
            Res[0, 0] = X;
            for (int j = 1; j < CountEquation; j++)
            {
                Res[j, 0] = Y[j];// первая точка результата 
            }
            for (int i = 0; i < countOfIterations; i++)
            {
                TPointSystemDifferential PointSystemDifferential = new TPointSystemDifferential();
                PointSystemDifferential.Result = new double[CountEquation];//
                PointSystemDifferential.IndexIteration = i;
                PointSystemDifferential.Coeffs = new List<double[]>();
                Coefs1 = Equation.ComputeEquation(X, Y);
                // Находим значения переменных для второго коэф.    
                double X2 = X + h / 2;
                for (int k = 0; k < CountEquation; k++)
                {
                    Y2[k] = Y[k] + Coefs1[k] / 2;
                }
                Coefs2 = Equation.ComputeEquation(X2, Y2);

                // Находим значения переменных для третьго коэф.
                double X3 = X + h / 2;
                for (int k = 0; k < CountEquation; k++)
                {
                    Y3[k] = Y[k] + Coefs2[k] / 2;
                }

                Coefs3 = Equation.ComputeEquation(X3, Y3);

                // Находим значения переменных для 4 коэф.
                double X4 = X + h;
                for (int k = 0; k < CountEquation; k++)
                {
                    Y4[k] = Y[k] + Coefs3[k];
                }
                Coefs4 = Equation.ComputeEquation(X4, Y4);

                // Находим новые значения переменных включая независимую    

                for (int k = 0; k < CountEquation; k++)
                {
                    Y[k] += (1.0 / 6.0) * (Coefs1[k] + 2 * (Coefs2[k] + Coefs3[k]) + Coefs4[k]);
                }
                PointSystemDifferential.X = X;
                // Результат  иттерации:
                for (int j = 0; j < CountEquation; j++)
                {
                    PointSystemDifferential.Result[j] = Y[j];
                }
                X += h;
                PointSystemDifferential.Coeffs.Add(Coefs1);
                PointSystemDifferential.Coeffs.Add(Coefs2);
                PointSystemDifferential.Coeffs.Add(Coefs3);
                PointSystemDifferential.Coeffs.Add(Coefs4);
                ResultSystemDifferential.SystemPoints.Add(PointSystemDifferential);
            }
            // Вернуть результат
            return ResultSystemDifferential;
        }
//------------------------------------------------------------
        /// <summary>
        /// Вывести отладочную информацию в консоль и в файл если задано имя
        /// </summary>
        /// <param name="Result">Результат решения системы дифф. уравнений</param>
        /// <param name="FileName">Имя файла</param>
        public static void Debug(TSystemResultDifferential Result, string FileName = "")
        {
            // В файл
            if (FileName.Length > 0) File.WriteAllText(FileName, Result.ToString());
            // В консоль
            Console.WriteLine(Result.ToString());
        }
 //------------------------------------------------------------
        /// <summary>
        /// Простой пример системы дифференциальных уравнений  и ее решения 
        /// <returns>Результат решения</returns>
        public static TSystemResultDifferential Example_dN()
        {
            // Создаем систему уравнений, которая должна решаться и задаем ее параметры 
            ISystemDifferentialEquation Equation = new TEquation_dN()

            {
                Equation = new AEquation_dN((X, Y) =>
                {
                    double[] FunArray = new double[5];

                    FunArray[0] = (X + Y[0] + Y[1] + Y[2] + Y[3] + Y[4]) ;
                    FunArray[1] = (X + 2 * Y[0] + Y[1] + Y[2] + Y[3] + Y[4]);
                    FunArray[2] = (X + Y[0] + 3 * Y[1] + Y[2] + Y[3] + Y[4]);
                    FunArray[3] = (5 * X + 2 * Y[0] + 3 * Y[1] + Y[2] + Y[3] + Y[4]);
                    FunArray[4] = (2 * X + 2 * Y[0] + 3 * Y[1] + Y[2] + Y[3] + Y[4]);
                    return FunArray;   // интегрируемая система 
                }),
                CountIterations = 10,
                Min_X = 0,
                Rounding = 3,
                Step = 1,
                CountEquatiuon = 5
            };
            //Задайте начальные условия 
            double[] InitArray = new double[5];//Начальные значения для всех Y
            InitArray[0] = 1;
            InitArray[1] = 1;
            InitArray[2] = 1;
            InitArray[3] = 1;
            InitArray[4] = 1;
            // Решаем
            return SolveSystemFourRungeKutta(Equation, InitArray);
        }
//------------------------------------------------------------

    }
}
// i want to change this code from my other device
// change this product
// i hate you 
