using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WEBOO.Programacion
{
  class Program
  {
    #region Método para averiguar si un número es primo
    public static bool EsPrimo(long n)
    {
      #region Usando ciclo while
      long j = 2;
      while (j < n) //Quiero recorrer todos los valores desde j=2 hasta n-1
      { //Probar si alguno menor que el número lo divide
        if (n % j == 0)
        {
          return false; //Encontró uno que lo divide, ya no es primo
        }
        j++;
      }
      return true; //Si ninguno lo divide es primo
      #endregion

      #region Usando ciclo for
      //for (int k = 0; k <= n - 1; k++)
      //  //Repetir una acción una cantidad n de veces

      //  for (long j = 2; j < n; j++)
      //    if (n % j == 0) return false;
      //return true;
      #endregion

      #region Más eficiente
      //long raiz = (long)Math.Sqrt(n);
      //for (long j = 2; j < raiz; j++)
      //  if (n % j == 0) return false;
      //return true;
      #endregion

    }
    #endregion

    #region Método para listar los pares en un intervalo
    public static void ListaPares(int m, int n)
    {

      for (int k = (m % 2 == 0) ? m : m + 1; 
           k <= n; 
           k += 2)
        Console.WriteLine(k);
    }
    #endregion

    #region Método para calcula el n-ésimo elemento de Fibonacci
    public static long Fibonacci(int n)
    {
      long ultimo = 1;
      long penultimo = 1;
      for (int k = 3; k <= n; k++)
      {
        long t = penultimo;
        penultimo = ultimo;
        ultimo = ultimo + t;
      }
      return ultimo;
    }
    #endregion

    static void Main(string[] args)
    {
      #region Determinar si un número k es primo
      //long p = 0; string s;
      //while (true)
      //{
      //  #region Entrar el número
      //  //do
      //  //{
      //  //  Console.WriteLine("\nEntre un número > 1 para saber si es primo");
      //  //  s = Console.ReadLine();
      //  //}
      //  //while (s.Length != 0 && (!long.TryParse(s, out p) || p < 1));
      //  //if (s.Length == 0) break;
      //  #endregion

      //  #region Determinar si es primo
      //  //bool esprimo = true;
      //  //long j = 2;
      //  //while (j < n) //Quiero recorrer todos los valores desde j=2 hasta n-1
      //  //{ //Probar si alguno menor que el número lo divide
      //  //  if (n % j == 0)
      //  //  {
      //  //    esprimo = false; break; //Encontró uno que lo divide, ya no es primo
      //  //  }
      //  //  j++;
      //  //}
      //  //if (esprimo)
      //  //  Console.WriteLine("\n{0} es primo", n);
      //  //else
      //  //  Console.WriteLine("\n{0} NO es primo", n);
      //  #endregion

      //  #region Usando un método para encapsular
      //  //if (EsPrimo(p))
      //  //  Console.WriteLine("\n{0} es primo", p);
      //  //else
      //  //  Console.WriteLine("\n{0} NO es primo", p);
      //  #endregion

      //}
      #endregion

      #region Pares en un intervalo
      //int m = 0; int n;
      //string s2;
      //while (true)
      //{
      //  Console.Write("\nEntra cota inferior  ");
      //  s2 = Console.ReadLine();
      //  if (s2.Length == 0) break;
      //  if (!int.TryParse(s2, out m))
      //  {
      //    Console.WriteLine("{0} no es un número entero", s2);
      //    break;
      //  }
      //  Console.Write("Entra cota superior  ");
      //  s2 = Console.ReadLine();
      //  if (s2.Length == 0) break;
      //  if (!int.TryParse(s2, out n))
      //  {
      //    Console.WriteLine("{0} no es un número entero", s2);
      //    break;
      //  }
      //  ListaPares(m, n);
      //}
      #endregion

      #region Calcular Fibonacci
      int k;
      string s3;
      while (true)
      {
        Console.Write("\nEntra posición a calcular Fibonacci  ");
        s3 = Console.ReadLine();
        if (s3.Length == 0) break;
        if ((!int.TryParse(s3, out k)) || (k < 1))
        {
          Console.WriteLine("{0} no es un número correcto", s3);
          break;
        }
        Console.WriteLine("Fibonacci de {0} es {1}", k, Fibonacci(k));
      }
      #endregion
    }
  }
}

#region Clase Práctica Ejercicios

// Usando ciclos liste por consola la tabla de multiplicar del 1 al 9

// La sucesión de Fibonacci es la sucesión 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, ... cada término es la suma de
// los dos anteriores
// Escriba un programa que lea un número y liste el elemento de la sucesión en esa posición. 
// Ejemplo si se entra 8 se debe dar como resultado 21

// Entre un número y determine si es perfecto. Un número es perfecto si es igual a la suma de sus divisores.
// Ejemplo 6 = 1 + 2 + 3   

#endregion
