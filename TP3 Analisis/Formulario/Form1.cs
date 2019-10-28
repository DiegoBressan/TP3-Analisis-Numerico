using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Formulario
{
    public partial class Form1 : Form, FormularioPrincipal
    {
        public Principal Principal { get; set; }

        public Form1()
        {
            Principal = new Principal();
            InitializeComponent();
        }
        //MINIMOS CUADRADOS

        private void button1_Click(object sender, EventArgs e)
        {
            MinimosCuadrados nuevo = new MinimosCuadrados(new DatosParametros());
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }

        public ResultadoRegresion MinimosCuadrados(DatosParametros Datos)
        {
            return Principal.MinimosCuadrados(Datos);
        }
        //MINIMOS CUADRADOS POLINOMIO
        private void button3_Click(object sender, EventArgs e)
        {
            MinimosCuadradosPolinomio nuevo = new MinimosCuadradosPolinomio(new DatosParametros());
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }
        public ResultadoRegresionPolinomio MinimosCuadradosPolinomio(DatosParametros Datos)
        {
            return Principal.MinimosCuadradosPolinomio(Datos);
        }

        //LAGRANJE
        private void button2_Click(object sender, EventArgs e)
        {
            InterpolacionLagranje nuevo = new InterpolacionLagranje(new DatosParametros());
            nuevo.Owner = this;
            nuevo.ShowDialog();
        }
        public ResultadoLagranje InterpolacionPolinomioLagranje(DatosParametros Datos, double ValorX)
        {
            return Principal.InterpolacionPolinomioLagranje(Datos, ValorX);
        }
    }
}
