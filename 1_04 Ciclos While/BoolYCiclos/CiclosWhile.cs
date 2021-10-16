using System;
using System.Diagnostics;


namespace WEBOO.Programacion {
  class Program
  {

    #region 1er EJEMPLO DE CICLO MÉTODO PARA ENTRAR UN NUMERO ENTERO
    static int ReadInteger( )
    {
      string s; int n;
      while (true)
      {
        Console.WriteLine("Entre un número entero positivo");
        s = Console.ReadLine();
        if (int.TryParse(s, out n) && (n>0))
          return n;
        else
          Console.WriteLine("Número incorrecto. Repita");
      }
    }
    #endregion 

    static void Main(string[] args) {

      #region TECLEAR NOMBRE SIN CICLO

      //string nombre1, nombre2;
      //Stopwatch crono1 = new Stopwatch();
      //Stopwatch crono2 = new Stopwatch();

      //Console.WriteLine("\nTeclea tu nombre");
      //crono1.Restart();
      //nombre1 = Console.ReadLine();
      //crono1.Stop();

      //Console.WriteLine("Teclea otra vez tu nombre");
      //crono2.Restart();
      //nombre2 = Console.ReadLine();
      //crono2.Stop();

      //if (nombre1 != nombre2)
      //  Console.WriteLine("Parece que no has tecleado bien el nombre. Vuelve a ejecutar el programa");
      //else
      //  Console.WriteLine("\nBienvenido {0} el menor tiempo en teclear tu nombre ha sido de {1} ms",
      //                    nombre1, Math.Min(crono1.ElapsedMilliseconds, crono2.ElapsedMilliseconds));

      #endregion

      #region TECLEAR HASTA QUE SE TECLEE BIEN EL NOMBRE CON (CICLO DO WHILE)
      //string nombre1, nombre2;
      //Console.WriteLine("Bienvenido a C#, vamos a hacer una prueba de habilidad de tecleo");
      //Stopwatch crono1 = new Stopwatch();
      //Stopwatch crono2 = new Stopwatch();
      //do
      //{
      //  Console.WriteLine("\nTeclea tu nombre");
      //  crono1.Restart();
      //  nombre1 = Console.ReadLine();
      //  crono1.Stop();

      //  Console.WriteLine("Teclea otra vez tu nombre");
      //  crono2.Restart();
      //  nombre2 = Console.ReadLine();
      //  crono2.Stop();
      //}
      //while (nombre1 != nombre2);
      //Console.WriteLine("\nBienvenido {0} el menor tiempo en teclear tu nombre ha sido de {1} ms",
      //                  nombre1, Math.Min(crono1.ElapsedMilliseconds, crono2.ElapsedMilliseconds));
      #endregion

      //¿Dónde poner un mensaje de que se ha equivocado?
      #region TECLEAR HASTA QUE SE TECLEE BIEN EL NOMBRE CON MENSAJE SI ERROR (WHILE Y BREAK)
      //string nombre1, nombre2;
      //Console.WriteLine("Bienvenido a C#, vamos a hacer una prueba de habilidad de tecleo");
      //Stopwatch crono1 = new Stopwatch();
      //Stopwatch crono2 = new Stopwatch();
      //while (true)
      //{
      //  Console.WriteLine("\nTeclea tu nombre");
      //  crono1.Restart();
      //  nombre1 = Console.ReadLine();
      //  crono1.Stop();

      //  Console.WriteLine("Teclea otra vez tu nombre");
      //  crono2.Restart();
      //  nombre2 = Console.ReadLine();
      //  crono2.Stop();

      //  if (nombre1 == nombre2) break; //Aborta la ejecución del ciclo y sigue en la instrucción siguiente
      //  else
      //  {
      //    Console.WriteLine("Parece que no has tecleado bien el nombre. Pulsa Enter para repetir");
      //    Console.ReadLine();
      //  }
      //}
      //Console.WriteLine("Bienvenido {0} el menor tiempo en teclear tu nombre \nha sido de {1} ms",
      //                  nombre1, Math.Min(crono1.ElapsedMilliseconds, crono2.ElapsedMilliseconds));
      #endregion

      #region CICLOS. CALCULO DEL MÁXIMO COMÚN DIVISOR (FUERZA BRUTA)
      //int m, n;
      //do
      //{
      //  Console.WriteLine("\nEntra un número positivo");
      //  m = Int32.Parse(Console.ReadLine());
      //  Console.WriteLine("\nEntra otro número positivo");
      //  n = Int32.Parse(Console.ReadLine());
      //} while (m <= 0 || n <= 0); //Si no son números positivos repite

      ////Un ciclo que empiece probando con el menor de los dos y vaya restando
      ////hasta que llegue a uno que los divida a los dos, al menos llegará a 1

      //int mcd = Math.Min(m, n);
      //int iteraciones = 1; //Comprobaciones de división
      //while (m % mcd != 0 || n % mcd != 0)
      //{
      //  iteraciones++;
      //  mcd--;
      //}

      //Console.WriteLine("\nEl Máximo Común Divisor de " + m + " y " + n + " es " + mcd);
      //Console.WriteLine("Calculado en " + iteraciones + " iteraciones del ciclo");

      //-----------------------------------------------------------
      //Console.WriteLine("\nEnter para continuar ...");
      //Console.ReadLine();
      //ILUSTRAR EL METER A SU VEZ TODO ESTO EN UN CICLO PARA PROBAR CON DIFERENTES PAREJAS DE NUMEROS

      #endregion

      #region CALCULO DEL MCD CON ALGORITMO DE EUCLIDES (MENOS ITERACIONES)
      //int m, n;
      //do //Repetir hasta entrar dos números positivos
      //{
      //  Console.WriteLine("\nMDC por Algoritmo de Euclides.\nEntra un número positivo");
      //  m = Int32.Parse(Console.ReadLine());
      //  Console.WriteLine("Entra otro número positivo");
      //  n = Int32.Parse(Console.ReadLine());
      //} while (m <= 0 || n <= 0);

      //int a = m; int b = n;

      //int r = a % b;
      //int iteraciones = 1;
      //while (r != 0)
      //{
      //  iteraciones++;
      //  a = b;
      //  b = r;
      //  r = a % b;
      //}

      //Console.WriteLine("El MCD de {0} y {1} es {2}. Calculado por Euclides en {3} iteraciones",
      //                    m, n, b, iteraciones);
      ////CP Demostrarlo matemáticamente que calcula el máximo común divisor
      #endregion

      #region CICLO DENTRO DE CICLO
      //while (true)
      //{
      //  int m, n;
      //  m = ReadInteger();
      //  n = ReadInteger();

      //  Console.WriteLine("\nMDC por Algoritmo Fuerza Bruta...");
      //  int mcd = Math.Min(m, n);
      //  int iteraciones = 1;
      //  while (m % mcd != 0 || n % mcd != 0)
      //  {
      //    iteraciones++;
      //    mcd--;
      //  }
      //  Console.WriteLine("El MCD de {0} y {1} es {2}. Calculado en {3} iteraciones",
      //                      m, n, mcd, iteraciones);

      //  Console.WriteLine("\nMDC por Algoritmo de Euclides...");
      //  int a = m; int b = n;
      //  int r = a % b;
      //  iteraciones = 1;
      //  while (r != 0)
      //  {
      //    iteraciones++;
      //    a = b;
      //    b = r;
      //    r = a % b;
      //  }
      //  Console.WriteLine("El MCD de {0} y {1} es {2}. Calculado por Euclides en {3} iteraciones",
      //                      m, n, b, iteraciones);
      //  Console.WriteLine();
      //}
      #endregion

      #region TECLEAR NOMBRE CON CANTIDAD DE VECES (WHILE Y BREAK)
      //string nombre1 = "";      //Mostrar lo que pasa si estas variables no están inicializadas    
      //string nombre2 = "";

      //Stopwatch crono1 = new Stopwatch();
      //Stopwatch crono2 = new Stopwatch();
      //int veces = 3;
      //while (veces > 0)
      //{
      //  Console.WriteLine("\nTeclea tu nombre");
      //  crono1.Restart();
      //  nombre1 = Console.ReadLine();
      //  crono1.Stop();
      //  Console.WriteLine("Teclea otra vez tu nombre");
      //  crono2.Restart();
      //  nombre2 = Console.ReadLine();
      //  crono2.Stop();
      //  if (nombre1 == nombre2) break;
      //  else
      //  {
      //    Console.WriteLine("Parece que no has tecleado bien el nombre.");
      //    veces--;
      //  }
      //}
      //if (veces == 0)
      //  Console.WriteLine("Lo siento agotaste todas las posibilidades");
      //else
      //  Console.WriteLine("Bienvenido {0} el menor tiempo en teclear tu nombre ha sido de {1} ms",
      //                  nombre1, Math.Min(crono1.ElapsedMilliseconds, crono2.ElapsedMilliseconds));
      #endregion

      #region CICLO CON "ACUMULADOR" COMPARADOR. LEE UNA SECUENCIA DE NÚMEROS Y ENCONTRAR EL MAYOR
      //Console.WriteLine("Encontrar el número mayor de una secuencia (Teclee solo Enter para terminar)");
      //Console.WriteLine("\nEntre un primer número");
      //string s = Console.ReadLine();
      //if (s.Length != 0)
      //{
      //  int mayor = Int32.Parse(s);
      //  while (true)
      //  {
      //    Console.WriteLine("Entre otro número");
      //    s = Console.ReadLine();
      //    if (s.Length == 0) break;
      //    int n = Int32.Parse(s);
      //    if (n > mayor) mayor = n;
      //  }
      //  Console.WriteLine("\nEl mayor es {0}", mayor);
      //}
      //else
      //  Console.WriteLine("No ha dado ninguna secuencia");
      #endregion

      #region CP EJERCICIOS PROPUESTOS
      //Mejore el código anterior para poder rectificar si lo que se teclea no es un número
      //Demostrar que el algoritmo de Euclides funciona. Más eficiente para calcular el MCD
      //Dado un número calcular el factorial
      //Dado un número determinar si es primo
      //Leer una secuencia de números hasta teclear una línea en blanco, contar cuántos fueron positivos y cuántos negativos
      //Leer una secuencia de números hasta teclear una línea en blanco, ir escribiendo cuáles son primos
      //Leer una secuencia de cadenas hasta teclear una línea en blanco, escribir la última entre las que tengan la longitud mayor y cuántas hubo con esa misma longitud
      //Lea una secuencia de número hasta terminar en cero y calcule el promedio de los positivos
      //Lea tres numeros que determinen una fecha y escribe como resultado los tres numeros correspondientes a la fecha del día siguiente
      //Idem al anterior pero escriba los tres numeros de la fecha del dia anterior
      //Lea un trio de números que representa una fecha, lea un número que representa una cantidad de días, de como salida la fecha luego de haber pasado esa cantidad de días
      //Lea dos trios de números que determinen dos fechas y determine la diferencia de dias entre las dos
      #endregion

    }
  }
}
