using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rahagyasSzamitas.Modell
{
    public class DataArrange<T>: DataCsvBase
        where T : IData, new()
    {
        public List<T> Rows { get; private set; } = [];

        public override void Load(string filename)
        {
            base.Load(filename );
            foreach (List<string> row in Data)
            {
                if (row.Count == 0) continue;
                IData dataClass = new T();
                dataClass.Parse(row);
                Rows.Add((T)dataClass);
            }
        }

        public List<T> GetAll(string filename )
        {
            Load(filename);
            return Rows;
        }
    }
}
