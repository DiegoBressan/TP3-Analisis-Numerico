using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logica;

namespace Formulario
{
    interface FormularioPrincipal
    {
        //MINIMOS CUADRADOS
        ResultadoRegresion MinimosCuadrados(DatosParametros Datos);
        //MINIMOS CUADRADOS POLINOMIO
        ResultadoRegresionPolinomio MinimosCuadradosPolinomio(DatosParametros Datos);
        //INTERPOLACION LAGRANJE
        ResultadoLagranje InterpolacionPolinomioLagranje(DatosParametros Datos, double ValorX);
    }
}
