using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Weboo.Programacion.Backtracking
{
  class Program
  {

    #region UBICA 8 REINAS
    public static bool UbicaReinas( int n )
    {
      bool[,] tablero = new bool[n, n];
      return UbicaReinas(tablero, n);
    }

    private static bool UbicaReinas( bool[,] tablero, int n )
    {
      // Condición de parada, cuando ya no queden reinas por ubicar
      if (n == 0) return true;

      //Quedan n reinas por ubicar
      int j = tablero.GetLength(0) - n;

      // Intentar ubicar una reina en la columna j
      for (int i = 0; i < tablero.GetLength(0); i++)
      {
        // Verificar si la reina en la ubicación no amenaza las anteriores
        if (!Amenaza(tablero, i, j))
        {
          // Intento de ubicar la reina en la celda i,j
          tablero[i, j] = true;

          //Visualizar el tablero
          ImprimirTableroReinas(tablero);
   
          // Ver si se puede ubicar las restantes reinas
          if (UbicaReinas(tablero, n - 1)) return true;

          // No se pudieron ubicar las restantes. Deshacer la ubicación que se hizo
          tablero[i, j] = false;
          ImprimirTableroReinas(tablero);
        }
      }
      return false; // No se pudieron ubicar las reinas en la columna j
    }

    private static bool Amenaza( bool[,] tablero, int fila, int columna )
    {
      // Verificar si hay alguna reina en la misma fila hacia la izquierda
      for (int j = 0; j < columna; j++)
      {
        if (tablero[fila, j]) return true;
      }
      // Diagonal noroeste (arriba a la izquierda)
      for (int i = fila-1, j = columna-1; i >= 0 && j >= 0; i--, j--)
      {
        if (tablero[i, j]) return true;
      }
      // Diagonal suroeste (abajo a la izquierda)
      for (int i = fila+1, j = columna-1; i < tablero.GetLength(0) && j >= 0; i++, j--)
      {
        if (tablero[i, j]) return true;
      }
      return false;
    }

    static void ImprimirTableroReinas( bool[,] tablero )
    {
      for (int i = 0; i < tablero.GetLength(0); i++)
      {
        for (int j = 0; j < tablero.GetLength(1); j++)
        {
          if (tablero[i, j])
          {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(" Q");
          }
          else
          {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" Q");
          }
        }
        Console.WriteLine();
      }
      Console.WriteLine();
      Console.ReadLine();
    }
    #endregion

    static void Main( string[] args )
    {

      while (true)
      {
        Console.Write("\nEntre la cantidad de reinas (solo Enter para terminar): ");
        string s = Console.ReadLine();
        if (s.Length == 0) break;
        int reinas = Int32.Parse(s);
        Console.WriteLine(UbicaReinas(reinas));
      }
    }
  }
}


