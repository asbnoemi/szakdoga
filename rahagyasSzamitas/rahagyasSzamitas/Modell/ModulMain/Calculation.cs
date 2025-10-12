using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rahagyasSzamitas.Modell.Tablels;

namespace rahagyasSzamitas.Modell.ModulMain
{
    internal class Calculation
    {
        public double size { get; set; }
        public double surfaceRoughness { get; set; }
        public string ITnum { get; set; }
        public double diameter { get; set; }
        public Calculation( double size=0, double surfaceRoughness=0, string ITnum="",double diameter = 0)
        {
            if (size < 0) throw new ArgumentException("méret nem lehet negatív");
            if (surfaceRoughness < 0) throw new ArgumentException("felületi érdesség nem lehet negatív");
            if (diameter < 0) throw new ArgumentException("átmérő nem lehet negatív");
            if (size == 0 && diameter == 0) throw new ArgumentException("méret vagy átmérő megadása kötelező");
            this.size = size;
            this.surfaceRoughness = surfaceRoughness;
            this.ITnum = ITnum;
            this.diameter = diameter;

        }
       
        public CalculationData ThisCalculations() 
        {
            double i=Calculationi();
            double[] R = CalculationR(i);
           double T = CalculationT(R);
              double O = CalculationOriginTolerance(T);

            return new CalculationData()
            {
                size = this.size,
                surfaceRoughness = this.surfaceRoughness,
                ITnum = this.ITnum,
                i = i,
                R = R,
                T = T,
                O = O,
            };
        }
        private double Calculationi()
        {
            double i = 0;
            i = 0.45 * Math.Cbrt(this.size > 0?this.size:this.diameter) * 0.001 * this.size;
            i = i * 0.001;// mikrométer bol mm-be
            return i;
        }
        private double[] CalculationR(double i)
        {
            DataArrange<DataTableITMultiplier> tableIT = new DataArrange<DataTableITMultiplier>();
            double q=tableIT.GetAll("ITNum.csv").Find(x=>(x.Itnum==this.ITnum)).Multiplier;
            double[] R = new double[2];
            R[0] = 2 * 4 * q * i;
            R[1] = q * i;
            return R;
        }
        private double CalculationT( double[] R)
        {
            double T = 0;
            T = this.size > 0?this.size:this.diameter + R[0];
            return T;
        }
        private double CalculationOriginTolerance(double T)
        {
            double O = 0;// eredeti ráhagyás esetén kell 
            O = T / 2;
            return O;
        }
    }
}
