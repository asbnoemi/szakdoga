using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rahagyasSzamitas.Modell.ModulMain
{
    internal class Calculation
    {
        public double size { get; set; }
        public double surfaceRoughness { get; set; }
        public string ITnum { get; set; }
        public Calculation( double size, double surfaceRoughness, string ITnum)
        {
            this.size = size;
            this.surfaceRoughness = surfaceRoughness;
            this.ITnum = ITnum;
        }
        public CalculationData ThisCalculations() 
        {
            return new CalculationData()
            {
                size = this.size,
                surfaceRoughness = this.surfaceRoughness,
                ITnum = this.ITnum,
                i = Calculationi(this),
                R = CalculationR((int)Calculationi(this), this),
                T = CalculationT(this, CalculationR((int)Calculationi(this), this)),
                O = CalculationOriginTolerance(this, CalculationT(this, CalculationR((int)Calculationi(this), this)))
            };
        }
        private double Calculationi(Calculation actual)
        {
            double i = 0;
            i = 0.45 * Math.Cbrt(actual.size) * 0.001 * actual.size;
            i = i * 0.001;// mikrométer bol mm-be
            return i;
        }
        private double[] CalculationR(int i, Calculation actual)
        {
            int q = 0;// IT szám alapján keresni kell kis táblázatban
            double[] R = new double[2];
            R[0] = 2 * 4 * q * i;
            R[1] = q * i;
            return R;
        }
        private double CalculationT(Calculation actual, double[] R)
        {
            double T = 0;
            T = actual.size + R[0];
            return T;
        }
        private double CalculationOriginTolerance(Calculation actual, double T)
        {
            double O = 0;// eredeti ráhagyás esetén kell 
            O = T / 2;
            return O;
        }
    }
}
