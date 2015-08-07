using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovingAverageCalculator;

namespace MovingAverageCalculatorTest
{
    [TestClass]
    public class MovingAverageCalculatorTestClass
    {
        private readonly double[] _testCase1 = { 0, 1, -2, 3, -4, 5, -6, 7, -8, 9 };
        private readonly double[] _testResult1 = { 0, 0.5, -0.33333333333333331, 0.5, -0.4, 0.6, -0.8, 1, -1.2, 1.4 };
        private readonly double[] _testCase2 = { 0, 1, 2, 3 };
        private readonly double[] _testResult2 = { 0, 0.5, 1, 2 };
        private AverageHelper _ah;

        [TestInitialize]
        public void TestInit()
        {
            _ah = new AverageHelper();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var results = _ah.FindAllAverages(_testCase1.ToList(), 5).ToArray();
            CheckForEqualityHelper(results, _testResult1);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var results = _ah.FindAllAverages(_testCase2.ToList(), 3).ToArray();
            CheckForEqualityHelper(results, _testResult2);
        }

        [TestMethod]
        [ExpectedException(typeof(ValueCountLessThanWindowException))]
        public void ValueCountLessThanWindowException()
        {
            _ah.FindAllAverages(new double[0], 1);
        }

        [TestMethod]
        [ExpectedException(typeof(BadWindowException))]
        public void BadWindowException()
        {
            _ah.FindAllAverages(new double[0], -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ValuesCountException))]
        public void ValuesCountException()
        {
            _ah.FindAllAverages(new double[0], 0);
        }

        private static void CheckForEqualityHelper(IList<double> results, Double[] arrayToCheckAgainst)
        {
            for (var i = 0; i < results.Count(); i++)
            {
                if (arrayToCheckAgainst[i] > results[i])
                {
                    Assert.IsTrue((arrayToCheckAgainst[i] - results[i]) < 1);
                }
                else
                {
                    Assert.IsTrue((results[i] - arrayToCheckAgainst[i]) < 1);
                }
            } 
        }

        [TestCleanup]
        public void CleanUp()
        {
            
        }
    }
}
