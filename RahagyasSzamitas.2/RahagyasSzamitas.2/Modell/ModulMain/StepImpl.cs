using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Input;

namespace rahagyasSzamitas.Modell.ModulMain
{
    class StepImpl : Step
    {
        public int size { get; set; }
        public int rough { get; set; }
        public int newSize { get; private set; }
        public string ITNum { get; set; }
        public short sizeType { get; set; }
        public StepImpl(int size, int rough, string ITNum, short sizeType)
        {
            this.size = size;
            this.rough = rough;
            this.ITNum = ITNum;
            this.sizeType = sizeType;
            this.newSize = sizCount(size, rough, ITNum, sizeType);
        }
        public int sizCount(int size, int rough, string ITNum, short sizeType)
        {  
            return newSize;
        }
    }  
    }
