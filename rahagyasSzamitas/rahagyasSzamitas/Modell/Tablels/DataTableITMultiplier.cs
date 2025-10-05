using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rahagyasSzamitas.Modell.Tablels
{
    public class DataTableITMultiplier: IData
    {
        public string Itnum { get; set; }   
        public double Multiplier { get; set; }
        public void Parse(List<string> line)
        {
            if (line.Count != 2) throw new ArgumentException("hibás beérkezö adat");
            var itnum = line[0].Trim();
            var m = line[1].Trim().Replace(',', '.');
            if (!double.TryParse(m, System.Globalization.NumberStyles.Float,
                                 System.Globalization.CultureInfo.InvariantCulture,
                                 out var multiplier))
                throw new ArgumentException("hibás beérkezö adat");
            this.Itnum = itnum;
            this.Multiplier = multiplier;
        }

    }
}
