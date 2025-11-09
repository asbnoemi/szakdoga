using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace rahagyasSzamitas.Modell.ModulMain
{
    public class CalculationData:Object
    {
        public double Size { get; set; }
        public bool Sizeordirection { get; set; }
        public double SurfaceRoughness { get; set; }
        public string ITnum { get; set; }
        public double I { get; set; }
        public double[] R { get; set; } 
        public double M { get; set; }
        public double O { get; set; }
    }
    
}
