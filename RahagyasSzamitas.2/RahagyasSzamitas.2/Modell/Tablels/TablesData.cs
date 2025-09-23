using rahagyasSzamitas.Modell.ModulMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace rahagyasSzamitas.Modell.Tablels
{   
    public class TableData
    {
        public int sizeRange { get; set; }
        public string Itnum { get; set; }
        public double size { get; set; }
        public TableData(int sizeRange, string Itnum, double size)
        {
            this.sizeRange = sizeRange;
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
                if (parts.Length < 3) continue;

                if (!int.TryParse(parts[0].Trim(), out var sizeRange)) continue;
                var itnum = parts[1].Trim();

                var s = parts[2].Trim().Replace(',', '.');
                if (!double.TryParse(s, System.Globalization.NumberStyles.Float,
                                     System.Globalization.CultureInfo.InvariantCulture,
                                     out var size)) continue;

                TableDatas.Add(new TableData(sizeRange, itnum, size));
            }
            return TableDatas;
        }

    }
    
}