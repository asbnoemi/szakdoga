using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rahagyasSzamitas.Modell.ModulMain
{
    public class steps
    {
        static steps _me;
        public static steps Me { get { if (_me == null) _me = new steps(); return _me; } }
        private steps() { }
        public List<CalculationData> StepList { get; set; } = [];


        
        public void SaveAsJason( string filename)
        {
            string jsonString = System.Text.Json.JsonSerializer.Serialize(this.StepList);
            System.IO.File.WriteAllText(filename, jsonString);
        }
       public void FindSaveFile() 
        {
            
        }
        public void LoadFromJason(string filename)
        {
            string jsonString = System.IO.File.ReadAllText(filename);
            this.StepList = System.Text.Json.JsonSerializer.Deserialize<List<CalculationData>>(jsonString);
        }
        public void Print(CalculationData newstep) { }

    }
}
