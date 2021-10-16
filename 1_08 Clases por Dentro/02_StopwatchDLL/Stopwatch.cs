using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WEBOO.Programacion
{
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
}
