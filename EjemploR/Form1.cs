using System;
using System.Windows.Forms;
using RDotNet;

namespace EjemploR
{
    public partial class Form1 : Form
    {
        Clases.Conexion objetoconexion;
        public Form1()
        {
            InitializeComponent();
            objetoconexion = new Clases.Conexion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EjemploClaseR ejemplo = new EjemploClaseR();
            MessageBox.Show(ejemplo.resultado.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var valor_a = objetoconexion.buscar();
            var valor_b = "46";
            var valor_c = "59";
            var valor_d = "62";
            REngine engine = REngine.GetInstance();
            var x = engine.Evaluate("x <- c("+valor_a+ ", " + valor_b + ", " + valor_c + ", " + valor_d + ")").AsNumeric();
            var labels = engine.Evaluate("labels <- c('London', 'New York', 'Singapore', 'Mumbai')");
            engine.Evaluate("barplot(x, main='Car Distribution',names.arg=c('agosto','sept','oct','nov'))");
            //engine.Evaluate("barplot(x, main='Car Distribution', horiz=TRUE,names.arg = c('Agosto', 'Septiembre', 'Octubre', 'Noviembre')");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            REngine engine = REngine.GetInstance();
            engine.Evaluate("persp(x = 10*(1:nrow(volcano)), y=10*(1:ncol(volcano)), z=3*volcano, theta = 135, phi = 30, col = 'green3', scale = FALSE,  ltheta = -120, shade = 0.75, border = NA, box = FALSE, main = 'Volcán Maunga Whau, Auckland, NZ')");
           
        }
    }
}
