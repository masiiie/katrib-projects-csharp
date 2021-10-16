using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace WEBOO.Programacion {
  class Program {

    #region BUSQUEDAS

    //BUSQUEDA SECUENCIAL
    static int PosSecuencial( int[] a, int x )
    {
      for (int k=0; k<a.Length; k++)
        if (a[k] == x)
          return k;
      return -1;
    }

    //BUSQUEDA BINARIA ITERATIVA
    static int PosBinarioIterativo( int[] a, int x )
    {
      int inf = 0; 
      int sup = a.Length - 1;
      while (inf <= sup)
      {
        int medio = inf + (sup - inf) / 2;
        if (x > a[medio])
          inf = medio + 1;
        else if (x < a[medio])
          sup = medio - 1;
        else return medio;
      }
      return -1;
    }
   
    //BUSQUEDA BINARIA RECURSIVA
    static int PosBinario( int[] a, int x )
    {
      return Pos(a, x, 0, a.Length - 1);
    }

    static int Pos( int[] a, int x,
                   int inf, int sup )
    {
      if (inf > sup) return -1;
      int medio = inf + (sup - inf) / 2;
      if (x > a[medio])
        return Pos(a, x, medio + 1, sup);
      else if (x < a[medio])
        return Pos(a, x, inf, medio - 1);
      else return medio;
    }
    #endregion
    
    #region ORDENAR MINIMOS SUCESIVOS  
    static void OrdenarPorMinimosSucesivos(int[] a)
    {
      for (int i = 0; i < a.Length - 1; i++)
        for (int j = i+1; j<a.Length; j++)
          if (a[j] < a[i])
          {
            int temp = a[j];
            a[j] = a[i];
            a[i] = temp;
          }
    } 
    #endregion

    #region ORDENAR POR MEZCLA
    static void OrdenarPorMezcla(int[] a)
    {
      OrdenarPorMezcla(a, 0, a.Length-1, new int[a.Length]);
    }
    static void OrdenarPorMezcla(int[] a, int ci, int cs, int[]temp)
    {
      if (ci < cs)
      {
        OrdenarPorMezcla(a, ci, ci + (cs - ci) / 2, temp);
        OrdenarPorMezcla(a, ci + (cs - ci) / 2 + 1, cs, temp);
        Mezclar(a, ci, ci + (cs - ci) / 2, ci + (cs - ci) / 2 + 1, cs, temp);
      }
    }
    static void Mezclar(int[] a, int ci1, int cs1, int ci2, int cs2, int[] temp)
    {
      int longitudMezcla = (cs1 - ci1 + 1) + (cs2 - ci2 + 1);
      int i = ci1;
      int k = 0;
      while (ci1 <= cs1 && ci2 <= cs2)
      {
        if (a[ci1] < a[ci2])
        {
          temp[k] = a[ci1];
          ci1++;
        }
        else
        {
          temp[k] = a[ci2];
          ci2++;
        }
        k++;
      }

      if (cs1 >= ci1) Array.Copy(a, ci1, temp, k, (cs1 - ci1) + 1); //Copiar los que queden del intervalo ci1,cs1
      if (cs2 >= ci2) Array.Copy(a, ci2, temp, k, (cs2 - ci2) + 1); //Copiar los que queden del intervalo ci2,cs2
      Array.Copy(temp, 0, a, i, longitudMezcla);
    }
    #endregion

    #region CREAR ARRAY ALEATORIO PERO ORDENADO
    public static int[] RandomSortedArray( int n )
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
        a[i] = r.Next(n);
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
      for (int k=0; k<a.Length; k++)
      {
        Console.Write("{0}  ", a[k]);
        if (k+1 % 10 == 0) Console.WriteLine();
      }
    }
    #endregion

    #region HANOI
    //Comentar los Console cuando se quiere solo medir el tiempo
    public static void Hanoi(int n, string origen, string auxiliar, string destino)
    {
      if (n < 1) throw new Exception("Valor cantidad de discos debe ser positivo");
      else Hanoi1(n, origen, auxiliar, destino);
    }

    static long contadorDeMovimientos = 0;
    private static void Hanoi1(int n, string origen, string auxiliar, string destino)
    {
      if (n == 1)
      {
        //Console.WriteLine("Mueve un disco de {0} a {1}", origen, destino);
        contadorDeMovimientos++;
      }
      else
      {
        Hanoi1(n - 1, origen, destino, auxiliar);
        //Console.WriteLine("Mueve un disco de {0} a {1}", origen, destino);
        contadorDeMovimientos++;
        Hanoi1(n - 1, auxiliar, origen, destino);
      }
    }
    #endregion

    #region EJERCICIOS CLASE PRÁCTICA
    //Calcular una base elevado a una potencia

    //Calcular el enésimo elemento de la sucesión de Fibonacci

    //Escribir una secuencia en el orden inverso a la que se ha dado

    //Calcular el n-ésimo elemento del conjunto de Wirth
    //1 pertenece al conjunto de Wirth
    //si x pertenece entonces 2*x+1 pertenece y 3*x+1 pertenece

    //¿Programar Hanoi sin recursividad?
    #endregion

    static void Main( string[] args )
    {

      while (true)
      {
        Console.WriteLine("\nEntre tamaño del array");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Creando array ordenado ... ");
        int[] a = RandomSortedArray(n);
        Stopwatch crono = new Stopwatch();

        #region PRUEBA DE BUSQUEDA
        while (true)
        {
          Console.WriteLine("\nENTRE VALOR A BUSCAR");
          string s = Console.ReadLine();
          if (s.Length == 0) break;
          int x = int.Parse(s);
          int pos;

          Console.WriteLine("Busqueda secuencial ...");
          crono.Restart();
          pos = PosSecuencial(a, x);
          crono.Stop();
          if (pos >= 0)
            Console.WriteLine("{0} SÏ está, a[{1}] == {2} ", x, pos, a[pos]);
          else
            Console.WriteLine("{0} NO está", x);
          Console.WriteLine("Tiempo {0} ms", crono.ElapsedMilliseconds);

          Console.WriteLine("\nBusqueda binaria ...");
          crono.Restart();
          pos = PosBinario(a, x);
          crono.Stop();
          if (pos >= 0)
            Console.WriteLine("{0} SÍ está, a[{1}] == {2} ", x, pos, a[pos]);
          else
            Console.WriteLine("{0} NO está", x);
          Console.WriteLine("Tiempo {0} ms", crono.ElapsedMilliseconds);
        }
        #endregion

        #region PRUEBA DE ORDENACION 

        //Console.WriteLine("\nCreando array desordenado de longitud {0} ... ", n);
        //int[] b = RandomArray(n);
        //int[] copia = new int[n];
        //Array.Copy(b, 0, copia, 0, n); //Creando copia del array
        //Console.WriteLine("El array original es");
        ////ListarArray(b);
        //Console.WriteLine("\nOrdenar por mínimos sucesivos ...");
        //crono.Restart();
        //OrdenarPorMinimosSucesivos(b);
        //crono.Stop();
        //Console.WriteLine("Tiempo {0} ms", crono.ElapsedMilliseconds);
       
        //Console.WriteLine("\nOrdenar por mezcla ...");
        //crono.Restart();
        //OrdenarPorMezcla(copia);
        //crono.Stop();
        //Console.WriteLine("Tiempo {0} ms", crono.ElapsedMilliseconds);

        ////Console.WriteLine("\nOrdenado por minimos sucesivos es");
        ////ListarArray(b);
        ////Console.WriteLine("\nOrdenado por mezcla es");
        ////ListarArray(copia);

        //if (EqualsArray(b, copia))
        //  Console.WriteLine("\nOK Las dos ordenaciones han dado igual resultado");
        //else
        //  Console.WriteLine("\nERROR Las dos ordenaciones no han dado igual resultado");

        #endregion
      }


      #region PRUEBA DE HANOI
      //Stopwatch crono = new Stopwatch();
      //do
      //{
      //  //Poner comentarios en Hanoi cuando se quiere solo medir el tiempo y la cantidad de movimientos
      //  Console.WriteLine("\nEntre cantidad de discos a mover");
      //  string s = Console.ReadLine();
      //  if (s.Length == 0) break;
      //  int k = Int32.Parse(s);
      //  Console.WriteLine("Movimiento de {0} discos en Torres de Hanoi\n", k);

      //  contadorDeMovimientos = 0;
      //  crono.Restart();
      //  Hanoi(k, "A", "B", "C");
      //  crono.Stop();
      //  Console.WriteLine("Total de movimientos {0}", contadorDeMovimientos);
      //  Console.WriteLine("Realizados en {0} ms", crono.ElapsedMilliseconds);
      //} while (true); 
      #endregion

    }
  }
}