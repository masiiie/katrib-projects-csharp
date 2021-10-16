using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace WEBOO.Programacion
{
  class Stopwatch
  {
    long arrancada;
    long parada;
    bool andando;

    public Stopwatch() 
    {
      arrancada = 0; 
      this.parada = 0;
      andando = false;
    }
    public void Restart()
    {
      arrancada = Environment.TickCount;
      andando = true;
    }
    public void Start()
    {
      //TODO ....
    }
    public void Stop()
    {
      parada = Environment.TickCount;
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
  }

  class Program
  {
    static void Main(string[] args)
    {
      System.Diagnostics.Stopwatch crono = new System.Diagnostics.Stopwatch();
      WEBOO.Programacion.Stopwatch miCrono = new WEBOO.Programacion.Stopwatch();
      while (true)
      {
        Console.WriteLine("\nTeclea tu nombre");
        crono.Restart();
        miCrono.Restart();
        string s = Console.ReadLine();
        crono.Stop();
        miCrono.Stop();
        if (s.Length == 0) break;
        Console.WriteLine("Demora en teclear medido con System.Diagnostics.StopWatch {0} ms", crono.ElapsedMilliseconds);
        Console.WriteLine("Demora en teclear medido con WEBOO.Programacion.StopWatch {0} ms", miCrono.ElapsedMilliseconds);

        #region Probando Restart
        crono.Restart();
        Thread.Sleep(1500);
        Console.WriteLine("\nStopwatch andando luego de 1500 ms es {0} ms", crono.ElapsedMilliseconds);
        Thread.Sleep(1000);
        Console.WriteLine("\nStopwatch andando luego de 1000 ms más es {0} ms", crono.ElapsedMilliseconds);

        miCrono.Restart();
        Thread.Sleep(1500);
        Console.WriteLine("\nStopwatch andando luego de 1500 ms es {0} ms", miCrono.ElapsedMilliseconds);
        Thread.Sleep(1000);
        Console.WriteLine("\nStopwatch andando luego de 1000 ms más es {0} ms", miCrono.ElapsedMilliseconds);
        #endregion

        #region Probando Propiedad sin parte set
        //miCrono.ElapsedMilliseconds = 200;
        //miCrono.IsRunning = false;
        #endregion

        
      }

    }
  }
}
