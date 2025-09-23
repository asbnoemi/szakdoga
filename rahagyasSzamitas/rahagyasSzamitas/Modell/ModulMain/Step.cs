using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rahagyasSzamitas.Modell.ModulMain
{
    public interface Step
    {
        public int size { get; set; }
        public int rough { get; set; }
        public int newSize { get;}
        public string ITNum { get;set; }
        public short sizeType { get; set; }
        public int sizCount(int size, int rough, string ITNum, short sizeType);
    }
   
    }
