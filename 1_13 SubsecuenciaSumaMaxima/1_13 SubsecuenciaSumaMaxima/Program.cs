using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace WEBOO.Programacion
{

  class Program
  {

    public static int[] CreateRandomArray(long n)
    {
      int[] a = new int[n];
      Random r = new Random();
      for (int k = 0; k < n; k++)
      {
        int m = r.Next(1, 20);
        //Para que haya negativos
        if (r.Next(0,2) == 0)
          a[k] = -m;
        else
          a[k] = m;
      }
      return a;
    }

    public static void ListArray(int[] a, int inf, int sup)
    {
      for (int k = inf; k <= sup; k++)
      {
        Console.Write("{0,4}  ", a[k]);
        if ((k - inf + 1) % 10 == 0) Console.WriteLine();
      }
    }
    
    #region SECUENCIA DE SUMA MÁXIMA. FUERZA BRUTA. ORDEN CÚBICO N^3
    public static long SubSumaMaxFuerzaBruta(int[] a, out int inf, out int sup)
    {
      long maxSuma = 0;
      inf = 0; sup = a.Length-1;
      for (int i = 0; i < a.Length; i++)
        for (int j = i; j < a.Length; j++)
        {
          long suma = 0;
          for (int k = i; k <= j; k++)
            suma += a[k];
          if (suma > maxSuma)
          {
            maxSuma = suma;
            inf = i; sup = j;
          }
        }
      return maxSuma;
    }
    #endregion

    #region SECUENCIA DE SUMA MÁXIMA. ORDEN CUADRÁTICO, N^2
    public static long SubSumaMaxCuadratico(int[] a, out int inf, out int sup)
    {
      long maxSuma = 0;
      inf = 0; sup = a.Length-1;
      for (int i = 0; i < a.Length; i++)
      {
        long suma = 0;
        for (int j = i; j < a.Length; j++)
        {
          suma += a[j];
          if (suma > maxSuma)
          {
            maxSuma = suma;
            inf = i; sup = j;
          }
        }
      }
      return maxSuma;
    }

    #endregion

    #region SECUENCIA DE SUMA MÁXIMA. RECURSIVO (DIVIDE Y VENCERÁS). ORDEN N*LN(N)
    public static long SubSumaMaxRecursivo(int[] a)
    {
      return SubSumaMaxRecursivo(a, 0, a.Length - 1);
    }

    static long SubSumaMaxRecursivo(int[] a, int inf, int sup)
    {
      long maxHaciaIzq = 0; long maxHaciaDer = 0;
      long maxIzq, maxMedio, maxDer;
      int medio;
      if (inf == sup) return (a[inf] > 0 ? a[inf] : 0);
      else
      {
        medio = (inf + sup) / 2;
        maxIzq = SubSumaMaxRecursivo(a, inf, medio);
        maxDer = SubSumaMaxRecursivo(a, medio + 1, sup);
        long sum = 0;
        for (int i = medio; i >= inf; i--)
        {
          sum += a[i];
          if (sum > maxHaciaIzq) maxHaciaIzq = sum;
        }
        sum = 0;
        for (int i = medio + 1; i <= sup; i++)
        {
          sum += a[i];
          if (sum > maxHaciaDer) maxHaciaDer = sum;
        }
        maxMedio = maxHaciaIzq + maxHaciaDer;
        return Math.Max(maxIzq, Math.Max(maxMedio, maxDer));
      }
    }
    #endregion

    #region SECUENCIA DE SUMA MÁXIMA LINEAL. ORDEN N
    //Consideramos que hay al menos un positivo
    public static long SubSumaMaxLineal(int[] a, out int inf, out int sup)
    {
      long maxSuma = 0;
      long suma = 0;
      int nuevoInf;
      inf = sup = nuevoInf = 0;
      for (int i = 0; i < a.Length; i++)
      {
        suma += a[i];
        if (suma < 0)
        {
          //Empieza a explorar una nueva subsecuencia
          suma = 0;
          nuevoInf = i + 1;
        }
        else
        {
          if (suma > maxSuma)
          {
            maxSuma = suma;
            inf = nuevoInf;
            sup = i;
          }
        }
      }
      return maxSuma;
    }
    #endregion

    #region CLASE PRACTICA
    //Modificar la solucion recursiva para que también devuelva donde empieza y donde termina la secuencia de suma máxima
    #endregion

    static void Main(string[] args)
    {
      int[] a; string s; long n;

      while (true)
      {
        Console.WriteLine("\n------");
        Console.WriteLine("Entre tamaño del array");
        s = Console.ReadLine();
        if (s.Length == 0) break;
        n = System.Int64.Parse(s);
        Console.WriteLine("Creando array ...");
        a = CreateRandomArray(n);
        long valor;
        Stopwatch crono = new Stopwatch();
        int desde, hasta;

        //ListArray(a, 0, a.Length - 1);

        #region FUERZA BRUTA CÚBICO
        //1 Tope de prueba 4000
        Console.WriteLine("\nSubSumaMax Fuerza Bruta (n^3) ...");
        crono.Restart();
        valor = SubSumaMaxFuerzaBruta(a, out desde, out hasta);
        crono.Stop();
        Console.WriteLine("Total {0}. Demora de {1} ms", valor, crono.ElapsedMilliseconds);
        Console.WriteLine("Desde la posición {0} hasta la {1}", desde, hasta);
        //ListArray(a, desde, hasta);
        #endregion

        #region FUERZA BRUTA CUADRÁTICO
        //2 Tope de prueba 100,000
        Console.WriteLine("\nSubSumaMax Cuadrático (n^2) ...");
        crono.Restart();
        valor = SubSumaMaxCuadratico(a, out desde, out hasta);
        crono.Stop();
        Console.WriteLine("Total {0}. Demora de {1} ms", valor, crono.ElapsedMilliseconds);
        Console.WriteLine("Desde la posición {0} hasta la {1}", desde, hasta);
        //ListArray(a, desde, hasta);
        #endregion

        #region RECURSIVO CON DIVIDE Y VENCERAS N * LN2(N)
        //3 Tope de prueba 200 000 000 y aumentar tamaño del array hasta que de out of memory
        Console.WriteLine("\nSubSumaMax Recursivo Divide y Vencerás (ln(n)*n) ...");
        crono.Restart();
        valor = SubSumaMaxRecursivo(a);
        crono.Stop();
        Console.WriteLine("Total {0}. Demora de {1} ms", valor, crono.ElapsedMilliseconds);
        #endregion

        #region LINEAL
        Console.WriteLine("\nSubSumaMax Lineal (n) ...");
        crono.Restart();
        valor = SubSumaMaxLineal(a, out desde, out hasta);
        crono.Stop();
        Console.WriteLine("Total {0}. Demora de {1} ms", valor, crono.ElapsedMilliseconds);
        Console.WriteLine("Desde la posición {0} hasta la {1}", desde, hasta);
        //ListArray(a, desde, hasta);
        #endregion
      }
    }
  }
}
