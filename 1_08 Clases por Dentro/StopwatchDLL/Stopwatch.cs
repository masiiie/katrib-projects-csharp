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

    public bool IsRunning { get; private set; }

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
      IsRunning = true;
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
            IsRunning = false;
        }
    }
  }
}
