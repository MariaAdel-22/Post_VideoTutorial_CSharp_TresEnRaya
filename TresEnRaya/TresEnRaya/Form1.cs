using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TresEnRaya
{
    public partial class Form1 : Form
    {

        TresEnRaya tresEnRaya = new TresEnRaya();
        private int[,] matriz = new int[2, 2];
        private int ganador = -1;

        public Form1()
        {
            //Inicializamos la partida

            InitializeComponent();
            tresEnRaya.InicializarPartida();
            matriz = tresEnRaya.Matriz;

        }

        private void ComprobarGanador()
        {
            //En este array obtenemos los últimos movimientos de la máquina.

            int[] ultMov = tresEnRaya.UltimoMovimientoMaquina;

            //En cada if lo que hago es comprobar si el último movimiento de la máquina concide con el último momento realizado (cuando pulsas), y si es así 
            //aparecerá el botón con el color rosa y el texto 0 para indicar que ha hecho un movimiento la máquina.

            if (ultMov[0] == 0 && ultMov[1] == 0) {

                button1.Text = "0";
                button1.BackColor = Color.LightPink;
            }

            if (ultMov[0] == 0 && ultMov[1] == 1) {

                button2.Text = "0";
                button2.BackColor = Color.LightPink;
            }

            if (ultMov[0] == 0 && ultMov[1] == 2) {

                button3.Text = "0";
                button3.BackColor = Color.LightPink;
            }

            if (ultMov[0] == 1 && ultMov[1] == 0) {

                button6.Text = "0";
                button6.BackColor = Color.LightPink;
            }

            if (ultMov[0] == 1 && ultMov[1] == 1) { 

                button5.Text = "0";
                button5.BackColor = Color.LightPink;
            }

            if (ultMov[0] == 1 && ultMov[1] == 2) { 

                button4.Text = "0";
                button4.BackColor = Color.LightPink;
            }

            if (ultMov[0] == 2 && ultMov[1] == 0) { 

                button9.Text = "0";
                button9.BackColor = Color.LightPink;
            }

            if (ultMov[0] == 2 && ultMov[1] == 1) {
                
                button8.Text = "0";
                button8.BackColor = Color.LightPink;
            }

            if (ultMov[0] == 2 && ultMov[1] == 2) { 

                button7.Text = "0";
                button7.BackColor = Color.LightPink;
            }
               

            if (ganador == 0) MessageBox.Show("Ganaste!");
             

            if (ganador == 1) MessageBox.Show("Perdiste...");
        

            if(ganador==-1 && tresEnRaya.TableroLleno())
                MessageBox.Show("Empate!"); 


        }


        private void EventoBotones( int x, int y,Button boton)
        {
            if (matriz[x, y] == -1)
            {
                tresEnRaya.SeleccionarPosicion(x,y);
                ganador = tresEnRaya.GanaPartida();
                ComprobarGanador();
                boton.Text = "X";
                boton.BackColor = Color.LightCyan;

            }
        }

        //En cada evento click de cada botón llamamos a un método al cual le pasamos la posición (esa posición es la que ocupa en una matriz) y el nombre del botón
        //que ha sido pulsado.

        private void button1_Click(object sender, EventArgs e)
        {
            EventoBotones(0, 0, button1);
       }

        private void button2_Click(object sender, EventArgs e)
        {
            EventoBotones(0, 1, button2);
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EventoBotones(0, 2, button3);
   
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EventoBotones(1, 0, button6);
     
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EventoBotones(1, 1, button5);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EventoBotones(1,2, button4);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            EventoBotones(2, 0, button9);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            EventoBotones(2, 1, button8);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EventoBotones(2, 2, button7);
        }

        //Este botón es el que tiene como texto "Nueva Partida" y de lo que encarga es de volver a iniciar la partida dándole un nombre vacío a todos los demás botones
        //es como que se resetea. Además también lo que hacemos es asignarle a la propiedad Matriz, la posición de los botones (que es una matriz en sí)

        private void button10_Click(object sender, EventArgs e)
        {
            tresEnRaya = new TresEnRaya();
            tresEnRaya.InicializarPartida();
            matriz = tresEnRaya.Matriz;
            ganador = -1;

            label1.Text = button1.Text = button2.Text = button3.Text = button4.Text = button5.Text = button6.Text = button7.Text = button8.Text = button9.Text = String.Empty;

            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Gray;

            button3.BackColor = Color.Gray;
            button4.BackColor = Color.Gray;

            button5.BackColor = Color.Gray;
            button6.BackColor = Color.Gray;

            button7.BackColor = Color.Gray;
            button8.BackColor = Color.Gray;
            button9.BackColor = Color.Gray;
        }
    }

}
