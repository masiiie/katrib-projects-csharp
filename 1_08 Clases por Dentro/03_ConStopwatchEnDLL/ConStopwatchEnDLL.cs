using System;
//using System.Diagnostics;
using System.Threading;

namespace WEBOO.Programacion
{
  class ConStopwatchEnDLL
  {
    static void Main(string[] args)
    {
      System.Diagnostics.Stopwatch crono = new System.Diagnostics.Stopwatch();

      WEBOO.Programacion.Stopwatch miCrono = new WEBOO.Programacion.Stopwatch();

      #region PROBAR TECLEAR EL NOMBRE
      while (true)
      {
        Console.WriteLine("\nTeclea tu nombre");

        crono.Restart();
        miCrono.Restart();
        //El tiempo de accionar de nuestro cronómetro se lo estamos pasando al otro
        string s = Console.ReadLine();

        miCrono.Stop();
        crono.Stop();

        if (s.Length == 0) break;
        Console.WriteLine("Demora en teclear medido con System.Diagnostics.Stopwatch {0} ms", crono.ElapsedMilliseconds);
        Console.WriteLine("Demora en teclear medido con WEBOO.Programacion.Stopwatch en DLL {0} ms", miCrono.ElapsedMilliseconds);
        Console.ReadLine();
      }
      #endregion

      #region PROBANDO RESTART Y STOP
      //Console.WriteLine("\nEchar a andar un System.Diagnostics.Stopwatch por 1000 ms...");
      //crono.Restart();
      //Thread.Sleep(1000);
      //crono.Stop();
      //Console.WriteLine("Pararlo. Tiempo marcado {0} ms", crono.ElapsedMilliseconds);
      //Console.WriteLine("Volver a hacer Restart y caminar por 2000 ms ...");
      //crono.Restart();
      //Thread.Sleep(2000);
      //crono.Stop();
      //Console.WriteLine("Pararlo. Tiempo marcado ms {0} ms", crono.ElapsedMilliseconds);
      //Console.ReadLine();

      //Console.WriteLine("\nEchar a andar un WEBOO.Programacion.Stopwatch (en DLL) por 1000 ms...");
      //miCrono.Restart();
      //Thread.Sleep(1000);
      //miCrono.Stop();
      //Console.WriteLine("Pararlo. Tiempo marcado {0} ms", miCrono.ElapsedMilliseconds);
      //Console.WriteLine("Volver a hacer Restart y caminar por 2000 ms ...");
      //miCrono.Restart();
      //Thread.Sleep(2000);
      //miCrono.Stop();
      //Console.WriteLine("Pararlo. Tiempo marcado ms {0} ms", crono.ElapsedMilliseconds);
      //Console.ReadLine();
      #endregion

      #region PROBANDO START
      //Console.WriteLine("\nEchar a andar System.Diagnostics.Stopwatch por 1000 ms...");
      //crono.Restart();
      //Thread.Sleep(1000);
      //crono.Stop();
      //Console.WriteLine("Parado. Tiempo marcado {0} ms", crono.ElapsedMilliseconds);
      //Console.WriteLine("Transcurrir otros 1000 ms con el crono parado ...");
      //Thread.Sleep(1000);
      //Console.WriteLine("Sigue parado. Tiempo marcado {0} ms", crono.ElapsedMilliseconds);
      //Console.WriteLine("Hacer Start (continua) y andar 1000 ms más ...");
      //crono.Start();
      //Thread.Sleep(1000);
      //crono.Stop();
      //Console.WriteLine("Parado. Tiempo marcado {0} ms", crono.ElapsedMilliseconds);
      //Console.ReadLine();
      #endregion

      #region PROBANDO ELAPSEDMILLISECONDS SIN HACER STOP
      miCrono.Restart();
      long i = 0;
      long instante1 = miCrono.ElapsedMilliseconds;
      while (instante1 == miCrono.ElapsedMilliseconds)
      {
        Console.WriteLine(miCrono.ElapsedMilliseconds);
        i++;
      }
      Console.WriteLine("Ciclo terminó luego de {0} incrementos en 1", i);
      #endregion

      #region PROBANDO QUE LAS VARIABLES DE INSTANCIA SON PRIVADAS
      //Descomentar las instrucciones siguientes para ver errores de compilación
      //Console.WriteLine("Instante de arrancada {0}", miCrono.arrancada);

      //Probar poniendo public arrancada
      //Console.WriteLine("Instante de arrancada {0}", miCrono.arrancada);
      //Pero en ese caso podemos también hacer
      //miCrono.arrancada = 100;
      #endregion

      #region PROBANDO PROPIEDAD SIN PARTE SET
      //Descomentar las instrucciones siguientes para ver errores de compilación
      //miCrono.ElapsedMilliseconds = 200;
      //miCrono.IsRunning = false;
      #endregion

      //CREAR UNA DLL CON STOPWATCH

      #region CP PROGRAMAR EL MÉTODO START EN LA CLASE WEBOO.PROGRAMACION.STOPWATCH
      #endregion

    }

  }
}
