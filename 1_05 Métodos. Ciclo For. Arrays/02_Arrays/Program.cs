using System;
using System.Collections.Generic;
using System.Text;

namespace WEBOO.Programacion {


  class Program
  {
    #region MAXIMO EN UN ARRAY
    static long Max( long[] a )
    {
      if (a.Length == 0) throw new Exception("Array no tiene elementos");
      long max = a[0];
      for (int k = 1; k < a.Length; k++)
        if (a[k] > max) max = a[k];
      return max;
    }
    #endregion

    static void Main(string[] args) {

      #region LEER UNA SECUENCIA DE ENTEROS Y CALCULAR EL PROMEDIO
      //long suma = 0;
      //int cuantos = 0;
      //while (true)
      //{
      //  Console.Write("Entra un número entero ");
      //  string s = Console.ReadLine();
      //  if (s.Length == 0) break;
      //  suma += long.Parse(s);
      //  cuantos++;
      //}
      //if (cuantos == 0)
      //  Console.WriteLine("No se ha entrado ningún número");
      //else
      //  Console.WriteLine("El promedio es {0} ", suma / (double)cuantos);
      #endregion

      #region LEER UNA SECUENCIA DE ENTEROS Y LISTAR LOS QUE SON MAYORES QUE EL PROMEDIO
      long suma = 0;
      int i = 0;
      long[] numeros = new long[100];
      while (true)
      {
        Console.Write("Entra un número entero ");
        string s = Console.ReadLine();
        if (s.Length == 0) break;
        numeros[i] = long.Parse(s);
        suma += numeros[i];
        i++;
      }
      if (i == 0)
        Console.WriteLine("No se entró ningún número");
      else
      {
        double promedio = suma / (double)i;
        Console.WriteLine("El promedio es {0}. Son mayores que el promedio",
                           promedio);
        for (int k = 0; k < i; k++)
          if (numeros[k] > promedio)
            Console.WriteLine("  {0}", numeros[k]);
      }
      #endregion

      #region PRUEBA A SALIRSE DE LOS LÍMITES DE UN ARRAY
      ////Saliéndose de los límites del array, descomentar la línea a continuación para provocar excepción
      //Console.WriteLine(valores[valores.Length]);
      //numeros[1000] = 2;
      #endregion

      #region PRUEBA DE QUE TODOS LOS ELEMENTOS TIENEN QUE SER DEL MISMO TIPO
      ////Los arrays respetan el tipo de sus elementos, descomentar la línea siguiente da error de compilación
      //numeros[1] = "rojo";
      #endregion

      #region PRUEBA DE MÁXIMO DE UN ARRAY
      Console.WriteLine("El máximo valor es {0}", Max(numeros));
      #endregion
    }
  }
}

#region Ejercicios para Clase Practica
//CP Metodo que recibe dos arrays del mismo tamaño y devuelve uno con la suma de los dos

//CP Invertir un array int[] Invierte(int[] a);

//CP Saber si un array está ordenado ascendentemente bool Ascendente(int[] a)';

//CP Concatenar dos array int[] Concatenar(int[] a, int[] b);

//CP Rotar a la derecha n elementos int[] Rotar(int[] a); 
//   Rotar(new int[] {5, 10, 4, 20, 7, 100, 12}, 3) debe dar {7, 100, 12, 5, 10, 4, 20}

//CP Copiar desde un array y una posicion hacia otro array y una posicion una cantidad de elementos
//   Si sobran se deja de copiar
//   void Copiar(int[] origen, int i, int[] destino, int j, int cuantos);

#endregion

