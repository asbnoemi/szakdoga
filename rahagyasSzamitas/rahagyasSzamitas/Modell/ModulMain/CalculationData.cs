using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace rahagyasSzamitas.Modell.ModulMain
{
    public class CalculationData
    {
        public double size { get; set; }
        public double surfaceRoughness { get; set; }
        public string ITnum { get; set; }
        public double i { get; set; }
        public double[] R { get; set; } 
        public double T { get; set; }
        public double O { get; set; }
    }
    
}
