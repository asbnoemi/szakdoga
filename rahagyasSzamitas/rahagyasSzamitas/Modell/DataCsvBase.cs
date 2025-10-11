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

        public string this[int i]
        {
            get => Header[i];
        }
        public List<List<string>> Data { get; private set; } = [];

        public virtual void Load(string filename) 
        {
            

            foreach (string line in File.ReadLines(filename,Encoding.UTF8))
            {
                
                Data.Add(line.Split(';').ToList());
            }
        
        }
        public virtual void Save() 
        { }
    }
}
