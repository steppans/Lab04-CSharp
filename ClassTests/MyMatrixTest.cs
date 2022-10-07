using System.Diagnostics.CodeAnalysis;

namespace ClassTests
{
    [TestClass]
    public class MyMatrixTest
    {
        private MyMatrix? a;
        private MyMatrix? b;

        private MyMatrix? aForMul;
        private MyMatrix? bForMul;

        [TestInitialize]
        public void SetUp()
        {
            a = new(3, 3);
            a.SetData(10, 30);
            b = new(3, 3);
            b.SetData(15, 40);

            aForMul = new(3, 2);
            aForMul.SetData(1, 10);
            bForMul = new(2, 3);
            bForMul.SetData(2, 8);
        }

        [TestMethod]
        public void TestSetMatrixData()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.IsTrue(10 <= a[i, j] && a[i, j] < 30);
                    Assert.IsTrue(15 <= b[i, j] && b[i, j] < 40);
                }
            }
        }

        [TestMethod]
        public void TestAddition()
        {
            MyMatrix result = a + b;

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    Assert.AreEqual(a[i, j] + b[i, j], result[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestSubstraction()
        {
            MyMatrix result = a - b;

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    Assert.AreEqual(a[i, j] - b[i, j], result[i, j]);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAdditionExeptions()
        {
            
            MyMatrix result = aForMul + bForMul;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSubstructionExeptions()
        {

            MyMatrix result = aForMul - bForMul;
        }

        [TestMethod]
        public void TestMulMatrix()
        {
            MyMatrix result = aForMul * bForMul;

            Assert.AreEqual(aForMul.m, result.m);
            Assert.AreEqual(bForMul.n, result.n);

            for(int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    double sum = 0;
                    for (int k = 0; k < 2; ++k)
                    {
                        sum += aForMul[i, k] * bForMul[k, j];
                    }
                    Assert.AreEqual(sum, result[i, j]);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestMulMatrixExeptions()
        {

            MyMatrix result = aForMul * b;
        }

        [TestMethod]
        public void TestMulMatrixOnNum()
        {
            MyMatrix result = a * 3;

            for (int i = 0; i < 3; ++i)
            {
                for(int j = 0; j < 3; ++j)
                {
                    Assert.AreEqual(a[i, j] * 3, result[i, j]);
                }
            }
        }

        [TestMethod]
        public void TestDelMatrixOnNum()
        {
            MyMatrix result = a / 8;

            // Want to put it on a screen
            result.PrintMatrix();

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    Assert.AreEqual(a[i, j] / 8, result[i, j]);
                }
            }
        }
    }
}