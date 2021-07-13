using Microsoft.VisualStudio.TestTools.UnitTesting;
using LR9;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        //------ —◊≈“◊»  Œ¡⁄≈ “Œ¬ --------

        private static int COUNTER = 5;

        public static IEnumerable<object[]> GetDataCounter()
        {
            int all = 0;
            foreach (var i in Enumerable.Range(0, COUNTER))
            {
                new MoneyArray(i);
                all += i;
                yield return new object[] { all };
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetDataCounter), DynamicDataSourceType.Method)]
        public void AATestCounter(int er)
        {
            System.Console.WriteLine(er);
            System.Console.WriteLine(Money.ObjectCount);
            Assert.AreEqual(er, Money.ObjectCount);
        }
    }

    [TestClass]
    public class UnitTest2
    {

        //------ ‘”Õ ÷»» ¬€◊»“¿Õ»ﬂ  Œœ≈≈  --------

        public static List<object[]> DataSubtractKopecks = new List<object[]>
        {
            new object []
            {
                new Money {Rubles = 100, Kopecks = 100 },
                100,
                new Money {Rubles = 100, Kopecks = 0 }
            },
            new object []
            {
                new Money {Rubles = 100, Kopecks = 100 },
                101,
                new Money {Rubles = 99, Kopecks = 99 }
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 0 },
                100,
                new Money {Rubles = 0, Kopecks = 0 }
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 0 },
                101,
                new Money {Rubles = 1, Kopecks = 0 }
            },
            new object []
            {
                new Money {Rubles = 100, Kopecks = 100 },
                -100,
                new Money {Rubles = 102, Kopecks = 0 }
            },
            new object []
            {
                new Money {Rubles = 100, Kopecks = 100 },
                0,
                new Money {Rubles = 101, Kopecks = 0 }
            },
        };
        public static IEnumerable<object[]> GetDataSubtractKopecks()
        {
            foreach (var set in DataSubtractKopecks)
                yield return set;
        }

        [TestMethod]
        [DynamicData(nameof(GetDataSubtractKopecks), DynamicDataSourceType.Method)]
        public void TestSubtractKopecks(Money m, int kopecks, Money er)
        {
            m.SubtractKopecks(kopecks);
            Assert.AreEqual(m, er);
        }

        // —“¿“»◊≈— ¿ﬂ ‘”Õ ÷»ﬂ
        [TestMethod]
        [DynamicData(nameof(GetDataSubtractKopecks), DynamicDataSourceType.Method)]
        public void TestStaticSubtractKopecks(Money m, int kopecks, Money er)
        {
            Money ar = Money.StaticSubtractKopecks(m, kopecks);
            Assert.AreEqual(ar, er);
        }

        //------ ”Õ¿–Õ€… œÀﬁ— --------

        public static List<object[]> DataUnaryPlusOperation = new List<object[]>
        {
            new object []
            {
                new Money {Rubles = 0, Kopecks = 0 },
                new Money {Rubles = 0, Kopecks = 1 }
            },
            new object []
            {
                new Money {Rubles = 0, Kopecks = 99 },
                new Money {Rubles = 1, Kopecks = 0 }
            },
            new object []
            {
                new Money {Rubles = 0, Kopecks = 100 },
                new Money {Rubles = 1, Kopecks = 1 }
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 0 },
                new Money {Rubles = 1, Kopecks = 1 }
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 99 },
                new Money {Rubles = 2, Kopecks = 0 }
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 100 },
                new Money {Rubles = 2, Kopecks = 1 }
            }
        };
        public static IEnumerable<object[]> GetDataUnaryPlusOperation()
        {
            foreach (var set in DataUnaryPlusOperation)
                yield return set;
        }

        [TestMethod]
        [DynamicData(nameof(GetDataUnaryPlusOperation), DynamicDataSourceType.Method)]
        public void TestUnaryPlusOperation(Money m, Money er)
        {
            m++;
            Assert.AreEqual(m, er);
        }

        //------ ”Õ¿–Õ€… Ã»Õ”— --------

        public static List<object[]> DataUnaryMinusOperation = new List<object[]>
        {
            new object []
            {
                new Money {Rubles = 0, Kopecks = 0 },
                new Money {Rubles = 0, Kopecks = 0 }
            },
            new object []
            {
                new Money {Rubles = 0, Kopecks = 1 },
                new Money {Rubles = 0, Kopecks = 0 }
            },
            new object []
            {
                new Money {Rubles = 0, Kopecks = 100 },
                new Money {Rubles = 0, Kopecks = 99 }
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 0 },
                new Money {Rubles = 0, Kopecks = 99 }
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 1 },
                new Money {Rubles = 1, Kopecks = 0 }
            }
        };
        public static IEnumerable<object[]> GetDataUnaryMinusOperation()
        {
            foreach (var set in DataUnaryMinusOperation)
                yield return set;
        }

        [TestMethod]
        [DynamicData(nameof(GetDataUnaryMinusOperation), DynamicDataSourceType.Method)]
        public void TestUnaryMinusOperation(Money m, Money er)
        {
            m--;
            Assert.AreEqual(m, er);
        }

        //------ œ–»¬≈ƒ≈Õ»≈   “»œ” INT --------

        public static List<object[]> DataTypeConvertionInt = new List<object[]>
        {
            new object []
            {
                new Money {Rubles = 0, Kopecks = 0 },
                0
            },
            new object []
            {
                new Money {Rubles = 0, Kopecks = 1 },
                0
            },
            new object []
            {
                new Money {Rubles = 0, Kopecks = 100 },
                1
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 0 },
                1
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 1 },
                1
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 100 },
                2
            }
        };
        public static IEnumerable<object[]> GetDataTypeConvertionInt()
        {
            foreach (var set in DataTypeConvertionInt)
                yield return set;
        }

        [TestMethod]
        [DynamicData(nameof(GetDataTypeConvertionInt), DynamicDataSourceType.Method)]
        public void TestTypeConvertionInt(Money m, int er)
        {
            Assert.AreEqual((int)m, er);
        }

        //------ œ–»¬≈ƒ≈Õ»≈   “»œ” BOOL --------

        public static List<object[]> DataTypeConvertionBool = new List<object[]>
        {
            new object []
            {
                new Money {Rubles = 0, Kopecks = 0 },
                false
            },
            new object []
            {
                new Money {Rubles = 0, Kopecks = 1 },
                true
            },
            new object []
            {
                new Money {Rubles = 0, Kopecks = 100 },
                true
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 0 },
                true
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 1 },
                true
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 100 },
                true
            }
        };
        public static IEnumerable<object[]> GetDataTypeConvertionBool()
        {
            foreach (var set in DataTypeConvertionBool)
                yield return set;
        }

        [TestMethod]
        [DynamicData(nameof(GetDataTypeConvertionBool), DynamicDataSourceType.Method)]
        public void TestTypeConvertionBool(Money m, bool er)
        {
            bool flag = m;
            Assert.AreEqual(flag, er);
        }

        //------ ¬€◊»“¿Õ»≈ (Money - Int) --------

        public static List<object[]> DataMoneyMinusInt = new List<object[]>
        {
            new object []
            {
                new Money {Rubles = 0, Kopecks = 0 },
                0,
                new Money {Rubles = 0, Kopecks = 0 }
            },
            new object []
            {
                new Money {Rubles = 0, Kopecks = 1 },
                1,
                new Money {Rubles = 0, Kopecks = 0 }
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 0 },
                1,
                new Money {Rubles = 0, Kopecks = 99 }
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 0 },
                100,
                new Money {Rubles = 0, Kopecks = 0 }
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 1 },
                1,
                new Money {Rubles = 1, Kopecks = 0 }

            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 0 },
                101,
                new Money {Rubles = 1, Kopecks = 0 }
            }
        };
        public static IEnumerable<object[]> GetDataMoneyMinusInt()
        {
            foreach (var set in DataMoneyMinusInt)
                yield return set;
        }

        [TestMethod]
        [DynamicData(nameof(GetDataMoneyMinusInt), DynamicDataSourceType.Method)]
        public void TestMoneyMinusInt(Money m, int num, Money er)
        {
            Money ar = m - num;
            Assert.AreEqual(ar, er);
        }

        //------ ¬€◊»“¿Õ»≈ (Int - Money) --------

        public static List<object[]> DataIntMinusMoney = new List<object[]>
        {
            new object []
            {
                new Money {Rubles = 0, Kopecks = 0 },
                0,
                0
            },
            new object []
            {
                new Money {Rubles = 0, Kopecks = 1 },
                1,
                0
            },
            new object []
            {
                new Money {Rubles = 0, Kopecks = 99 },
                100,
                1
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 0 },
                100,
                0
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 1 },
                1,
                -100
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 0 },
                101,
                1
            }
        };
        public static IEnumerable<object[]> GetDataIntMinusMoney()
        {
            foreach (var set in DataIntMinusMoney)
                yield return set;
        }

        [TestMethod]
        [DynamicData(nameof(GetDataIntMinusMoney), DynamicDataSourceType.Method)]
        public void TestIntMinusMoney(Money m, int num, int er)
        {
            int ar = num - m;
            Assert.AreEqual(ar, er);
        }

        //------ ¬€◊»“¿Õ»≈ (Money - Money) --------

        public static List<object[]> DataMoneyMinusMoney = new List<object[]>
        {
            new object []
            {
                new Money {Rubles = 0, Kopecks = 0 },
                new Money {Rubles = 0, Kopecks = 0 },
                new Money {Rubles = 0, Kopecks = 0 }
            },
            new object []
            {
                new Money {Rubles = 0, Kopecks = 1 },
                new Money {Rubles = 0, Kopecks = 0 },
                new Money {Rubles = 0, Kopecks = 1 },
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 0 },
                new Money {Rubles = 0, Kopecks = 99 },
                new Money {Rubles = 0, Kopecks = 1 },
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 0 },
                new Money {Rubles = 1, Kopecks = 0 },
                new Money {Rubles = 0, Kopecks = 0 },
            },
            new object []
            {
                new Money {Rubles = 1, Kopecks = 1 },
                new Money {Rubles = 1, Kopecks = 0 },
                new Money {Rubles = 0, Kopecks = 1 },
            },
            new object []
            {
                new Money {Rubles = 0, Kopecks = 50 },
                new Money {Rubles = 0, Kopecks = 90 },
                new Money {Rubles = 0, Kopecks = 50 },
            }
        };
        public static IEnumerable<object[]> GetDataMoneyMinusMoney()
        {
            foreach (var set in DataMoneyMinusMoney)
                yield return set;
        }

        [TestMethod]
        [DynamicData(nameof(GetDataMoneyMinusMoney), DynamicDataSourceType.Method)]
        public void TestMoneyMinusMoney(Money m1, Money m2, Money er)
        {
            Money ar = m1 - m2;
            Assert.AreEqual(ar, er);
        }

        //------ C–≈ƒÕ≈≈ ¿–»‘Ã≈“»◊≈— Œ≈ --------

        public static List<object[]> DataAverage = new List<object[]>
        {
            new object []
            {
                new MoneyArray
                (
                    new Money[]
                    {
                        new Money(1,0),
                        new Money(2,0),
                        new Money(3,0),
                    }
                ),
                new Money(2,0)
            },
            new object []
            {
                new MoneyArray
                (
                    new Money[]
                    {
                        new Money(3,1),
                        new Money(3,1),
                        new Money(3,1),
                    }
                ),
                new Money(3,1)
            },
            new object []
            {
                new MoneyArray
                (
                    new Money[]
                    {
                        new Money(0,1),
                        new Money(0,2),
                        new Money(0,3),
                    }
                ),
                new Money(0,2)
            },
            new object []
            {
                new MoneyArray
                (
                    new Money[]
                    {
                        new Money(1,1),
                        new Money(2,2),
                        new Money(3,3),
                    }
                ),
                new Money(2,2)
            },
            new object []
            {
                new MoneyArray
                (
                    new Money[]
                    {
                        new Money(1,50),
                        new Money(2,50),
                        new Money(3,50),
                    }
                ),
                new Money(2,50)
            },
            new object []
            {
                new MoneyArray
                (
                    new Money[]
                    {
                        new Money(0,0),
                        new Money(0,0),
                        new Money(0,0),
                    }
                ),
                new Money(0,0)
            },
            new object []
            {
                new MoneyArray
                (
                    new Money[]
                    {
                        new Money(0,3),
                        new Money(0,3),
                        new Money(0,4),
                    }
                ),
                new Money(0,3)
            }
        };
        public static IEnumerable<object[]> GetDataAverage()
        {
            foreach (var set in DataAverage)
                yield return set;
        }

        [TestMethod]
        [DynamicData(nameof(GetDataAverage), DynamicDataSourceType.Method)]
        public void TestAverage(MoneyArray ma, Money er)
        {
            Money ar = ma.Average();
            Assert.AreEqual(ar, er);
        }

        //------ C–≈ƒÕ≈≈ ¿–»‘Ã≈“»◊≈— Œ≈  Œœ≈≈  --------

        public static List<object[]> DataAverageKopecks = new List<object[]>
        {
            new object []
            {
                new MoneyArray
                (
                    new Money[]
                    {
                        new Money(1,10),
                        new Money(2,30),
                        new Money(3,40),
                    }
                ),
                26.67
            },
            new object []
            {
                new MoneyArray
                (
                    new Money[]
                    {
                        new Money(3,0),
                        new Money(3,0),
                        new Money(3,0),
                    }
                ),
                0
            },
            new object []
            {
                new MoneyArray
                (
                    new Money[]
                    {
                        new Money(0,1),
                        new Money(0,2),
                        new Money(0,3),
                    }
                ),
                2
            },
        };
        public static IEnumerable<object[]> GetDataAverageKopecks()
        {
            foreach (var set in DataAverageKopecks)
                yield return set;
        }

        [TestMethod]
        [DynamicData(nameof(GetDataAverageKopecks), DynamicDataSourceType.Method)]
        public void TestAverageKopecks(MoneyArray ma, double er)
        {
            double ar = ma.AverageKopecks;
            Assert.AreEqual(ar, er);
        }

        //------ C–≈ƒÕ≈≈ ¿–»‘Ã≈“»◊≈— Œ≈ –”¡À≈… --------

        public static List<object[]> DataAverageRubles = new List<object[]>
        {
            new object []
            {
                new MoneyArray
                (
                    new Money[]
                    {
                        new Money(10,1),
                        new Money(30,2),
                        new Money(40,3),
                    }
                ),
                26.67
            },
            new object []
            {
                new MoneyArray
                (
                    new Money[]
                    {
                        new Money(0,0),
                        new Money(0,0),
                        new Money(0,0),
                    }
                ),
                0
            },
            new object []
            {
                new MoneyArray
                (
                    new Money[]
                    {
                        new Money(1,1),
                        new Money(2,2),
                        new Money(3,3),
                    }
                ),
                2
            },
        };
        public static IEnumerable<object[]> GetDataAverageRubles()
        {
            foreach (var set in DataAverageRubles)
                yield return set;
        }

        [TestMethod]
        [DynamicData(nameof(GetDataAverageRubles), DynamicDataSourceType.Method)]
        public void TestAverageRubles(MoneyArray ma, double er)
        {
            double ar = ma.AverageRubles;
            Assert.AreEqual(ar, er);
        }


        [TestMethod]
        public void TestMethod1()
        {


            Money m1, m2, m3, m4, m5, m6, m7, m8, m9;


            m1 = new Money(000, 000);

            Assert.AreEqual(0, m1.Rubles);
            Assert.AreEqual(0, m1.Kopecks);

            m2 = new Money();

            Assert.AreEqual(0, m2.Rubles);
            Assert.AreEqual(0, m2.Kopecks);

            m3 = new Money(100, 100);

            Assert.AreEqual(101, m3.Rubles);
            Assert.AreEqual(0, m3.Kopecks);

            m4 = new Money(-100, 100);


            m5 = new Money(100, -100);


            m6 = new Money(-100, -100);


            m7 = new Money(-100);


            m8 = new Money(100);


            m9 = new Money(50);




        }
    }

}