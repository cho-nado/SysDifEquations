﻿//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using StandartHelperLibrary.MathHelper;
//***********************************************************
namespace PL_1
{
    class Program
    {
//----------------------------------------------------------
        static void Main(string[] args)
        {
            // Простой тест
            TSystemDifferentialSolver.Debug(TSystemDifferentialSolver.Example_dN());
            //TDifferentialSolverTwo.Debug(TDifferentialSolverTwo.Example_dXdYdZ());
            //

            Console.ReadKey();
        }
//----------------------------------------------------------
    }
}
