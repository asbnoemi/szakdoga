using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace rahagyasSzamitas.Modell.ModulMain
{
    public class steps
    {
        static steps _me;
        public static steps Me { get { if (_me == null) _me = new steps(); return _me; } }
        private steps() { }
        public List<CalculationData> StepList { get; set; } = [];


        
        public void SaveAsJason( string fileName)
        {
            var saveDir = Path.Combine(AppContext.BaseDirectory, "save");
            Directory.CreateDirectory(saveDir);

            
            string jsonString = JsonSerializer.Serialize(this.StepList);
            
            File.WriteAllText(Path.Combine(saveDir, fileName),jsonString);
        }
      
        public List<string> FindFromJason()
        {
            var saveDir = Path.Combine(AppContext.BaseDirectory, "save");
            Directory.CreateDirectory(saveDir);
            if (!Directory.Exists(saveDir))
            {
                return new List<string>();
            }
            string[] filePaths = Directory.GetFiles(saveDir ,"*.json");  
            
          List<string>saveFileList  =  new  List<string>(filePaths);
            return saveFileList;
        }
        public void LoadFromJason(string filename)
        {
            
           this.StepList= JsonSerializer.Deserialize<List<CalculationData>>(File.ReadAllText( filename));
        }
        public void Print(CalculationData newstep) { }

    }
}
