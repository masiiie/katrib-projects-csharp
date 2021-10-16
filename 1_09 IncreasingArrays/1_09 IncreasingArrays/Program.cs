using System;

namespace WEBOO.Programacion
{

  #region SUPER ARRAY
  class SuperArray
  {
    long[] items;
    const int defaultSize = 20;
    void IncreaseArray()
    {
      long[] temp = new long[items.Length + defaultSize];
      System.Array.Copy(items, 0, temp, 0, items.Length);
      items = temp;
    }

    public SuperArray()
    {
      items = new long[defaultSize];
      Count = 0;
    }

    public int Count { get; private set; }

    public void Add(long x)
    {
      if (Count == items.Length)
        IncreaseArray();
      items[Count] = x;
      Count++;
    }

    public long this[int i]
    {
      get
      {
        if (i < 0 || i >= Count)
          throw new IndexOutOfRangeException();
        return items[i];
      }
      set
      {
        if (i < 0 || i >= Count)
          throw new IndexOutOfRangeException();
        items[i] = value;
      }
    }

    #region EJERCICIOS PARA CLASE PRÁCTICA
    //CP Implementar bool Contains(int x); devuelve true si en el array hay un valor igual a x
    //CP Implementar void Remove(int x); quita la 1ra ocurrencia de x y desplaza a la izquierda los elementos que están después
    //CP Implementar void InsertAt(int x, int position); inserta x en la posición i (si es válida) y desplaza hacia la derecha los elementos que están después
    //CP Implementar void RemoveAt(int position); quita el elemento en la posición y desplaza hacia la izquierda los siguientes 
    #endregion
  }
  #endregion

  class Program
  {
    static void Main(string[] args)
    {

      #region LEER UNA SECUENCIA DE ENTEROS Y LISTAR LOS QUE SON MAYORES QUE EL PROMEDIO
      ////Probar ejecutando con una entrada de más de 10 elementos
      //long suma = 0;
      //int i = 0;
      //long[] numeros = new long[10];
      //while (true)
      //{
      //  Console.Write("Entra un número entero ");
      //  string s = Console.ReadLine();
      //  if (s.Length == 0) break;
      //  if (i >= numeros.Length)
      //    throw new Exception("Tamaño de array excedido");
      //  numeros[i] = long.Parse(s);
      //  suma += numeros[i];
      //  i++;
      //}
      //if (i == 0)
      //  Console.WriteLine("No se entró ningún número");
      //else
      //{
      //  double promedio = suma / (double)i;
      //  Console.WriteLine("El promedio es {0}. Son mayores que el promedio",
      //                     promedio);
      //  for (int k = 0; k < i; k++)
      //    if (numeros[k] > promedio)
      //      Console.WriteLine("  {0}", numeros[k]);
      //}
      #endregion

      #region USANDO SUPER ARRAY
      //Probar ejecutando con una entrada de más de 10 elementos
      long total = 0;
      SuperArray valores = new SuperArray();
      while (true)
      {
        Console.Write("Entra un número entero ");
        string s = Console.ReadLine();
        if (s.Length == 0) break;
        long numero = long.Parse(s);
        valores.Add(numero);
        total += numero;
      }
      if (valores.Count == 0)
        Console.WriteLine("No se entró ningún número");
      else
      {
        double promedio = total / (double)(valores.Count);
        Console.WriteLine("\nEl total es {0} y el promedio es {1}", 
                          total, promedio);
        Console.WriteLine("Son mayores que el promedio");
        for (int k = 0; k < valores.Count; k++)
          if (valores[k] > promedio)
            Console.WriteLine("  {0} en posicion {1}", valores[k], k);
      }

      Console.WriteLine("valores[5] es {0}", valores[5]);
      Console.WriteLine("Asignando valores[5] = 1000");
      valores[5] = 1000;
      Console.WriteLine("valores[5] es {0}", valores[5]);

      #region ERRORES DE COMPILACION
      //valores.Count = 20;
      //Console.WriteLine(valores.defaultSize);
      #endregion

      #region EXCEPCIONES EN EJECUCION
      //valores.Count = 20;
      //Console.WriteLine(valores[valores.Count]);
      //Console.WriteLine(valores[-1]);
      #endregion


      #endregion

    }
  }
}

#region CLASE PRACTICA
//CP Diseñe e Implemente una clase Polinomio
//CP Diseñe e Implemente una clase Poligono en el plano
#endregion

