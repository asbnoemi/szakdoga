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
    public class TableData
    {
        public int sizeRangeMin { get; set; }
        public int sizeRangeMax { get; set; }
        public string Itnum { get; set; }
        public double size { get; set; }
        public TableData(int sizeRangeMax,int sizRangeMin , string Itnum, double size)
        {
            
            this.sizeRangeMax = sizeRangeMax;
            this.sizeRangeMin = sizRangeMin;
            this.Itnum = Itnum;
            this.size = size;
        }
        public List<TableData> TableDataLoad(string FileLocation)
        {
            List<TableData> TableDatas = new List<TableData>();
            foreach (var line in File.ReadLines(FileLocation, Encoding.UTF8)) 
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(';'); 
                if (parts.Length < 4) continue;

                if (!int.TryParse(parts[0].Trim(), out var sizeRangeMin)) continue;
                if (!int.TryParse(parts[1].Trim(), out var sizeRangeMax)) continue;
                var itnum = parts[2].Trim();
                var s = parts[3].Trim().Replace(',', '.');
                if (!double.TryParse(s, System.Globalization.NumberStyles.Float,
                                     System.Globalization.CultureInfo.InvariantCulture,
                                     out var size)) continue;

                TableDatas.Add(new TableData( sizeRangeMin, sizeRangeMax , itnum, size));
            }
            return TableDatas;
        }

    }
    
}