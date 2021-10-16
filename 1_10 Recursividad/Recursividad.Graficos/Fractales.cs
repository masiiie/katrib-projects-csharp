using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recursividad.Graficos
{
    public partial class Fractales : Form
    {
        Bitmap canvas;
        
        public Fractales()
        {
            InitializeComponent();

            // Este Bitmap se utiliza para dibujar en el método recursivo
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(canvas);
            
            // Calcular los vértices del triángulo inicial
            Point p1 = new Point(pictureBox1.Width / 2, 0);
            Point p2 = new Point(0, pictureBox1.Height);
            Point p3 = new Point(pictureBox1.Width, pictureBox1.Height);
            
            //EJECUTAR SECUENCIAL BLOQUEA LA INTERFAZ GRÁFICA HASTA TERMINAR
            //DrawFractalTriangle(p1, p2, p3, g, Color.Red);

            //EJECUTAR LA RECURSION EN UNA HEBRA EN PARALELO SIN BLOQUEAR LA INTERFAZ GRAFICA, SI AQUELLA DUERME LA INTERFAZ GRAFICA SEGUIRA PINTANDO
            Task.Factory.StartNew(( ) => DrawFractalTriangle(p1, p2, p3, g, Color.Red));

        }

        private void DrawFractalTriangle(Point p1, Point p2, Point p3, Graphics g, Color c)
        {
            //Nivel de resolución hasta donde queremos dibujar los triángulos
            if (Distance(p1, p2) < 5 || 
                Distance(p2, p3) < 5 || 
                Distance(p1, p3) < 5) return;
            
            Brush b = new SolidBrush(c);
            g.FillPolygon(b, new Point[] { p1, p2, p3 });
            b.Dispose();

            pictureBox1.Invalidate(); // Invalidar para que se redibuje el PictureBox (se lanza el evento Paint)
            System.Threading.Thread.Sleep(1000); // Esperar 1 segundo

            // Calcular los vértices del nuevo triángulo
            Point np1 = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
            Point np2 = new Point((p2.X + p3.X) / 2, (p2.Y + p3.Y) / 2);
            Point np3 = new Point((p3.X + p1.X) / 2, (p3.Y + p1.Y) / 2);
            
            // Dibujar el fractal dentro del nuevo triángulo con el color opuesto
            DrawFractalTriangle(np1, np2, np3, g, (c==Color.Red)? Color.Blue: Color.Red);
        }

        private void DrawFractalSierpinski(Point p1, Point p2, Point p3, Graphics g, int rgb)
        {
            // TODO: Implementar Triángulo de Sierpinski
        }

        // Distancia Euclideana
        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Dibujar en el PictureBox lo que hay en el Bitmap canvas
            e.Graphics.DrawImage(canvas, 0, 0);
        }
    }
}
