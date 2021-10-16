using System;
using System.Diagnostics;
using System.Threading;

namespace WEBOO.Programacion
{
  #region CLASE STOPWATCH
  public class Stopwatch
  {
    long arrancada;
    long parada;
    bool andando;

    public Stopwatch()
    {
      arrancada = 0;
      parada = 0;
      andando = false;
    }
    public bool IsRunning
    {
      get { return andando; }
    }
    public long ElapsedMilliseconds
    {
      get
      {
        if (IsRunning)
          return Environment.TickCount - arrancada;
        else
          return parada - arrancada;
      }
    }
    public void Restart()
    {
      arrancada = Environment.TickCount;
      andando = true;
    }
    public void Start()
    {
      //TO DO ....
    }
    public void Stop()
    {
        if (IsRunning)
        {
          parada = Environment.TickCount;
          andando = false;
        }
    }
  }
  #endregion

  class ConStopwatchEnElProyecto
  {
    static void Main(string[] args)
    {
      System.Diagnostics.Stopwatch crono = new System.Diagnostics.Stopwatch();

      WEBOO.Programacion.Stopwatch miCrono = new WEBOO.Programacion.Stopwatch();

      #region PROBAR TECLEAR EL NOMBRE
      //while (true)
      //{
      //  Console.WriteLine("\nTeclea tu nombre");

      //  crono.Restart();
      //  miCrono.Restart();

      //  string s = Console.ReadLine();

      //  crono.Stop();
      //  miCrono.Stop();  

      //  if (s.Length == 0) break;
      //  Console.WriteLine("Demora en teclear medido con System.Diagnostics.Stopwatch {0} ms", crono.ElapsedMilliseconds);
      //  Console.WriteLine("Demora en teclear medido con WEBOO.Programacion.Stopwatch {0} ms", miCrono.ElapsedMilliseconds);
      //  Console.ReadLine();
      //}
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

      //Console.WriteLine("\nEchar a andar un WEBOO.Programacion.Stopwatch por 1000 ms...");
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

      #region PROBANDO START de System.Diagnostic.Stopwatch
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
      //miCrono.Restart();
      //long i = 0; 
      //long instante1 = miCrono.ElapsedMilliseconds;
      //while (instante1 == miCrono.ElapsedMilliseconds)
      //{
      //  i++;
      //}
      //Console.WriteLine("En un milisegundo el ciclo hizo {0} iteraciones incrementando i", i);
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

      #region CP Programar el método Start en la clase WEBOO.Programacion.Stopwatch
      #endregion

      #region Compilando una clase como DLL independiente
      //Comentar el código de WEBOO.Programacion.Stopwatch e intentar compilar el programa de prueba

      //Crear un proyecto Class Library dentro de la solución y compilar la clase WEBOO.Programacion.Stopwatch

      //Añadir como DLL la clase al proyecto

      //Compilar y ejecutar usando la DLL

      //Salir de VS, mover el exe y la DLL a otra carperta y ejecutar
      #endregion

    }

  }
}
