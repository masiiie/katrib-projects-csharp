using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace WEBOO.Programacion {
  class Program {

    static int[,] distancias;
    static int[] ciudades;
    static string[] nombres;
    static int menorDistancia;
    static int[] mejorCamino;

    #region METODOS PARA IMPRIMIR
    //Método auxiliar para escribir un array de elementos de tipo T
    static void Print(int[] a, int desde, int hasta)
    {
      int cont = 0;
      for (int k = desde; k <= hasta; k++)
      {
        cont++;
        if (cont % 10 == 0) Console.WriteLine();
        else Console.Write("{0} ", nombres[a[k]]);
      }
      Console.WriteLine();
    }
    static void Print(int[] a)
    {
      Print(a, 0, a.Length - 1);
    }
    #endregion

    static int SumaDistancias(int[] camino, int m) {
      int result = 0;
      for (int i = 0; i < m - 1; i++) result += distancias[camino[i], camino[i + 1]];
      return result;
    }

    #region PERMUTACIONES Y VARIACIONES DE M ELEMENTOS SIN REPETIR
    static void VariacionesSinRepeticion(int[] a, int pos, int m)
    {
      if (pos == m)
      {
        #region Mejor camino empezando por cualquier ciudad
        //int suma = SumaDistancias(a, m);
        ////Descomentar si se quiere imprimir el recorrido
        //Print(a);
        //Console.WriteLine(suma);
        //if (suma < menorDistancia)
        //{
        //  menorDistancia = suma;
        //  System.Array.Copy(a, 0, mejorCamino, 0, m);
        //  //Copiar el mejor camino hasta el momento
        //}
        #endregion

        #region Mejor camino empezando por una fija
        int suma = distancias[0, a[0]] + SumaDistancias(a, m);
        Print(a);
        Console.WriteLine(suma);
        if (suma < menorDistancia)
        {
          menorDistancia = suma;
          System.Array.Copy(a, 0, mejorCamino, 0, m);
          //Copiar el mejor camino hasta el momento
        }
        #endregion
      }
      else
      {
        for (int i = pos; i < a.Length; i++)
        {
          int temp = a[i];
          a[i] = a[pos];
          a[pos] = temp;
          VariacionesSinRepeticion(a, pos + 1, m);
          temp = a[i];
          a[i] = a[pos];
          a[pos] = temp;
        }
      }
    }
    static void Permutaciones(int[] a) {
      //Cuando la longitud de las secuencias es la misma que la cantidad de elementos de a se le llama permutaciones
      //Son n! secuencias (arrays) donde n es la longitud de origen. Note que es lo mismo que n!/(n-m)! donde m == n
      VariacionesSinRepeticion(a, 0, a.Length);
    }
    #endregion

    static void Main(string[] args) {

      #region CALCULO DEL VIAJANTE POR FUERZA BRUTA
      distancias = new int[,] {{ 0, 60, 30, 40, 35},
                                {60,  0, 15, 55, 30},
                                {30, 15,  0, 75, 45},
                                {40, 55, 75,  0, 85},
                                {35, 30, 45, 85,  0}};
      nombres = new string[] { "Habana", "San Jose", "Bauta", "Madruga", "Guines" };
      menorDistancia = int.MaxValue;

      #region MEJOR CAMINO PASANDO POR TODAS LAS CIUDADES
      //ciudades = new int[] { 0, 1, 2, 3, 4 };
      //mejorCamino = new int[ciudades.Length];
      //Permutaciones(ciudades);
      //Console.WriteLine("\nEl mejor camino pasando por todas las ciudades es ");
      //for (int k = 0; k < mejorCamino.Length; k++)
      //  Console.Write("{0}  ", nombres[mejorCamino[k]]);
      //Console.WriteLine();
      //Console.WriteLine("Recorriendo una distancia de {0}", menorDistancia);
      #endregion

      #region MEJOR CAMINO SALIENDO DE LA HABANA
      ciudades = new int[] { 1, 2, 3, 4 };
      mejorCamino = new int[ciudades.Length];
      Permutaciones(ciudades);
      Console.WriteLine("\nEl mejor camino saliendo de la Habana es ");
      Console.Write("Habana ");
      for (int k = 0; k < mejorCamino.Length; k++)
        Console.Write("{0} ", nombres[mejorCamino[k]]);
      Console.WriteLine();
      Console.WriteLine("Recorriendo una distancia de {0}", menorDistancia);
      #endregion

      #endregion
    }
  }
}

//EJERCICIOS CLASE PRACTICA
//1- Fijar una ciudad de partida
//2- Mejorar el algoritmo no siguiendo un camino en cuanto de un recorrido mayor que el menor encontrado hasta el momento
