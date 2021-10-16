using System;
using System.Diagnostics;


namespace WEBOO.Programacion
{
  class Program
  {
    static long EntraPositivo()
    {
      long k;
      while (true)
      {
        Console.WriteLine("Entra un positivo");
        string s = Console.ReadLine();
        if (long.TryParse(s, out k))
          if (k > 0) return k;
        Console.WriteLine("Te dije que teclearas un positivo");
      }
    }
    static void Main(string[] args)
    {
      #region TIPOS NUMÉRICOS ENTEROS, INT, LONG
      //Console.WriteLine("Mayor int {0}", int.MaxValue);
      //Console.WriteLine("Mayor long {0}", long.MaxValue);
      //Console.WriteLine("Días en un int {0}", int.MaxValue / 1000 / 60 / 60 / 24);
      //Console.WriteLine("Años en un long {0}", long.MaxValue / 1000 / 60 / 60 / 24 / 365);
      #endregion

      #region OPERACIONES CON TIPOS NUMÉRICOS. EXPRESIONES
      //Console.WriteLine("Entra tu edad");
      //string s = Console.ReadLine();
      //int edad = Int32.Parse(s);
      //Console.WriteLine("Tu edad dentro de 10 años es {0}", edad + 10);

      //Console.WriteLine("\nEntra longitud de un cateto");
      //double a = EntraPositivo();
      //Console.WriteLine("Entra longitud del otro cateto");
      //double b = EntraPositivo();
      //Console.WriteLine("La longitud de la hipotenusa es {0}", Math.Sqrt(a * a + b * b));

      //Console.WriteLine("\nEl mayor float es  {0}", float.MaxValue);
      //Console.WriteLine("El mayor double es {0}", double.MaxValue);

      //Console.WriteLine("Entra tu nombre");
      //Stopwatch crono = new Stopwatch();
      //crono.Start();
      //string nombre = Console.ReadLine();
      //crono.Stop();
      //Console.WriteLine("{0} te has demorado {1} ms en teclear tu nombre", nombre,
      //                  crono.ElapsedMilliseconds);
      //Console.WriteLine("Tecleando a una velocidad de {0} caracteres por segundo",
      //                   nombre.Length / crono.ElapsedMilliseconds * 1000);
      //Console.WriteLine("Tecleando a una velocidad de {0} caracteres por segundo",
      //                  nombre.Length / (crono.ElapsedMilliseconds / 1000));
      //Console.WriteLine("Tecleando a una velocidad de {0} caracteres por segundo",
      //                  (float)nombre.Length / crono.ElapsedMilliseconds * 1000);
      //Hacer descomentando las dos anteriores

      #endregion

      #region EL TIPO BOOL y LA CONDICIONAL IF
      //Stopwatch crono1 = new Stopwatch();
      //Stopwatch crono2 = new Stopwatch();
      //Console.WriteLine("Teclea tu nombre");
      //crono1.Start();
      //string nombre1 = Console.ReadLine();
      //crono1.Stop();
      //Console.WriteLine("\nVuélvelo a teclear");
      //crono2.Start();
      //string nombre2 = Console.ReadLine();
      //crono2.Stop();
      //if (nombre1 == nombre2)
      //{
      //  Console.WriteLine("\nHas tecleado igual dos veces tu nombre");
      //  Console.WriteLine("El menor tiempo de tecleo ha sido {0} ms", 
      //                     Math.Min(crono1.ElapsedMilliseconds, crono2.ElapsedMilliseconds));
      //}
      //else
      //  Console.WriteLine("Has tecleado incorrectamente, vuelve a ejecutar el programa");
      #endregion

      #region CONDICIONALES COMPROBAR MULTIPLICACIÓN
      Random r = new Random();
      r.Next(30);
      int n1 = r.Next(30);
      int n2 = r.Next(30);
      Stopwatch crono = new Stopwatch();
      Console.WriteLine("Entra el resultado de multiplicar {0} por {1}", n1, n2);
      crono.Start();
      int result = int.Parse(Console.ReadLine());
      crono.Stop();
      if (result == n1 * n2)
        Console.WriteLine("\nMultiplicación correcta, calculada en {0} ms", crono.ElapsedMilliseconds);
      else
        Console.WriteLine("\nERROR has multiplicado mal. Vuelve a ejecutar el programa");
      #endregion

      #region CONDICIONALES ANIDADAS. HALLAR EL MAYOR DE TRES NUMEROS
      //Console.Write("Teclea un primer número ");
      //int a = int.Parse(Console.ReadLine());
      //Console.Write("Teclea un segundo número ");
      //int b = int.Parse(Console.ReadLine());
      //Console.Write("Teclea un tercer número ");
      //int c = int.Parse(Console.ReadLine());
      //Console.WriteLine();

      ////CON IF ANIDADOS
      //if (a >= b)
      //{
      //  if (a >= c) Console.WriteLine("El mayor es {0}", a);
      //  else
      //    Console.WriteLine("El mayor es {0}", c);
      //}
      //else
      //{
      //  if (b >= c)
      //    Console.WriteLine("El mayor es {0}", b);
      //  else
      //    Console.WriteLine("El mayor es {0}", c);
      //}

      ////OTRA FORMA
      //Console.WriteLine("El mayor es {0}", Math.Max(a, Math.Max(b,c)));
      #endregion

      #region USANDO OPERADORES LOGICOS
      //Console.Write("Teclea un primer número ");
      //int j = int.Parse(Console.ReadLine());
      //Console.Write("Teclea un segundo número ");
      //int k = int.Parse(Console.ReadLine());
      //Console.Write("Teclea un tercer número ");
      //int m = int.Parse(Console.ReadLine());

      //if ((j >= k) && (j >= m))
      //  Console.WriteLine("El mayor es {0}", j);
      //else if ((k >= j) && (k >= m))
      //  Console.WriteLine("El mayor es {0}", k);
      //else
      //  Console.WriteLine("El mayor es {0}", m);
       #endregion

      #region EJERCICIOS
      //Escriba código para que de 
      //RAPIDO (si teclea a mas de 2 ctres por segundo)
      //REGULAR (si teclea entre 1 y 2 ctres por segundo) y 
      //LENTO (si teclea a menos de 1 cter por segundo)

      //Escriba tres veces el nombre y escoja la más rápida

      //Como mejorar la solución para no diferenciar entre mayúsculas y minúsculas

      //Leer tres números y escribirlos ordenados de menor a mayor
      
      //Leer tres valores enteros que sean posibles lados de un triángulo. 
      //Decir si forman triángulo equilátero, isósceles, escaleno, o si no pueden formar un triángulo.

      //Lea tres valores enteros y escríbalos en orden de menor a mayor y el valor promedio de los tres

      //Lea un número que sea menor o igual que 100. Con la menor cantidad de preguntas posibles determine si es primo

      //Usted puede haber escrito dos veces una misma cadena como su nombre. Escriba un programa que mida mejor su velocidad de tecleo

      //¿Puede hacer un programa que juegue al TIC TAC TOE?

      #endregion

    }
  }
}
