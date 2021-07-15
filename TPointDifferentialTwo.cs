﻿// Точка решения дифференциального уравнения
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*********************************************************
namespace StandartHelperLibrary.MathHelper
{
    /// <summary>
    /// Точка решения дифференциального уравнения
    /// </summary>
    public class TPointDifferentialTwo
    {
        /// <summary>
        /// Номер итерации
        /// </summary>
        public int IndexIteration { get; set; } = 0;
        /// <summary>
        /// Коэффициенты решения
        /// </summary>
        public Dictionary<string, double> Koeffs { get; set; } = new Dictionary<string, double>();
        /// <summary>
        /// Значения (Х) передаваемые в уравнение 
        /// </summary>
        public Dictionary<string, double> Values { get; set; } = new Dictionary<string, double>();
        /// <summary>
        /// delta-y в точке
        /// </summary>
        public double G { get; set; } = 0;
        /// <summary>
        /// delta-z в точке
        /// </summary>
        public double L { get; set; } = 0;
        /// <summary>
        /// Результат расчета в точке
        /// </summary>
        public double Y { get; set; } = 0;
        /// <summary>
        /// Результат расчета в точке
        /// </summary>
        public double Z { get; set; } = 0;
//-------------------------------------------------------
        /// <summary>
        /// В текстовое представление
        /// </summary>
        /// <returns>Текстовое представление</returns>
        public override string ToString()
        {
            string StringKoeffs = "#1 ";
            foreach (var Value in Koeffs)
                StringKoeffs = StringKoeffs + Value.Key + ": " + Value.Value.ToString() + "; ";
            string StringG = "#2 G: " + G.ToString();
            string StringL = "#2 L: " + L.ToString();
            string StringValues = "#3 ";
            foreach (var Value in Values)
                StringValues = StringValues + Value.Key + ": " + Value.Value.ToString() + "; ";
            string StringZ = "#4 z: " + Z.ToString();
            string StringY = "#5 y: " + Y.ToString();
            return "Point №" + IndexIteration.ToString() + " \r\n" + StringKoeffs + " \r\n" +
                   StringG + " \r\n" + StringL + " \r\n" + StringValues + " \r\n" + StringZ + " \r\n" + StringY + "\r\n";
        }
        //-------------------------------------------------------
    }
}
