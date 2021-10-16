using System;

namespace WEBOO.Programacion {

  class Program
  {

    #region REINA NEGRA DA JAQUE AL REY
    static bool ReinaNegraDaJaque(string[,] tablero){
      int m = tablero.GetLength(0);
      int n = tablero.GetLength(1);
      //Buscar posicion de reina negra
      int filaRN = -1; int columnaRN = -1;
      for (int i=0; i<m; i++){
        for (int j=0; j<n; j++)
          if (tablero[i, j] != null && tablero[i, j] == "Q_N") {
            filaRN = i; columnaRN = j; break;
          }
        if (filaRN != -1) break;
      }
      if (filaRN == -1) throw new Exception("Reina negra no está en el tablero");
      
      //Buscar si amenaza a rey blanco en la horizontal hacia la izquierda
      for (int j = columnaRN-1; j>=0; j--)
        if (tablero[filaRN, j] != null) {
          if (tablero[filaRN, j] == "R_B") return true;
          else break; //Hay otra pieza por tanto la dama blanca no da jaque en esa dirección
        }
        //Sigue en el ciclo si no había ninguna pieza por el camino

      //Buscar si amenaza a rey blanco en la horizontal hacia la derecha
      for (int j = columnaRN+1; j<n; j++)
        if (tablero[filaRN, j] != null) {
          if (tablero[filaRN, j] == "R_B") return true;
          else break; //Hay otra pieza por tanto la reina no da jaque en esa dirección
        }

      //Buscar si amenaza a rey blanco en la vertical hacia arriba
      for (int i = filaRN - 1; i>=0; i--)
        if (tablero[i, columnaRN] != null) {
          if (tablero[i, columnaRN] == "R_B") return true;
          else break; //Hay otra pieza por tanto no da jaque en esa dirección
        }

      //Buscar si amenaza a rey blanco en la vertical hacia abajo
      for (int i = filaRN + 1; i < m; i++)
        if (tablero[i, columnaRN] != null) {
          if (tablero[i, columnaRN] == "R_B") return true;
          else break; //Hay otra pieza por tanto no da jaque en esa dirección
        }

      //Buscar si amenaza a rey blanco en la diagonal noroeste
      for (int i = filaRN - 1, j = columnaRN - 1; i >= 0 && j >= 0; i--, j--)
        if (tablero[i,j] != null) {
          if (tablero[i,j] == "R_B") return true;
          else break; //Hay otra pieza por tanto no da jaque en esa dirección
        }

      //Buscar si amenaza a rey blanco en la diagonal sureste
      for (int i = filaRN + 1, j = columnaRN + 1; i < m && j < n; i++, j++)
        if (tablero[i, j] != null) {
          if (tablero[i, j] == "R_B") return true;
          else break; //Hay otra pieza por tanto no da jaque en esa dirección
        }

      //CP Buscar las amenazas en la diagonal noreste y en la diagonal suroeste
      return false;
    }
    #endregion 

    #region REINA NEGRA DA JAQUE AL REY ARRAY DE DIRECCIONES
    private static bool PosicionValida( int totalFilas, int totalColumnas, int i, int j )
    {
      return i >= 0 && i < totalFilas && j >= 0 && j < totalColumnas;
    }

    static bool ReinaNegraDaJaqueMejorada( string[,] tablero )
    {
      int m = tablero.GetLength(0);
      int n = tablero.GetLength(1);
      //Buscar posicion de reina negra
      int filaReinaN = -1; int columnaReinaN = -1;
      for (int i = 0; i < m; i++)
      {
        for (int j = 0; j < n; j++)
          if (tablero[i, j] != null && tablero[i, j] == "Q_N")
          {
            filaReinaN = i; columnaReinaN = j; break;
          }
        if (filaReinaN != -1) break;
      }
      if (filaReinaN == -1) throw new Exception("Reina negra no está en el tablero");

      //Arrays para moverse en las direcciones Norte, Sur, Este, Oeste, Este, Noreste, Noroeste, Sureste, Suroeste
      int[] dirFilas    = {-1, 1, 0, 0,-1,-1, 1, 1};
      int[] dirColumnas = { 0, 0, 1,-1, 1,-1, 1,-1};

      for (int k = 0; k < dirFilas.Length; k++)
      {
        int i = filaReinaN + dirFilas[k]; 
        int j = columnaReinaN + dirColumnas[k];
        while (PosicionValida(m, n, i, j))
        {
          if (tablero[i,j] == "R_B") return true;
          else if (tablero[i,j] != null) break;
          i += dirFilas[k]; j += dirColumnas[k];
        }
      }
      return false;
    }
    #endregion 

    #region LISTAR TABLERO
    static void ListaTablero(string[,] tablero) {
      int filas = tablero.GetLength(0);
      int columnas = tablero.GetLength(1);
      for (int i = 0; i < filas; i++) {
        for (int j = 0; j < columnas; j++)
          Console.Write((tablero[i, j] == null) ? "---" + "  ": tablero[i, j] + "  ");
        Console.WriteLine("\n");
      } 
    } 
    #endregion

    static void Main(string[] args)
    {
      #region PRUEBA DE DIMENSIONES
      //int[,] matriz = { { 20, 10, 15 }, { 5, 20, 30 }, { 60, 7, 25 }, { 1, 40, 35 } };
      //ListaMatriz(matriz);
      //Console.WriteLine("Cantidad de dimensiones del array {0}", matriz.Rank);
      //for (int k = 0; k < matriz.Rank; k++)
      //  Console.WriteLine("La cantidad de elementos en la dimensión {0} es de {1}", k, matriz.GetLength(k));
      #endregion 

      string[,] ajedrez = new string[8, 8];
      ajedrez[3, 3] = "T_N";
      ajedrez[3, 5] = "A_B";
      ajedrez[5, 4] = "P_N";
      ajedrez[7, 5] = "A_B";
      ajedrez[4, 2] = "P_B";
      
      //REY
      ajedrez[5, 3] = "R_B";

      //REINA
      //Ejecutar cambiando posiciones de la Reina Negra
      ajedrez[2, 0] = "Q_N";  //No Jaque
      //ajedrez[7, 3] = "Q_N";  //Jaque
      //ajedrez[5, 7] = "Q_N";  //No Jaque
      //ajedrez[7, 3] = "Q_N";  //Jaque

      ListaTablero(ajedrez);
      Console.ReadLine();
      Console.WriteLine("El rey blanco {0} en jaque por la reina negra", 
                         ReinaNegraDaJaque(ajedrez) ? "ESTÁ" : "NO ESTÁ");
      Console.WriteLine("Usando array de direcciones, el rey blanco {0} en jaque por la reina negra", 
                         ReinaNegraDaJaqueMejorada(ajedrez) ? "ESTÁ" : "NO ESTÁ");
    }
  }
}

    #region EJERCICIOS CLASE PRACTICA
    
        //CP Implemente el método anterior con otro algoritmo
        //buscando la dama blanca y averiguando si amenaza al rey
    
        //CP Buscar si el rey negro esta amenazado por un caballo blanco

        //CP Ver si el rey negro está en jaque

        //CP Ver algún peón blanco puede comerse a una pieza negra

        //CP Sumar dos matrices y devolver la suma de las dos

        //CP Implementar el juego del TIC TAC TOE

        //CP Dada una matriz devolver la matriz transpuesta
    
        //CP Dada una matriz determinar si es simétrica

        //CP Una matriz de int si para un valor int consideramos area la mayor cantidad de casillas contiguas de se valor
        //Determine cuál es el área mayor contenida en esa matriz (no importa cuál es el valor)

    #endregion

