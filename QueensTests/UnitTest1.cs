using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;

namespace QueensTests
{
    [TestClass]
    public class UnitTest1
    {
        private string OutputExpected;
        private string OutputActual;
        private FileStream fs;
        private StreamReader sr;

        [TestMethod]
        public void NotHittingQueensTesting()
        {
            Process.Start("Queens.exe", "Queens.exe NotHittingQueensInputTest NotHittingQueensActualTest");
            fs = new FileStream("NotHittingQueensExpectedTest.txt", FileMode.Open);
            sr = new StreamReader(fs);
            OutputExpected = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            fs = new FileStream("NotHittingQueensActualTest.txt", FileMode.Open);
            sr = new StreamReader(fs);
            OutputActual = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            Assert.AreSame(OutputExpected, OutputActual);
        }

        [TestMethod]
        public void NotHittingQueensAllTesting()
        {
            Process.Start("Queens.exe", "Queens.exe NotHittingQueensAllInputTest NotHittingQueensAllActualTest");
            fs = new FileStream("NotHittingQueensAllExpectedTest.txt", FileMode.Open);
            sr = new StreamReader(fs);
            OutputExpected = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            fs = new FileStream("NotHittingQueensAllActualTest.txt", FileMode.Open);
            sr = new StreamReader(fs);
            OutputActual = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            Assert.AreSame(OutputExpected, OutputActual);
        }

        [TestMethod]
        public void BeatAllCellsTesting()
        {
            Process.Start("Queens.exe", "Queens.exe BeatAllCellsInputTest BeatAllCellsActualTest");
            fs = new FileStream("BeatAllCellsExpectedTest.txt", FileMode.Open);
            sr = new StreamReader(fs);
            OutputExpected = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            fs = new FileStream("BeatAllCellsActualTest.txt", FileMode.Open);
            sr = new StreamReader(fs);
            OutputActual = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            Assert.AreSame(OutputExpected, OutputActual);
        }

        [TestMethod]
        public void BeatAllCellsAllTesting()
        {
            Process.Start("Queens.exe", "BeatAllCellsAllInputTest BeatAllCellsAllActualTest");
            
            fs = new FileStream("BeatAllCellsAllExpectedTest.txt", FileMode.Open);
            sr = new StreamReader(fs);
            OutputExpected = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            fs = new FileStream("BeatAllCellsAllActualTest.txt", FileMode.Open);
            sr = new StreamReader(fs);
            OutputActual = sr.ReadToEnd();
            sr.Close();
            fs.Close();

            Assert.AreSame(OutputExpected, OutputActual);
        }

    }
}