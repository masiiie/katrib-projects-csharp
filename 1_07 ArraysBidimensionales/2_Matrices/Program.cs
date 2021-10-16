using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

namespace WEBOO.Programacion
{
  class Program
  {

    #region LISTAR MATRIZ DE ENTEROS
    static void ListaMatriz( int[,] a )
    {
      int filas = a.GetLength(0);
      int columnas = a.GetLength(1);
      for (int i = 0; i < filas; i++)
      {
        for (int j = 0; j < columnas; j++)
          Console.Write("{0,5}", a[i, j]);
        Console.WriteLine();
      }
    }
    #endregion

    #region MULTIPLICAR DOS MATRICES
    static int[,] Multiplicar( int[,] a, int[,] b )
    {
      if (a.GetLength(1) != b.GetLength(0))
        throw new Exception("Las Matrices no se pueden multiplicar");
      int[,] c = new int[a.GetLength(0), b.GetLength(1)];
      for (int i = 0; i < a.GetLength(0); i++)
        for (int j = 0; j < b.GetLength(1); j++)
        {
          c[i, j] = 0;
          for (int k = 0; k < a.GetLength(1); k++)
            c[i, j] += a[i, k] * b[k, j];
        }
      return c;
    }
    #endregion

    static void Main( string[] args )
    {
      #region PRUEBA MULTIPLICACIÓN DE MATRICES
      int[,] a = { {  2,  4,  6 }, 
                   {  3,  5,  7 }, 
                   { 12, 14, 16 }, 
                   { 13, 15, 17 } 
                 };
      int[,] b = { { 1, 10, 100 }, 
                   { 1, 10, 100 }, 
                   { 1, 10, 100 },  
                 };

      int[,] identidad = 
                 { { 1, 0, 0 }, 
                   { 0, 1, 0 }, 
                   { 0, 0, 1 },  
                 };


      Console.WriteLine("\nMultiplicación de Matrices");
      Console.WriteLine("Matriz A");
      ListaMatriz(a);

      Console.WriteLine("\nMatriz B");
      ListaMatriz(b);
      Console.WriteLine();
      int[,] result = Multiplicar(a, b);
      Console.WriteLine("\nMatriz A x B");
      ListaMatriz(result);
      Console.WriteLine();

      result = Multiplicar(a, identidad);
      Console.WriteLine("\nMatriz A x Identidad");
      ListaMatriz(result);
      Console.WriteLine();
      #endregion
    }
  }
}
