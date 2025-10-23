using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rahagyasSzamitas.Modell.ModulMain
{
    public class steps
    {
        static steps _me;
        public static steps Me { get { if (_me == null) _me = new steps(); return _me; } }
        private steps() { }
        public List<CalculationData> StepList { get; set; } = [];
        public void Load() { }
        public void Save(CalculationData newstep) { }
        public void Print(CalculationData newstep) { }

    }
}
