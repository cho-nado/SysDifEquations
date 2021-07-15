﻿// Унифицированный результат решения дифференциального уравнения
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//*********************************************************
namespace StandartHelperLibrary.MathHelper
{
    /// <summary>
    /// Унифицированный результат решения дифференциального уравнения
    /// </summary>
    public class TResultDifferentialTwo
    {
        /// <summary>
        /// Исходное уравнение и настройки решателя
        /// </summary>
        public IDifferentialEquation Equation { get; set; }
        /// <summary>
        /// Точки решения дифф. уравнения
        /// </summary>
        public List<TPointDifferentialTwo> PointsTwo { get; set; } = new List<TPointDifferentialTwo>();
        //-------------------------------------------------------
        /// <summary>
        /// В текстовое представление
        /// </summary>
        /// <returns>Текстовое представление</returns>
        public override string ToString()
        {
            string Out = "";
            foreach (var P in PointsTwo)
            {
                Out = Out + P.ToString() + " \r\n";
            }
            return Out;
        }
        //-------------------------------------------------------
    }
}
