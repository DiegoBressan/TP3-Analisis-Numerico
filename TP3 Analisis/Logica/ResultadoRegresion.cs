using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class ResultadoRegresion
    {
        public double Pendiente { get; set; }
        public double OrdenadaOrigen { get; set; }
        public List<double> Resul { get; set; }
        public double Efectividad { get; set; }
        public int GradoFinal { get; set; }
    }
}