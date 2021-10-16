using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recursividad.Graficos
{
    public partial class Mondrian : Form
    {
        static readonly Random rnd = new Random();
        Bitmap canvas;
        int count = 1; // Contar la cantidad de rectángulos

        public Mondrian()
        {
            InitializeComponent();

            // Este Bitmap se utiliza para dibujar en el método recursivo
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(canvas);

            Pen bluePen = new Pen(Brushes.Blue, 10);
            
            g.DrawRectangle(bluePen, pictureBox1.DisplayRectangle);
            DrawRectangleNumber(count, pictureBox1.DisplayRectangle, g);
            pictureBox1.Invalidate();

            bluePen.Width = 5;

            // Invocar el método recursivo en una hebra independiente
            Task.Factory.StartNew(() => DivideRectangle(pictureBox1.DisplayRectangle, g, bluePen))
                .ContinueWith(task => MessageBox.Show("Listo!"));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Dibujar en el PictureBox lo que hay en el Bitmap
            e.Graphics.DrawImage(canvas, 0, 0);
        }

        void DivideRectangle(Rectangle rect, Graphics g, Pen pen)
        {
            if (rect.Width <= 200 || rect.Height <= 200) return; // caso base

            System.Threading.Thread.Sleep(2000); // Esperar 2 segundos
            
            if (rect.Width > rect.Height) // dividir verticalmente
            {
                int splitPoint = rnd.Next(100, rect.Width - 100);
                g.DrawLine(pen, rect.X + splitPoint, rect.Y, rect.X + splitPoint, rect.Y + rect.Height);

                // Rectángulo izquierdo
                Rectangle rectIzq = new Rectangle(rect.X, rect.Y, splitPoint, rect.Height);
                count++;
                DrawRectangleNumber(count, rectIzq, g);
                
                // Rectángulo derecho
                Rectangle rectDer = new Rectangle(rect.X + splitPoint, rect.Y, rect.Width - splitPoint, rect.Height);
                count++;
                DrawRectangleNumber(count, rectDer, g);
                
                DivideRectangle(rectIzq, g, pen); // Dividir rectángulo izquierdo                            
                DivideRectangle(rectDer, g, pen); // Dividir rectángulo derecho 
            }
            else // dividir horizontalmente
            {
                int splitPoint = rnd.Next(100, rect.Height - 100);
                g.DrawLine(pen, rect.X, rect.Y + splitPoint, rect.X + rect.Width, rect.Y + splitPoint);
                
                // Rectángulo superior
                Rectangle rectSup = new Rectangle(rect.X, rect.Y, rect.Width, splitPoint);
                count++;
                DrawRectangleNumber(count, rectSup, g);

                // Rectángulo inferior
                Rectangle rectInf = new Rectangle(rect.X, rect.Y + splitPoint, rect.Width, rect.Height - splitPoint);
                count++;
                DrawRectangleNumber(count, rectInf, g);

                DivideRectangle(rectSup, g, pen); // Dividir rectángulo superior   
                DivideRectangle(rectInf, g, pen); // Dividir rectángulo inferior   
            }
        }

        void DrawRectangleNumber(int count, Rectangle rect, Graphics g)
        {
            g.FillRectangle(Brushes.White, rect.X + 5, rect.Y + 5, 50, 50);
            g.DrawString(count.ToString(), new Font("Arial", 20), Brushes.Red, rect.X + 10, rect.Y + 10);
            pictureBox1.Invalidate();
        }
    }
}
