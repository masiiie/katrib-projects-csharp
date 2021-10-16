using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WEBOO.Programacion
{
  class Program
  {
    #region MÉTODO PARA AVERIGUAR SI UN NÚMERO ES PRIMO
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

    static void Main( string[] args )
    {
      //DETERMINAR SI UN NÚMERO K ES PRIMO
      long p = 0; string s;
      while (true)
      {
        do
        {
          Console.WriteLine("\nEntre un número > 1 para saber si es primo");
          s = Console.ReadLine();
        }
        while (s.Length != 0 && (!long.TryParse(s, out p) || p < 1));

        if (s.Length == 0) break;

        #region Determinar si es primo in line
        //bool esprimo = true;
        //long j = 2;
        //while (j < n) //Quiero recorrer todos los valores desde j=2 hasta n-1
        //{ //Probar si alguno menor que el número lo divide
        //  if (n % j == 0)
        //  {
        //    esprimo = false; break; //Encontró uno que lo divide, ya no es primo
        //  }
        //  j++;
        //}
        //if (esprimo)
        //  Console.WriteLine("\n{0} es primo", n);
        //else
        //  Console.WriteLine("\n{0} NO es primo", n);
        #endregion

        #region Usando un método para encapsular
        //if (EsPrimo(p))
        //  Console.WriteLine("\n{0} es primo", p);
        //else
        //  Console.WriteLine("\n{0} NO es primo", p);
        #endregion
      }
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
