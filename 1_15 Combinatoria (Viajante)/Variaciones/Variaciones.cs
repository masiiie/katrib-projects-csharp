using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace WEBOO.Programacion {
  class Program {

    #region Factorial
    static long Factorial(long n)
    {
      long result = 1;
      for (long k = 1; k <= n; k++)
        result *= k;
      return result;
    }
    #endregion

    #region PrintArray
    //Método auxiliar para escribir un array de elementos de tipo T
    static void Print<T>(T[] a, int desde, int hasta) {
      int cont = 0;
      for (int k = desde; k <= hasta; k++){
        cont++;
        if (cont % 10 == 0) Console.WriteLine();
        else Console.Write("{0,-5}", a[k]);
      }
      Console.WriteLine();
    }

    static void Print<T>(T[] a)
    {
      Print(a, 0, a.Length - 1);
    }
    #endregion

    static int total=0; //Para contar las combinaciones

    #region VARIACIONES DE N EN M SIN TENER ELEMENTOS REPETIDOS
    //Formar todas las secuencias (arrays) sin elementos repetidos de m elementos del a
    //Son N!/(N-M)! secuencias
    //Se entiende que si el a es {4, 7, 9} como secuencias de dos elementos están 
    //{4, 9}, {9, 4}, {7, 9}, {9, 7}, {4, 7} y {7, 4} en total 3! / (3-2)! = 6 
    //pero no {9, 9} ni {4, 4}
    static void VariacionesSinRepeticion<T>(T[] a, int m)
    {
      if (m > 0 && m <= a.Length)
      {
        total = 0;
        VariacionesSinRepeticion(a, 0, m);
      }
      else
        throw new ArgumentException("Longitud de la variación incorrecta");
    }

    static void VariacionesSinRepeticion<T>(T[] a, int pos, int m)
    {
      if (pos == m)
      {
        total++;
        Print(a, 0, pos - 1);
      }
      else
      {
        for (int i = pos; i < a.Length; i++)
        //En cada iteración de este ciclo se forman todas las 
        //variaciones que empiezan por a[pos] que tengan longitud m - pos
        {
          T temp = a[i];
          a[i] = a[pos];
          a[pos] = temp;
          VariacionesSinRepeticion(a, pos + 1, m);
          temp = a[i];
          a[i] = a[pos];
          a[pos] = temp;
        }
      }
    }

    #endregion
    
    #region VARIACIONES DE N EN M PUDIENDO TENER ELEMENTOS REPETIDOS
    //Todas las secuencias M elementos que se pueden formar a partir de una secuencia a de N elementos
    //Se pueden repetir elementos. Note que M no tiene que guardar ninguna relación con la longitud N de la secuencia a
    //El total de secuencias en la respuesta es de N^M, es decir N elevado a la M
    static void VariacionesConRepeticion<T>(T[] a, int m)
    {
      if (m > 0 && m <= a.Length)
      {
        total = 0;
        VariacionesConRepeticion(a, new T[m], 0);
      }
      else
        throw new ArgumentException("Longitud de la variación incorrecta");
    }
    static void VariacionesConRepeticion<T>(T[] a, T[] variacion, int pos)
      //Se tiene que llenar el array variacion
    {
      if (pos == variacion.Length)
        //Se termina cdo se ha llenado todo el array 
      {
        total++;
        //Aquí se pone el código de lo que se quiere hacer con el array
        Print(variacion);
      }
      else
        for (int i = 0; i < a.Length; i++)
        {
          variacion[pos] = a[i];
          VariacionesConRepeticion(a, variacion, pos + 1);
        }
    }
      #endregion

    #region COMBINACIONES
    ////Todas las secuencias de longitud m que se pueden extraer de una a de n elementos
    ////donde el orden de los elementos en cada secuencia resultado no es determinante
    ////Es decir la secuencia {"a", "b", "c"} se considera la misma que {"b", "c", "a"} y por tanto no se quiere repetir
    static void Combinaciones<T>(T[] a, int m) {
      total = 0;
      if (m > a.Length) return; //No se pueden formar secuencias de longitud m sin repetir elementos si m es mayor que la longitud del a
      Combinaciones(a, new T[m], 0, 0);
    }

    static void Combinaciones<T>(T[] a, T[] combinacion, int posa, int posCombinacion) {
      if (posCombinacion == combinacion.Length) {
        //Se formó una combinación
        total++;
        Print(combinacion, 0, combinacion.Length-1);
      }
      else if (posa == a.Length) 
        //Ya se recorrió todo el a, no quedan mas a poner
        return;
      else {
        combinacion[posCombinacion] = a[posa]; //Llené una celda de combinacion con una de a
        //Intentar usando otro de a poner otro mas en combinacion
        Combinaciones(a, combinacion, posa + 1, posCombinacion + 1);

        // Intentar usando otro de a ponerlo en la misma posición de combinación, es decir sin considerar el anterior puesto
        Combinaciones(a, combinacion, posa + 1, posCombinacion);
      }
    }
    static void TodasLasCombinaciones<T>(T[] a) {
      //Formar todas las combinaciones con todas las longitudes posibles
      //es (2**N)-1 si no consideramos la secuencia vacia como una posible secuencia
      //Si queremos considerar la secuencia vacia empezar el ciclo siguiente en 0
      int grantotal = 0;
      for (int i = 1; i <= a.Length; i++) {
        Combinaciones(a, i);
        grantotal += total;
      }
      total = grantotal;     
    }
    #endregion

    static void Main(string[] args)
    {

      string[] valores = { "a", "b", "c", "d", "e" };

      #region VARIACIONES SIN REPETICIÓN
      while (true)
      {
        Console.WriteLine("\nSecuencia");
        Print(valores, 0, valores.Length - 1);
        Console.WriteLine("Entre el número longitud de la variación (sin repetidos)");
        string s = Console.ReadLine();
        if (s.Length == 0) break;
        int m = System.Int32.Parse(s);
        VariacionesSinRepeticion(valores, m);
        int n = valores.Length;
        Console.WriteLine("Total de N en M es N!/(N-M)!, {0}!/({0}-{1})! = {2}/{3} debe ser {4}", n, m, Factorial(n), Factorial(n - m), total);
        //Si N=M se le llama permutaciones y entonces es = N!
      }
      #endregion

      #region VARIACIONES CON REPETICIÓN
      //while (true) //Probar hasta 11
      //{
      //  Console.WriteLine("\nSecuencia a");
      //  Print(valores, 0, valores.Length - 1);
      //  Console.WriteLine("Entre el número longitud de la variación (con repetidos)");
      //  string s = Console.ReadLine();
      //  if (s.Length == 0) break;
      //  int m = System.Int32.Parse(s);
      //  VariacionesConRepeticion(valores, m);
      //  Console.WriteLine("Total de N en M es N**M, 5**{0} debe ser {1}", m, total);
      //}
      #endregion

      #region COMBINACIONES
      while (true)
      {
        Console.WriteLine("\nSecuencia");
        Print(valores, 0, valores.Length - 1);
        Console.WriteLine("Entre el número longitud de la combinación");
        string s = Console.ReadLine();
        if (s.Length == 0) break;
        int m = System.Int32.Parse(s);
        Console.WriteLine("\nCombinaciones de {0} en {1}", valores.Length, m);
        Combinaciones(valores, m);
        Console.WriteLine("Total {0}", total);
        Console.WriteLine("\nTodas las combinaciones de {0}", valores.Length);
        TodasLasCombinaciones(valores);
        Console.WriteLine("Total {0}", total);
      }
      #endregion
    }
  }
}
