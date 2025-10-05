using rahagyasSzamitas.Modell.ModulMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using rahagyasSzamitas.Modell.Tablels;


namespace rahagyasSzamitas.Modell.Tablels
{   
    public class DataTableITSize: IData
    {
        
        public int sizeRangeMin { get; set; }
        public int sizeRangeMax { get; set; }
        public string Itnum { get; set; }
        public double size { get; set; }
        
        public void Parse(List <string> line)
        {
            List<DataTableITSize> TableDatas = new List<DataTableITSize>();

            if (line.Count != 4) throw new ArgumentException("hibás beérkezö adat");
            if (!int.TryParse(line[0].Trim(), out var sizeRangeMin));
                if (!int.TryParse(line[1].Trim(), out var sizeRangeMax));
                var itnum = line[2].Trim();
                var s = line[3].Trim().Replace(',', '.');
            if (!double.TryParse(s, System.Globalization.NumberStyles.Float,
                                 System.Globalization.CultureInfo.InvariantCulture,
                                 out var size))

                this.sizeRangeMin = sizeRangeMin;
                this.sizeRangeMax = sizeRangeMax;
                this.Itnum = itnum; 
                this.size = size;
                    
            
            
        }

    }
    
}