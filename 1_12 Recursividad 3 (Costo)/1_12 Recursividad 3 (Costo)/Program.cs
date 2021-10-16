using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WEBOO.Programacion
{
  class Program
  {
    #region CREAR ARRAY ALEATORIO PERO ORDENADO
    public static int[] RandomSortedArray(int n)
    {
      int[] a = new int[n];
      Random r = new Random(); ;
      a[0] = r.Next(5);
      for (int i = 1; i < a.Length; i++)
        a[i] = a[i - 1] + r.Next(5);
      return a;
    }
    #endregion

    #region CREAR ARRAY ALEATORIO DESORDENADO
    public static int[] RandomArray(int n)
    {
      int[] a = new int[n];
      Random r = new Random(); ;
      for (int i = 0; i < a.Length; i++)
      {
        a[i] = r.Next(n*2);
      }

      return a;
    }
    #endregion

    #region COMPARACION DE IGUALDAD DE ARRAYS
    static bool EqualsArray(int[] a, int[] b)
    {
      if (a.Length == b.Length)
      {
        for (int k = 0; k < a.Length; k++)
          if (a[k] != b[k]) return false;
        return true;
      }
      else return false;
    }
    #endregion

    #region LISTAR ARRAY
    static void ListarArray(int[] a)
    {
      for (int k = 0; k < a.Length; k++)
      {
        Console.Write("{0}  ", a[k]);
        if (k + 1 % 10 == 0) Console.WriteLine();
      }
    }
    #endregion

    static long iteraciones;

    #region BUSQUEDAS

    //BUSQUEDA SECUENCIAL
    static int PosSecuencial(int[] a, int x)
    {
      iteraciones = 0;
      for (int k = 0; k < a.Length; k++)
      {
        iteraciones++;
        if (a[k] == x)
          return k;
      }
      return -1;
    }

    //BUSQUEDA BINARIA RECURSIVA
    static int PosBinario(int[] a, int x)
    {
      iteraciones = 0;
      return Pos(a, x, 0, a.Length - 1);
    }

    static int Pos(int[] a, int x,
                   int inf, int sup)
    {
      iteraciones++;
      if (inf > sup) return -1;
      int medio = inf + (sup - inf) / 2;
      if (x > a[medio])
        return Pos(a, x, medio + 1, sup);
      else if (x < a[medio])
        return Pos(a, x, inf, medio - 1);
      else return medio;
    }
    #endregion

    #region ORDENACION

      #region ORDENAR MINIMOS SUCESIVOS
        static void OrdenarPorMinimosSucesivos(int[] a)
        {
          iteraciones = 0;
          for (int i = 0; i < a.Length - 1; i++)
            for (int j = i + 1; j < a.Length; j++)
            {
              iteraciones++;
              if (a[j] < a[i])
              {
                int temp = a[j];
                a[j] = a[i];
                a[i] = temp;
              }
            }
        }
        #endregion

      #region ORDENACIÓN POR MEZCLA
      public static void OrdenarPorMezcla(int[] a)
      {
        int[] aux = new int[a.Length];
        iteraciones = 0;
        OrdenarPorMezcla(a, aux, 0, a.Length - 1);
      }

      private static void OrdenarPorMezcla(int[] a, 
                       int[] aux, int inf, int sup)
      {
        if (inf < sup)
        {
          int medio = (inf + sup) / 2;
          OrdenarPorMezcla(a, aux, inf, medio);
          OrdenarPorMezcla(a, aux, medio + 1, sup);
          Mezclar(a, aux, inf, medio, sup);
        }
        else iteraciones++;
      }

      private static void Mezclar(int[] a, int[] aux, int inf, int medio, int sup)
      {
        int izq = inf; // para recorrer la 1ra mitad
        int der = medio + 1; // para recorer la 2da mitad
        int pos = inf; // para ir dejando la mezcla en aux

        while (izq <= medio && der <= sup)
        {
          iteraciones++;
          if (a[izq] < a[der]) aux[pos++] = a[izq++];
          else aux[pos++] = a[der++];
        }
        if (izq <= medio) Array.Copy(a, izq, aux, pos, medio - izq + 1);
        iteraciones += medio - izq + 1;
        if (der <= sup) Array.Copy(a, der, aux, pos, sup - der + 1);
        iteraciones += sup - der + 1;

        //Pasar el resultado de la mezcla de nuevo para a
        Array.Copy(aux, inf, a, inf, sup - inf + 1);
        iteraciones += sup - inf + 1;
      }

      #endregion

    #endregion

    #region MAXIMO

      #region MÁXIMO DIVIDE Y VENCERAS
      public static int MaximoDivideYVenceras(int[] a)
      {
        if (a.Length == 0)
          throw new ArgumentException("array no puede estar vacío");
        else
        {
          iteraciones = 0;
          return MaximoRecursivo(a, 0, a.Length - 1);
        }
      }

      static int MaximoRecursivo(int[] a, int inf, int sup)
      {
        iteraciones++;
        if (inf >= sup)
        {
          return a[inf];
        }
        else
        {
          int medio = (inf + sup) / 2;
          int maxIzq = MaximoRecursivo(a, inf, medio);
          int maxDer = MaximoRecursivo(a, medio + 1, sup);
          return Math.Max(maxIzq, maxDer);
        }
      }
      #endregion

      #region MÁXIMO FUERZA BRUTA SECUENCIAL
      public static int MaximoSecuencial(int[] a)
      {
        iteraciones = 0;
        if (a.Length == 0)
          throw new ArgumentException("array no puede estar vacío");
        int max = a[0];
        for (int k = 1; k < a.Length; k++)
        {
          iteraciones++;
          if (a[k] > max) max = a[k];
        }
        return max;
      }
      #endregion

    #endregion

    #region FIBONACCI
    public static long FibonacciRecursivo(int n)
    {
      iteraciones = 0;
      if (n < 1) throw new Exception("Término debe >= 1");
      return FibonacciRec(n);
    }

    static long FibonacciRec(int n)
    {
      iteraciones++;
      if (n == 1 || n == 2)
        return 1;
      else
        return FibonacciRec(n - 1) + FibonacciRec(n - 2);
    }

    public static long FibonacciIterativo(int n)
    {
      if (n < 1) throw new Exception("Término debe >= 1");
      long ultimo = 1, penultimo = 1;
      for (int k = 3; k <= n; k++)
      {
        long temp = penultimo;
        penultimo = ultimo;
        ultimo = ultimo + temp;
      }
      return ultimo;
    }
    #endregion

    static void Main(string[] args)
    {
      while (true)
      {
        Stopwatch crono = new Stopwatch();

        Console.WriteLine("\n------------------");
        Console.Write("Entra longitud del array "); //Para ordenacion no pasar de 200,000
        int n = int.Parse(Console.ReadLine());
        int[] a;
       

        #region PRUEBA BUSQUEDA
        //a = RandomSortedArray(n);
        //crono.Restart();
        //int pos = PosSecuencial(a, -10);
        //crono.Stop();
        //Console.WriteLine();
        //Console.WriteLine("Busqueda secuencial calculado en  {0,6} ms {1,8} iteraciones", crono.ElapsedMilliseconds, iteraciones);

        //crono.Restart();
        //pos = PosBinario(a, -10);
        //crono.Stop();
        //Console.WriteLine("Busqueda binaria calculado en     {0,6} ms {1,8} iteraciones", crono.ElapsedMilliseconds, iteraciones);
        #endregion

        #region PRUEBA MAXIMO
        a = RandomArray(n);
        crono.Restart();
        int max = MaximoSecuencial(a);
        crono.Stop();
        Console.WriteLine();
        Console.WriteLine("El maximo secuencial calculado en {0,6} ms {1,8} iteraciones", crono.ElapsedMilliseconds, iteraciones);

        crono.Restart();
        max = MaximoDivideYVenceras(a);
        crono.Stop();
        Console.WriteLine("El maximo recursivo calculado en  {0,6} ms {1,8} iteraciones", crono.ElapsedMilliseconds, iteraciones);
        #endregion

        #region PRUEBA ORDENACION
        //crono.Restart();
        //OrdenarPorMinimosSucesivos(a);
        //crono.Stop();
        //Console.WriteLine();
        //Console.WriteLine("Ordenacion minimos sucesivos calculado en {0,6} ms {1,12} iteraciones", crono.ElapsedMilliseconds, iteraciones);

        //crono.Restart();
        //OrdenarPorMezcla(a);
        //crono.Stop();
        //Console.WriteLine("Ordenacion por mezcla calculado en        {0,6} ms {1,12} iteraciones", crono.ElapsedMilliseconds, iteraciones);
        #endregion 

        #region PRUEBA FIBONACCI
        //Console.WriteLine("\nEntre termino a calcular de sucesión Fibonacci"); //PROBAR HASTA CON 45
        //int k = int.Parse(Console.ReadLine());
        //crono.Restart();
        //long result = FibonacciIterativo(k);
        //crono.Stop();
        //Console.WriteLine("El término {0} de la sucesión de Fibonacci (via iterativa) es {1,12}", k, result);
        //Console.WriteLine("Calculado en {0,8} ms", crono.ElapsedMilliseconds);
        //crono.Restart();
        //result = FibonacciRecursivo(k);
        //crono.Stop();
        //Console.WriteLine("El término {0} de la sucesión de Fibonacci (via recursiva) es {1,12}", k, result);
        //Console.WriteLine("Calculado en {0,8} ms {1,12} iteraciones", crono.ElapsedMilliseconds, iteraciones);
        #endregion
      
      }
    }
  }
}
