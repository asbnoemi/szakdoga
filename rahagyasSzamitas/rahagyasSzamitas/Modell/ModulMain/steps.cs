using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace rahagyasSzamitas.Modell.ModulMain
{
    public class Steps
    {
        static Steps _me;
        public static Steps Me { get { if (_me == null) _me = new Steps(); return _me; } }
        public List<CalculationData> StepList { get; set; } = [];
        private Steps() { }
        public void SaveAsJason( string fileName)
        {
            var saveDir = Path.Combine(AppContext.BaseDirectory, "save");
            Directory.CreateDirectory(saveDir);

            
            string jsonString = JsonSerializer.Serialize(this.StepList);
            
            File.WriteAllText(Path.Combine(saveDir, fileName),jsonString);
        }
        public void SaveLatex(string filename)
        {
            string[] content = CreateLatexstep(Steps.Me.StepList[0], 0);
            File.AppendAllText(filename, content[0]);
            for (int i = 0; i < Steps.Me.StepList.Count; i++)
            {
               content = CreateLatexstep(Steps.Me.StepList[i], i);
                File.AppendAllText(filename, content[1]);

            }
           content = CreateLatexstep(Steps.Me.StepList[Steps.Me.StepList.Count-1], Steps.Me.StepList.Count);
            File.AppendAllText(filename, content[2]);
        }
       public string[] CreateLatexstep(CalculationData Disdata,int SerialNum ) 
        {

            string contentBigSize = $$""""                
                \textbf{Legnagyobb méret:} $\varnothing {{Disdata.Size}}$
                \[i = 0{,}45 \cdot \sqrt[3]{D} + 0{,}001 \cdot D = 0{,}45 \cdot \sqrt[3]{{{Disdata.Size}}} + 0{,}001 \cdot {{Disdata.Size}}\]  
                \[i = {{Disdata.I * 1000}}\,\mu m = {{Disdata.I}}\,mm\]
                """";
                string contentNext = $$""""               
                
               \textbf{következö méret:} 
                \[{{Disdata.ITnum}}\]
                \[Q_{{SerialNum}}={{Disdata.R[2]}}\]
                \[T_{{SerialNum}} = q_{{SerialNum}} \cdot i = {{Disdata.R[2]}} \cdot {{Disdata.I}}\,mm = {{Disdata.R[1]}}\,mm\]  
                \[[M + R_{{SerialNum}}] - T_{{SerialNum}} = \left[{{Disdata.Size}}\,mm + 2 \cdot 4 \cdot {{Disdata.R[2]}} \cdot {{Disdata.I}}\,mm\right] = {{Disdata.R[0]}} _{ - {{Disdata.M}}}\]
               """";
            string contentEnd = $$""""
            
            \\textbf{Kiindulási méret:} 
            \[{{Disdata.ITnum}}\]
            \[Q_{{SerialNum}}={{Disdata.R[2]}}\]
            \[T_{{SerialNum}} = q_{{SerialNum}} \cdot i = {{Disdata.R[2]}} \cdot {{Disdata.I}}\,mm = {{Disdata.R[1]}}\,mm\]  
            \[[M + R_{{SerialNum}}] _{\pm T_{{SerialNum}}} = \left[{{Disdata.Size}}\,mm + 2 \cdot 4 \cdot {{Disdata.R[2]}} \cdot {{Disdata.I}}\,mm\right] = {{Disdata.R[0]}} \pm {{Disdata.O}}\]            
            """";
            string[] content = new string[3] { contentBigSize, contentNext, contentEnd };
            return content; 
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
        

    }
}
