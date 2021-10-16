using System;
using System.Diagnostics;


namespace WEBOO.Programacion
{
  class Program
  {
    static void Main(string[] args)
    {
      #region 1ER PROGRAMA
        //Console.WriteLine("Hola. Bienvenido al curso de Programación");
      #endregion

      #region 2DO PROGRAMA. INTERACTUANDO CON EL USUARIO
      //Console.WriteLine("Hola, teclea tu nombre por favor");
      //string nombre = Console.ReadLine();

      //Console.Write("Hola ");
      //Console.Write(nombre);
      //Console.WriteLine(". Bienvenido al curso de Programación");

      ////De otra forma (concatenando cadenas)
      //Console.WriteLine("Hola " + nombre + ". Bienvenido al curso de Programación");

      ////De otra forma (con formato)
      //Console.WriteLine("Hola {0}. Bienvenido al curso de Programación", nombre);

      #endregion

      #region 3ER PROGRAMA. MIDIENDO EL TIEMPO DE TECLADO USANDO EL TIPO STOPWATCH.
      //Stopwatch crono = new Stopwatch();
      //Console.WriteLine("Hola, teclea tu nombre por favor");

      //crono.Start();
      //string nombre = Console.ReadLine();
      //crono.Stop();
      //Console.WriteLine("Hola {0}. Bienvenido al curso de Programación", nombre);
      //Console.WriteLine("Te has demorado {0} ms en teclear tu nombre", crono.ElapsedMilliseconds);

      //Console.WriteLine("A una velocidad de {0} caracteres por segundo",
      //                   (nombre.Length / (float)crono.ElapsedMilliseconds) * 1000); 
      //// Probar sin el casting (float) para que se vea la diferencia

      //Console.WriteLine("Días en un int {0}", int.MaxValue / 1000 / 60 / 60 / 24);
      //Console.WriteLine("Años en un long {0}", long.MaxValue / 1000 / 60 / 60 / 24 / 365);
      #endregion

      #region 4TO PROGRAMA. CREANDO MÁS DE UN OBJETO STOPWATCH
      //Stopwatch crono = new Stopwatch();
      //Stopwatch cronoGlobal = new Stopwatch();

      //cronoGlobal.Start();
      //Console.WriteLine("Hola, teclea tu nombre por favor");
      //crono.Start();
      //string nombre1 = Console.ReadLine();
      //crono.Stop();
      //Console.WriteLine("Te has demorado {0} ms en teclear {1}", crono.ElapsedMilliseconds, nombre1);

      //Console.WriteLine("\nTeclea de nuevo el nombre");
      //crono.Restart();
      //string nombre2 = Console.ReadLine();
      //crono.Stop();
      //Console.WriteLine("Te has demorado {0} ms en teclear {1} por 2da vez", crono.ElapsedMilliseconds, nombre1);

      //Console.WriteLine("\nTiempo total de ejecución {0} ms", cronoGlobal.ElapsedMilliseconds);
      #endregion

      #region CP EJERCICIOS
      //Escriba cuánto se demora en teclear 4 veces el nombre
      //Escriba tres numeros y halle el menor y el mayor de los tres
      //Resuelva el problema 4 pero usando un solo cronometro, analice la diferencia
      //Que el programa le escriba una cadena y le pida repetirla
      //Qué limitaciones tienen estos programas para garantizar que se ha tecleado correctamente el nombre. ¿Cómo puede solucionarlo?
      #endregion

    }
  }
}
