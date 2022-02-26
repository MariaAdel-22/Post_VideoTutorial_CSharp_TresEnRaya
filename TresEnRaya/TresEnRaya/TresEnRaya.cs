using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TresEnRaya
{
    class TresEnRaya
    {
        //Definimos las posiciones de los botones (como el tablero del juego)
        private int[,] matriz = new int[3, 3];
        private int ganador = -1;
        
        //Guardamos aquí el último movimiento de nuestra Inteligencia Artificial
        private int[] ultimoMovimientoMaquina = new int[3];

        //Declaramos propiedades para acceder a ellos desde el Form1
        public int[,] Matriz { get => matriz; set => matriz = value; }
        public int Ganador { get => ganador; set => ganador = value; }
        public int[] UltimoMovimientoMaquina { get => ultimoMovimientoMaquina; set => ultimoMovimientoMaquina = value; }

        //Lo que hacemos es recorrer toda la matriz para asignarle el valor -1, ya cuando se vayan pulsando los botones conforme se juegue la partida irá cambiando
        //los valores de dicha matriz.
        public void InicializarPartida()
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1); j++)
                    matriz[i, j] = -1;
            Ganador = -1;
        }

        //En este método lo que hacemos es comprobar que nos pasemos los límites que tiene el tablero del juego.
        public void SeleccionarPosicion(int x, int y)
        {
            if (x >= 0 && x < 3 && y >= 0 && y < 3 && matriz[x, y] == -1 && Ganador == -1)
            {
                matriz[x, y] = 0;
                Ganador = GanaPartida();
                MueveMaquina();
            }
        }

        //Comprobamos si alguna de las combinaciones de la matriz es la ganadora
        public int GanaPartida()
        {
            int aux = -1;

            //Compruebo las combinaciones en diagonal
            if (matriz[0, 0] != -1 && matriz[0, 0] == matriz[1, 1] && matriz[0, 0] == matriz[2, 2])
                aux = matriz[0, 0];

            if (matriz[0, 2] != -1 && matriz[0, 2] == matriz[1, 1] && matriz[0, 2] == matriz[2, 0])
                aux = matriz[0, 2];

            //Compruebo las combinaciones en horizontal y vertical
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                if (matriz[i, 0] != -1 && matriz[i, 0] == matriz[i, 1] && matriz[i, 0] == matriz[i, 2])
                    aux = matriz[i, 0];

                if (matriz[0, i] != -1 && matriz[0, i] == matriz[1, i] && matriz[0, i] == matriz[2, i])
                    aux = matriz[0, i];
            }


            return aux;
        }

        //Recorremos la matriz para comprobar si algún elemento del tablero tiene el valor -1, si no es así significa que el tablero ya está lleno.
        public bool TableroLleno()
        {
            bool tableroCompleto = true;
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1); j++)
                    if (matriz[i, j] == -1)
                        tableroCompleto = false;


            return tableroCompleto;
        }

        //Comprobamos si se ha terminado el juego(ya sea porque el tablero está lleno o porque alguien ha ganado).
        public bool FinJuego()
        {
            bool fin = false;
            if (TableroLleno() || GanaPartida() != -1)
                fin = true;

            return fin;

        }

        //Es un algoritmo con el cual se tiene en cuenta los siguientes puntos:
        //cuál es el mejor movimiento que aplicará la máquina utilizando la máxima o mínima ventaja. Es la posición que más nos convenga
        public void MueveMaquina()
        {

            if (!FinJuego())
            {
                int f = 0;
                int c = 0;
                int v = Int32.MinValue;
                int aux;

                for (int i = 0; i < matriz.GetLength(0); i++)
                    for (int j = 0; j < matriz.GetLength(1); j++)
                        if (matriz[i, j] == -1)
                        {
                            matriz[i, j] = 1;
                            aux = Minimo();
                            if (aux > v)
                            {
                                v = aux;
                                f = i;
                                c = j;
                            }

                            matriz[i, j] = -1;
                        }
                matriz[f, c] = 1;
                ultimoMovimientoMaquina[0] = f;
                ultimoMovimientoMaquina[1] = c;
            }
        }


        private int Maximo()
        {
            if (FinJuego())
            {
                if (GanaPartida() != -1)
                    return -1;
                else
                    return 0;
            }

            int v = Int32.MinValue;
            int aux;
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1); j++)
                    if (matriz[i, j] == -1)
                    {
                        matriz[i, j] = 1;
                        aux = Minimo();
                        if (aux > v)
                            v = aux;

                        matriz[i, j] = -1;
                    }

            return v;
        }

        private int Minimo()
        {
            if (FinJuego())
            {
                if (GanaPartida() != -1)
                    return 1;
                else
                    return 0;
            }

            int v = Int32.MaxValue;
            int aux;
            for (int i = 0; i < matriz.GetLength(0); i++)
                for (int j = 0; j < matriz.GetLength(1); j++)
                    if (matriz[i, j] == -1)
                    {
                        matriz[i, j] = 0;
                        aux = Maximo();
                        if (aux < v)
                            v = aux;

                        matriz[i, j] = -1;
                    }

            return v;
        }
    }
}
