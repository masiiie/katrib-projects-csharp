using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace WEBOO.Programacion {
  class Program {

    #region FACTORIAL
    public static long Factorial(long n)
    {
      if (n <= 0) throw new Exception("Número debe ser positivo");
      else return FactorialInterno(n);
    }

    static long FactorialInterno(long n)
    {
      if (n==1) return 1;
      else 
        return n * FactorialInterno(n - 1);
    }

    static long FactorialIterativo(long n)
    {
      if (n < 0) throw new Exception("Parámetro debe ser positivo");
      long result = 1;
      for (long k = 1; k <= n; k++) result *= k;
      return result;
    }
    #endregion

    #region BIG FACTORIAL

    public static decimal BigFactorial(long n)
    {
      if (n <= 0) throw new Exception("Número debe ser positivo");
      else return BigFactorialInterno(n);
    }

    static decimal BigFactorialInterno(long n)
    {
      decimal result = 1;
      if (n == 1) return result;
      else
        return n * BigFactorialInterno(n - 1);
    }

    static decimal BigFactorialIterativo(long n)
    {
      if (n < 0) throw new Exception("Parámetro debe ser positivo");
      decimal result = 1;
      for (decimal k = 1; k <= n; k++) result *= k;
      return result;
    }
    #endregion

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
    static int Pos( int[] a, int x )
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
 
    #region MAXIMO COMUN DIVISOR
    static int Mcd(int a, int b) {
      if (a < 0 || b < 0) throw new Exception("Parámetros deben ser positivos");
      else if (b > a) return Mcd(b, a);
      else if (b == 0) return a;
      else return Mcd(a - b, b);
    }
    #endregion

    #region FIBONACCI
    
    static long Fibonacci(int n)
    {
        if (n <= 1) return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    static long FibonacciIterativo(int n)
    {
        if (n < 1) throw new Exception("Parámetro debe ser positivo");
        long ultimo = 1, penultimo = 1;
        for (int k = 3; k <= n; k++)
        {
            long temp = penultimo; penultimo = ultimo; ultimo = ultimo + temp;
        }
        return ultimo;
    } 
    #endregion

    #region CREATE SORTED RANDOM ARRAY
    public static int[] RandomSortedArray( int n )
    {
      int[] a = new int[n];
      Random r = new Random();
      a[0] = r.Next(5);
      for (int i = 1; i < a.Length; i++)
        a[i] = a[i - 1] + r.Next(5);
      return a;
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

      #region PRUEBA DE FACTORIAL
      //do
      //{
      //  Console.WriteLine("\nEntre el numero a hallar factorial (solo Enter para terminar)");
      //  string s = Console.ReadLine();
      //  if (s.Length == 0) break;
      //  int k = Int32.Parse(s);

      //  //Con 21 ya da negativo
      //  Console.WriteLine("\nFactorial recursivo (con long) de {0} es \t{1}", k, Factorial(k));
      //  Console.WriteLine("\nFactorial iterativo (con long) de {0} es \t{1}", k, FactorialIterativo(k));

      //  //Probar con el decimal para ver mayor representación, idea del costo de lo que sea proporcional a factorial
      //  //con 28 ya da overflow
      //  Console.WriteLine("\nFactorial recursivo (con decimal) de {0} es \t{1}", k, BigFactorial(k));
      //  Console.WriteLine("\nFactorial iterativo (con decimal) de {0} es \t{1}", k, BigFactorialIterativo(k));
      //} while (true); 
      #endregion
      
      #region PRUEBA DE BÚSQUEDA (SECUENCIAL Y BINARIA)
      //while (true)
      //{
      //  Console.WriteLine("Entre tamaño del array");
      //  int n = int.Parse(Console.ReadLine());
      //  int[] a = RandomSortedArray(n);
      //  Console.WriteLine("Primer elemento del array es {0}, ultimo elemento del array es {1}", a[0], a[a.Length - 1]);
      //  Stopwatch crono = new Stopwatch();
      //  while (true)
      //  {
      //    Console.WriteLine("\nEntre valor a buscar");
      //    string s = Console.ReadLine();
      //    if (s.Length == 0) break;
      //    int x = int.Parse(s);
      //    int pos;
      //    crono.Restart();
      //    pos = PosSecuencial(a, x);
      //    crono.Stop();
      //    Console.WriteLine("{0} está en pos {1} búsqueda secuencial en {2} ms", x, pos, crono.ElapsedMilliseconds);
      //    crono.Restart();
      //    pos = PosBinarioIterativo(a, x);
      //    crono.Stop();
      //    Console.WriteLine("{0} está en pos {1} búsqueda binaria iterativa en {2} ms", x, pos, crono.ElapsedMilliseconds);
      //    crono.Restart();
      //    pos = Pos(a, x);
      //    crono.Stop();
      //    Console.WriteLine("{0} está en pos {1} búsqueda binaria recursiva {2} ms", x, pos, crono.ElapsedMilliseconds);
      //  }
      //}
      #endregion

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

      #region Prueba de MCD
      //do {
      //  Console.WriteLine("\nEntre números a hallar el MCD (solo Enter para terminar)");
      //  string s1 = Console.ReadLine();
      //  if (s1.Length == 0) break;
      //  string s2 = Console.ReadLine();
      //  int a = Int32.Parse(s1);
      //  int b = Int32.Parse(s2);
      //  Console.WriteLine("\nMCD de {0} y {1} es {2}", a, b, Mcd(a, b));
      //} while (true); 
      #endregion

      #region Prueba de Fibonacci
        ////Probar con valores hasta que se note la diferencia de tiempo entre la solución recursiva y la iterativa (42)
        //do
        //{
        //    Console.WriteLine("\nEntre el número a buscar de Fibonacci (solo Enter para terminar)");
        //    string s4 = Console.ReadLine();
        //    if (s4.Length == 0) break;
        //    int k = Int32.Parse(s4);
        //    Console.WriteLine("El número {0} de la sucesión de Fibonacci (via iterativa) es {1}", k, FibonacciIterativo(k));
        //    Console.WriteLine("El número {0} de la sucesión de Fibonacci (via recursiva) es {1}", k, Fibonacci(k));
        //} while (true); 
      #endregion

    }
  }
}