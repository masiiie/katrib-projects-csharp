using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace WEBOO.Programacion {


  class Program
  {
    #region ES PRIMO
    static bool EsPrimo(int x)
    {
      int raiz = (int)Math.Sqrt(x);
      for (int i = 2; i <= raiz; i++)
        if (x % i == 0) return false;
      return true;
    }
    #endregion

    #region CREA RANDOM ARRAY
    public static int[] CreaRandomArray( int n )
    {
      int[] result = new int[n];
      Random r = new Random();
      for (int k = 0; k < result.Length; k++)
        result[k] = r.Next(n);
      return result;
    }
    #endregion

    #region LISTAR ARRAY A 10 x LINEA
    public static void Listar(int[] a)
    {
      for (int i = 0; i < a.Length; i++)
      {
        if (i % 10 == 0) Console.WriteLine();
        Console.Write("  {0}", a[i]);
      }
      Console.WriteLine();
    }
    #endregion

    #region COPY

    public static void Copy(int[] origen, int posOrigen, 
                             int[] destino, int posDestino, int longitud )
    {
      if (posOrigen >= 0 && (posOrigen + longitud) <= origen.Length && 
          posDestino >= 0 && (posDestino + longitud) <= destino.Length)
        for (int k = 0; k < longitud; k++)
          destino[posDestino + k] = origen[posOrigen + k];
      else throw new IndexOutOfRangeException("Indices fuera de rango en Copy"); 
    }
    #endregion

    #region COVERTIR UN ARRAY EN UN STRING
    static string ArrayToString( int[] a )
    {
      //Método frágil solo funciona bien cuando todos caben en una línea
      string result = "{";
      for (int i = 0; i < a.Length; i++)
        if (i == 0)
          result += a[i];
        else
          result = result + ", " + a[i];
      return result + "}";
    }
    #endregion

    #region SUMA DE ARRAYS
    static int[] Suma(int[] a, int[] b)
    {
      if (a.Length != b.Length)
        throw new ArgumentException("Los arrays deben tener la misma longitud");
      //Se conoce el tamaño del resultado
      int[] result = new int[a.Length];
      for (int i = 0; i < a.Length; i++)
        result[i] = a[i] + b[i];
      return result;
    }
    #endregion

    #region PRIMOS POR EL METODO DE ERATOSTENES
    public static bool[] CribaDeEratostenes( int n )
    {
      bool[] noprimos = new bool[n+1]; 

      noprimos[0] = true;
      noprimos[1] = true;

      for (int i = 2; i < n + 1; i++)
      {
        if (!noprimos[i])
          for (long mult = i; mult * i < n + 1; mult++)
            noprimos[mult * i] = true;
      }
      return noprimos;
    }

    #endregion

    #region ORDENACIÓN
    static void Ordenar(int[] a)
    {
      for (int k = 0; k < a.Length - 1; k++)
        for (int j = k + 1; j < a.Length; j++)
          if (a[j] < a[k])
          {
            //intercambiar a[j] con a[k]
            int temp = a[j];
            a[j] = a[k];
            a[k] = temp;
          }
    }
    #endregion

    static void Main(string[] args) {

      #region PRUEBA DE ARRAY.COPY
      //while (true)
      //{
      //  int[] a = { -1, -2, -3, -4, -5, -6, -7, -8, -9 };
      //  int[] b = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15};
      //  Console.WriteLine();
      //  Console.WriteLine("\nOrigen");
      //  Console.WriteLine(ArrayToString(a));
      //  Console.WriteLine("\nDestino");
      //  Console.WriteLine(ArrayToString(b));
      //  Console.WriteLine("\nDesde posición");
      //  int desde = int.Parse(Console.ReadLine());
      //  Console.WriteLine("Hacia posición");
      //  int hacia = int.Parse(Console.ReadLine());
      //  Console.WriteLine("Cuantos");
      //  int cuantos = int.Parse(Console.ReadLine());
      //  Copy(a, desde, b, hacia, cuantos);
      //  Console.WriteLine(ArrayToString(b));
      //  Console.WriteLine("----------------------------------");
      //  Console.ReadLine();
      //}
      #endregion

      #region SUMAR DOS ARRAYS
      //int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
      //int[] b = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
      //Console.WriteLine("Primer Array");
      //Console.WriteLine(ArrayToString(a));
      //Console.WriteLine("Segundo array");
      //Console.WriteLine(ArrayToString(b));
      ////Sumando los elementos del array
      //Console.WriteLine("\nSuma de los dos arrays");
      //Console.WriteLine(ArrayToString(Suma(a, b)));
      #endregion

      #region LISTAR PRIMOS MENORES QUE N
      //int n;
      //while (true)
      //{
      //  Console.WriteLine("Entre un valor entero");
      //  string s = Console.ReadLine();

      //  if (int.TryParse(s, out n)) break;
      //}
      //int cuantos = 0;
      //Stopwatch crono = new Stopwatch();
      //crono.Start();
      //for (int i = 2; i <= n; i++)
      //  if (EsPrimo(i))
      //  {
      //    //Console.WriteLine(i);
      //    cuantos++;
      //  }
      //crono.Stop();
      //Console.WriteLine("Hay {0} números primos menores que {1}", cuantos, n);
      //Console.WriteLine("Calculado en {0} ms", crono.ElapsedMilliseconds);

      //crono.Restart();
      //bool[] result = CribaDeEratostenes(n);
      //cuantos = 0;
      //for (int k = 2; k <= n; k++)
      //  if (!result[k])
      //  {
      //    //Console.WriteLine(k);
      //    cuantos++;
      //  }
      //crono.Stop();
      //Console.WriteLine("\nHay {0} números primos menores que {1}", cuantos, n);
      //Console.WriteLine("Calculado por método de Eratostenes {0} ms", crono.ElapsedMilliseconds);
      #endregion

      #region PROBAR ORDENACION
      //int[] a;
      //while (true)
      //{
      //  int n;
      //  while (true)
      //  {
      //    Console.WriteLine("\nEntra tamaño del array");
      //    string s = Console.ReadLine();
      //    if (int.TryParse(s, out n)) break;
      //  }
      //  a = CreaRandomArray(n);
      //  Listar(a);
      //  Ordenar(a);
      //  Listar(a);
      //}
      #endregion

      #region Pares. Usando métodos que "filtran" un array
      ////valores = new int[] { 10, 11, 20, 49, 7, 43, 28 };
      ////Console.WriteLine("\nHallar los pares de \n{0}", ArrayToString(valores));
      ////int[] pares = Pares(valores);
      ////Console.WriteLine("\nLos Pares son \n{0}", ArrayToString(pares));
      //#endregion

      //#region Crear y escribir un array sin darle valores
      //////Creando otro array
      ////int[] b = new int[5];
      ////Console.Write("{");
      ////foreach (int valor in b)
      ////  Console.Write(" {0},", valor);
      ////Console.WriteLine("\b }");
      #endregion

      #region Creación directa de un array como parámetro
      ////Puede crearse un array directamente para pasarlo como parámetro
      ////Console.WriteLine("\nPares {0} ", ArrayToString(new int[] { 2, 4, 6, 8, 10, 12, 14 }));

      ////ERROR de compilación
      ////Console.WriteLine("\nPares {0} ", ArrayToString({ 2, 4, 6, 8, 10, 12, 14 }));
      #endregion

    }
  }
}

#region Ejercicios para Clase Practica
//CP Invertir un array int[] Invierte(int[] a);

//CP Saber si un array está ordenado ascendentemente bool Ascendente(int[] a)';

//CP Concatenar dos array int[] Concatenar(int[] a, int[] b);

//CP Rotar a la derecha n elementos int[] Rotar(int[] a); 
//   Rotar(new int[] {5, 10, 4, 20, 7, 100, 12}, 3) debe dar {7, 100, 12, 5, 10, 4, 20}

//CP Copiar desde un array y una posicion hacia otro array y una posicion una cantidad de elementos
//   Si sobran se deja de copiar
//   void Copiar(int[] origen, int i, int[] destino, int j, int cuantos);

//CP Determinar si un string es palíndromo (se lee igual de izq a derecha que de derecha a izquierda
//   ignorando espacios y diferencia entre mayusculas y minusculas
//   bool Palindromo(string s)
//   "somos", "La ruta natural" y "Anita lava la tina" son palíndromos

//CP Estudiar la clase string. Implementar métodos de la clase string como métodos estáticos
// para usar en la forma Metodo(s1, s2) en lugar de s1.Metodo(s2) o en la forma
// Metodo(s) en lugar de s.Metodo()
#endregion

