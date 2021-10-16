using System;
using System.Collections.Generic;
using System.Text;

namespace WEBOO.Programacion
{
    class Program
    {

        public enum Celda {libre, obstaculo, paso, camino};
        public static int[,] dir = { 
                              {-1,  0},    // arriba (decrementa la i se mantiene la j)
                              { 0,  1},    // derecha (se mantiene la i incrementa la j)
                              { 1,  0},    // abajo (incrementa la i se mantiene la j)
                              { 0, -1}     // izquierda (se mantiene la i, decrementa la j)
                            };
        
        private static bool PosValida(Celda[,] b, int fila, int columna)
        {
            return fila >= 0 && fila < b.GetLength(0) && columna >= 0 && columna < b.GetLength(1);
        }

        public static void ImprimirLaberinto( Celda[,] lab )
        {
          Console.Write("   ");
          for (int j = 0; j < lab.GetLength(1); j++)
            Console.Write("{0,3}", j);
          Console.WriteLine();
          for (int i = 0; i < lab.GetLength(0); i++)
          {
            Console.Write("{0,2} ", i);  
            for (int j = 0; j < lab.GetLength(1); j++)
            {
                if (lab[i, j] == Celda.libre)
                {
                  Console.ForegroundColor = ConsoleColor.Gray;
                  Console.Write("{0,3}","-"); // destino
                  Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (lab[i, j] == Celda.camino)
                {
                  Console.ForegroundColor = ConsoleColor.Green;
                  Console.Write("{0,3}", "*"); // destino
                  Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (lab[i, j] == Celda.paso)
                {
                  Console.ForegroundColor = ConsoleColor.Red;
                  Console.Write("{0,3}", "-"); // destino
                  Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                  Console.ForegroundColor = ConsoleColor.Gray;
                  Console.Write("{0,3}", "X"); // pared
                }
            }
            Console.WriteLine();
          }
        }
        
        public static bool HayCamino(Celda[,] lab, int i_origen, int j_origen, 
                                                   int i_destino, int j_destino)
        {
          if (lab[i_origen, j_origen] == Celda.libre)
          {
            if (i_origen == i_destino && j_origen == j_destino)
            {
              lab[i_origen, j_origen] = Celda.camino;
              return true;
            }
            lab[i_origen, j_origen] = Celda.paso;
            for (int k = 0; k < dir.GetLength(0); k++)
            {
              int i = i_origen + dir[k, 0];
              int j = j_origen + dir[k, 1];
              if (PosValida(lab, i, j) && 
                  HayCamino(lab, i, j, i_destino, j_destino))
              {
                lab[i_origen, j_origen] = Celda.camino;
                return true;
              }
            }
            return false;
          }
          else
            return false;
        }

       
        static void Main(string[] args)
        {

          #region LABERINTO
          Celda[,] lab1 = { 
          /*0*/ {Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre},
          /*1*/ {Celda.libre, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre},
          /*2*/ {Celda.libre, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo},
          /*3*/ {Celda.libre, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre},
          /*4*/ {Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.libre},
          /*5*/ {Celda.libre, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre},
          /*6*/ {Celda.libre, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.libre},
          /*7*/ {Celda.libre, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre},
          /*8*/ {Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo},
          /*9*/ {Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo},
          /*10*/{Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre},
          /*11*/{Celda.libre, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo,  Celda.obstaculo},
          /*12*/{Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo},
          /*13*/{Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo},
          /*14*/{Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.obstaculo, Celda.obstaculo, Celda.obstaculo, Celda.libre,  Celda.libre},
          /*15*/{Celda.libre, Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.obstaculo, Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre,  Celda.libre},
          /*16*/{Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.obstaculo, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre, Celda.libre}};
          #endregion

          int fila_origen, columna_origen, fila_destino, columna_destino;

          #region PRUEBA LABERINTO

          ImprimirLaberinto(lab1);
          Console.Write("Entre fila origen ");
          fila_origen = int.Parse(Console.ReadLine());

          Console.Write("Entre columna origen ");
          columna_origen = int.Parse(Console.ReadLine());

          Console.Write("Entre fila destino ");
          fila_destino = int.Parse(Console.ReadLine());

          Console.Write("Entre columna destino ");
          columna_destino = int.Parse(Console.ReadLine());

          Console.WriteLine(HayCamino(lab1, fila_origen, columna_origen, fila_destino, columna_destino) ? "HAY CAMINO" : "NO HAY CAMINO");
          ImprimirLaberinto(lab1);
          Console.WriteLine();
          #endregion

          #region CP IMPLEMENTAR BUSCAR CAMINO MÁS CORTO. GUARDAR EL CAMINO EN UN ARRAY RESULTADO
          //TO DO
          #endregion

        }       
    }
}

