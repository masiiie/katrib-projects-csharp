using System;

namespace WEBOO.Programacion
{
  class Fecha
  {
    public int Dia { get; private set;}
    public int Mes { get; private set; }
    public int Año { get; private set; }

    public Fecha(int d, int m, int a)
    {
      if (FormanFecha(d, m, a))
      {
        Dia = d; Mes = m; Año = a;
      }
      else 
        throw new Exception("Fecha incorrecta");
    }

    #region MÉTODOS PRIVADOS
    private bool FormanFecha(int d, int m, int a)
    {
      if (m >= 1 && m <= 12 && a>=0)
      {
        int ultimo = UltimoDiaDelMes(m, a);
        if (d > 0 && d <= ultimo) return true;
      }
      return false;
    }
    private int UltimoDiaDelMes(int m, int a)
    {
      switch (m)
      {
        case 2:
          //Bisiesto es si es múltiplo de 4 pero no de 100
          //o si es múltiplo de 400
          if (a%4==0 && a%100!=0 || a%400==0) return 29;
          else return 28;
        case 4: case 6: case 9: case 11: 
          return 30;
        default: 
          return 31;
      }
    }
    #endregion

    //Devuelve una nueva fecha con el día siguiente
    public Fecha Mañana()
    {
      int ultimo = UltimoDiaDelMes(Mes, Año);
      if (Dia == ultimo)
      {
        if (Mes == 12) return new Fecha(1, 1, Año + 1);
        else return new Fecha(1, Mes + 1, Año);
      }
      else return new Fecha(Dia + 1, Mes, Año);
    }

    //Devuelve una nueva fecha con el día siguiente
    public void CambiaAMañana()
    {
      int ultimo = UltimoDiaDelMes(Mes, Año);
      if (Dia == ultimo)
      {
        if (Mes == 12) 
        {
          Dia = 1;
          Mes = 1;
          Año = Año + 1;
        }
        else 
        { 
          Dia = 1;
          Mes = Mes + 1;
        }
      }
      else 
        Dia = Dia + 1;
    }

    #region REDEFINIENDO COMPARADOR DE == Y !=
    //public static bool operator ==(Fecha f1, Fecha f2)
    //{
    //  return (f1.Dia == f2.Dia && f1.Mes == f2.Mes
    //          && f1.Año == f2.Año);
    //}
    //public static bool operator !=(Fecha f1, Fecha f2)
    //{
    //  return (f1.Dia != f2.Dia || f1.Mes != f2.Mes
    //          || f1.Año != f2.Año);
    //}
    #endregion

    #region CLASE PRACTICA. Implementar los siguientes métodos
    public Fecha Ayer()
    {
      //Implementar
      //Devolver la fecha de ayer
      throw new NotImplementedException();
    }
    public void PasaDias(int n)
    {
      //Implementar
      //Cambiar la fecha por la fecha luego de pasar n días
      throw new NotImplementedException();
    }
    public int DiferenciaDias(Fecha otraFecha)
    {
      //Implementar
      //Retorna la diferencia de dias entre las dos fechas 
      //(negativo si otraFecha es anterior a la fecha del objeto)
      throw new NotImplementedException();
    }

    public string ConvierteAString()
    {
      //Implementar
      //Retorna un string en el formato (dd/mm/aa)
      throw new NotImplementedException();
    }
    #endregion

  }
  
  class Program
  {
    static void Main(string[] args)
    {
      //ERROR de Compilación, el constructor exige parámetros;
      //Fecha f = new Fecha();


      Fecha f1 = new Fecha(31, 12, 2012);
      Fecha f2 = f1;
      Fecha f3 = new Fecha(31, 12, 2012);

      //Acceso a las propiedades
      Console.WriteLine("\nCreando fechas ...");
      Console.WriteLine("f1 es {0}/{1}/{2}", f1.Dia, f1.Mes, f1.Año);
      Console.WriteLine("f2 al que se le ha asignado f1 es {0}/{1}/{2}", f2.Dia, f2.Mes, f2.Año);
      Console.WriteLine("f3 creado con los mismos valores es {0}/{1}/{2}", f3.Dia, f3.Mes, f3.Año);

      //ERROR de Compilación, la propiedad Dia no se puede cambiar desde fuera, su parte set es privada
      //f1.Dia = 25;

      //ERROR de Compilación, el método FormanFecha es privado no se puede usar externamente
      //Console.WriteLine(f1.FormanFecha(2, 2, 2));

      Console.WriteLine("\nComparando fechas ...");
      Console.WriteLine("f1 es {0}/{1}/{2}", f1.Dia, f1.Mes, f1.Año);
      Fecha f4 = f1.Mañana();
      Console.WriteLine("Poniendo en f4 el resultado de f1.Mañana()");
      Console.WriteLine("f4 es {0}/{1}/{2}", f4.Dia, f4.Mes, f4.Año);

      Console.WriteLine("Cambiando f1 a la fecha siguiente con f1.CambiaAMañana()");
      f1.CambiaAMañana();
      Console.WriteLine("f1 es {0}/{1}/{2}", f1.Dia, f1.Mes, f1.Año);
      Console.WriteLine("Comprobando que f2 sigue siendo el mismo objeto que f1");
      Console.WriteLine("f2 es {0}/{1}/{2}", f2.Dia, f2.Mes, f2.Año);

      //Ejecutar comentando y descomentando la definición de operator==
      //f1 seguirá siendo siempre igual a f2 independientemente de que no se haya redefinido el operador ==
      Console.WriteLine("\nComparando con ==");
      Console.WriteLine("f1 == f2 es {0}", f1 == f2);
      //f1 será igual a f4 según se haya redefinido el operador ==
      Console.WriteLine("f1 == f4 es {0}", f1 == f4);

      //Probar el bisiesto
      Console.WriteLine("\nProbando el caso bisiesto");
      Fecha f5 = new Fecha(28, 2, 2012);
      Fecha mañana = f5.Mañana();
      Console.WriteLine("f5 es {0}/{1}/{2}", f5.Dia, f5.Mes, f5.Año);
      Console.WriteLine("f5.Mañana es {0}/{1}/{2}", mañana.Dia, mañana.Mes, mañana.Año);
    }
  }
}

