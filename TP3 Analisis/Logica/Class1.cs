using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Class1
    {
        public int Calcular(int[] vecx, int[] vecy, int c)
        {
            int acuy = 0;
            int acux = 0;
            int acusum = 0;
            double acuxcuadrado = 0;

            for (int i = 0; i < c; i++)
            {
                acux = acux + vecx[i];
                acuy = acuy + vecy[i];

                acusum = acusum + (vecx[i] * vecy[i]);

                acuxcuadrado = acuxcuadrado + (Math.Pow(vecx[i], 2));
            }
        }
    }
}