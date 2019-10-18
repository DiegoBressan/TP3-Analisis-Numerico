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
    }
}
