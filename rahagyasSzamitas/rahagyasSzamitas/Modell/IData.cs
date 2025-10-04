using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rahagyasSzamitas.Modell
{
   public interface IData
    {
        public void Parse(List<string> row);
    }
}
