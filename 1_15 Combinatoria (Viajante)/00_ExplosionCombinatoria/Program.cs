using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WEBOO.Programacion
{
  class Program
  {
    #region FACTORIAL
    static long Factorial(long n)
    {
      long result = 1;
      for (long k = 1; k <= n; k++)
        result *= k;
      return result;
    }
    #endregion

    static void Main(string[] args)
    {
      Stopwatch crono = new Stopwatch();

      #region PRUEBA DE DEMORA PROPORCIONAL A FACTORIAL
      //while (true) //Hasta 13 se puede esperar
      //{
      //  Console.WriteLine("\nEntre el número para calcular factorial");
      //  string s = Console.ReadLine();
      //  if (s.Length == 0) break;
      //  long n = System.Int32.Parse(s);
      //  long m = Factorial(n);
      //  Console.WriteLine("El Factorial de {0} es {1}", n, m);
      //  crono.Restart();
      //  for (long k = 1; k <= m; k++) ; //Probar solo hasta factorial de 13
      //  crono.Stop();
      //  Console.WriteLine("Iterar un ciclo esa cantidad de veces sin hacer nada más demora {0} ms", crono.ElapsedMilliseconds);
      //}
      #endregion

      Console.WriteLine("\nUna solución que demora proporcional a fact de 20 \nsuponiendo 10,000 millones de operaciones por segundo es {0} años",
                         ((double)Factorial(20)) / 10000000000 / 60 / 60 / 24 / 365);
    }
  }
}
