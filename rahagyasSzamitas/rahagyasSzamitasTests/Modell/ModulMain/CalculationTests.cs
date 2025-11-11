using Microsoft.VisualStudio.TestTools.UnitTesting;
using rahagyasSzamitas.Modell.ModulMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rahagyasSzamitas.Modell.ModulMain.Tests
{
    [TestClass()]
    public class CalculationTests
    {
        [TestMethod()]
        public void CalculationTest()
        {
            Calculation calc = new Calculation( size: 60, surfaceRoughness: 1.821, ITnum: "IT9", diameter: 40);
            Assert.IsNotNull(calc);     
        }
        [TestMethod()]
        public void ThisCalculationsTest()
        {
            Calculation calc = new Calculation(size: 60, surfaceRoughness: 0, ITnum: "IT9", diameter: 40);
            CalculationData data = calc.ThisCalculations();
            Assert.AreEqual(60, data.Size);
            Assert.AreEqual(0, data.SurfaceRoughness);
            Assert.AreEqual("IT9", data.ITnum);
            Assert.AreEqual(0.00182, Math.Round(data.I, 3));
            Assert.AreEqual(0.982, Math.Round(data.R[0], 3));
            Assert.AreEqual(0.245, Math.Round(data.R[1], 3));
            Assert.AreEqual(0.163, Math.Round(data.R[2], 3));
            Assert.AreEqual(0.245, Math.Round(data.M, 3));
                
        }
    }
}