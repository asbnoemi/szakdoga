using rahagyasSzamitas.Modell.Tablels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using rahagyasSzamitas.Modell.Tablels;

namespace rahagyasSzamitas.Modell
{
    public class DataCsvBase
    {
        private string _filename;
        public List<string> Header { get; private set; } = [];
        public List<List<string>> Data { get; private set; } = [];
        public virtual void Load(string filename) 
        {
            bool first = true;

            foreach (string line in File.ReadLines(filename,Encoding.UTF8))
            {
                if (first)
                {
                    Header.AddRange(line.Split(';'));
                    first = false;
                }
                else
                {Data.Add(line.Split(';').ToList()); }
                
            }
        
        }
        
    }
}
