using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LR6;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
//------ ”ƒ¿À≈Õ»≈ ÷»‘– --------
        [DataTestMethod]
        [DataRow(new char[] { '1', 'a', '2', 'b', '3', 'c' }, new char[] { 'a', 'b', 'c' }, DisplayName = "Test1")]
        [DataRow(new char[] { '1', 'a', '2', 'b', '3', 'c' }, new char[] { 'a', 'b', 'c' }, DisplayName = "Test2")]
        [DataRow(new char[] { '1', '2', 'b', '3', 'c' }, new char[] { 'b', 'c' }, DisplayName = "Test3")]     
        public void TestDeleteDigits(char[] input, char [] er)
        {
            CollectionAssert.AreEqual(er, LR6Program.DeleteDigits(input));
        }

//------ —Œ«ƒ¿Õ»≈ Ã¿——»¬¿ --------
        [DataTestMethod]
        [DataRow(0,0,DisplayName = "Test 1")]
        [DataRow(1,1,DisplayName = "Test 2")]
        [DataRow(5,5,DisplayName = "Test 3")]
        [DataRow(10,10, DisplayName = "Test 4")]
        public void TestCreateArrayRandom(int input, int er)
        {
            Assert.AreEqual(LR6Program.CreateArrayRandom(input).Length, er);
        }

//------ –¿«ƒ≈ƒ≈À≈Õ»≈ —“–Œ » Õ¿ œ–≈ƒÀŒ∆≈Õ»ﬂ » —ÀŒ¬¿ --------
        public static Dictionary<string , string[][]> DataSplitString = new Dictionary<string, string[][]>
        {
            ["abcd abc, ab. abcd : ab, a!"] = new string[][]
            {
                new string[] { "abcd", " ", "abc", ",", " ", "ab" },
                new string[] { "."},
                new string[] { " ", "abcd", " ", ":", " ", "ab", ",", " ", "a" },
                new string[] {"!"}
            },
            ["abcd: ab, cd. abc ab"] = new string[][]
            {
                new string[] { "abcd", ":", " ", "ab", ",", " ", "cd" },
                new string[] { "." },
                new string[] { " ", "abc", " ", "ab" }
            },
            [": ab, cd! abc "] = new string[][]
            {
                new string[] { ":", " ", "ab", ",", " ", "cd" },
                new string[] { "!" },
                new string[] { " ", "abc", " "}
            }
        };
        public static IEnumerable<object[]> GetDataSplitString()
        {
            foreach (var set in DataSplitString)
                yield return new object[] { set.Value, set.Key };
        }

        [DynamicData(nameof(GetDataSplitString), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void TestSplitString(string[][] er, string input)
        {
            string[][] ar = LR6Program.SplitString(input);

            Assert.AreEqual(er.Length, ar.Length);
            
            foreach (int i in Enumerable.Range(0, ar.Length))
            {
                CollectionAssert.AreEqual(er[i], ar[i]);
            }
        }

//------ œ≈–≈¬Œ–Œ“ —ÀŒ¬ ¬ œ–≈ƒÀŒ∆≈Õ»» --------
        public static Dictionary<int, List<string[]>> DataReverseWordsSentence = new Dictionary<int, List<string[]>>
        {
            [1] = new List<string[]> { 
                new string[] { "abcd", " ", "ab", ",", " ", "abc" }, 
                new string[] { "dcba", " ", "ba", ",", " ", "cba" } 
            },
            [2] = new List<string[]> 
            { 
                new string[] { "abc", "ab", "a" },
                new string[] { "cba", "ba", "a"} 
            },
            [3] = new List<string[]> 
            { 
                new string[] { "" },
                new string[] { "" }
            },
            [4] = new List<string[]>
            {
                new string[] { " ", ".", ",", ":", "!" },
                new string[] { " ", ".", ",", ":", "!" }
            },
        };
        public static IEnumerable<object[]> GetDataReverseWordsSentence()
        {
            foreach (var set in DataReverseWordsSentence)
                yield return new object[] { set.Value[0],set.Value[1] };
        }

        [DynamicData(nameof(GetDataReverseWordsSentence), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void TestReverseWordsSentence(string[] input, string[] er)
        {            
            string[] ar = LR6Program.ReverseWordsSentence(input);

            CollectionAssert.AreEqual(er, ar);
        }

//------ —Œ–“»–Œ¬ ¿ —ÀŒ¬ œŒ ”¡€¬¿Õ»ﬁ ƒÀ»Õ€ --------
        public static Dictionary<int, List<string[]>> DataOrderDescSentence = new Dictionary<int, List<string[]>>
        {
            [1] = new List<string[]> 
            { 
                new string[] { "abcd", " ", "ab", ",", " ", "abc" }, 
                new string[] { "abcd", " ", "abc", ",", " ", "ab" }
            },
            [2] = new List<string[]>
            {
                new string[] { "ab", " ", "ab", ",", " ", "ab" },
                new string[] { "ab", " ", "ab", ",", " ", "ab" }
            },
            [3] = new List<string[]>
            {
                new string[] { "abcd", "ab", "abc" ," ", ",", " " },
                new string[] { "abcd", "abc", "ab", " ", ",", " " }
            },
            [4] = new List<string[]>
            {
                new string[] { "a","abcd", "abc", "abcde","ab" },
                new string[] { "abcde", "abcd", "abc", "ab", "a" }
            }
        };
        public static IEnumerable<object[]> GetDataOrderDescSentence()
        {
            foreach (var set in DataOrderDescSentence)
                yield return new object[] { set.Value[0], set.Value[1] };
        }

        [DynamicData(nameof(GetDataOrderDescSentence), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void TestOrderDescSentence(string[] input, string[] er)
        {
            string[] ar = LR6Program.OrderDescSentence(input);

            CollectionAssert.AreEqual(er, ar);
        }

//------ —¡Œ– ¿ —“–Œ » »« —ÀŒ¬ --------
        public static Dictionary<string, string[][]> DataAssembleString = new Dictionary<string, string[][]>
        {
            ["abcd abc, ab. abcd : ab, a!"] = new string[][]
            { 
                new string[] { "abcd", " ", "abc", ",", " ", "ab" }, 
                new string[] { "."},
                new string[] { " ", "abcd", " ", ":", " ", "ab", ",", " ", "a" },
                new string[] {"!"}
            }
        };
        public static IEnumerable<object[]> GetDataAssembleString()
        {
            foreach (var set in DataAssembleString)
                yield return new object[] { set.Value, set.Key };
        }
        [DynamicData(nameof(GetDataAssembleString), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void TestAssembleString(string[][] input, string er)
        {
            string ar = LR6Program.AssembleString(input);

            Assert.AreEqual(er, ar);
        }

        //------ »Õ“≈√–¿÷»ŒÕÕŒ≈ “≈—“»–Œ¬¿Õ»≈ --------
        public static Dictionary<string, string> DataReverseOrderString = new Dictionary<string, string>
        {
            ["a abcd, ab. abcd : ab, abc!"] = "dcba ba, a. dcba : cba, ba!",
            ["a a, a. a : a, a!"] = "a a, a. a : a, a!",
            [",ab!"] = ",ba!",
            ["abc!"] = "cba!",
        };
        public static IEnumerable<object[]> GetDataReverseOrderString()
        {
            foreach (var set in DataReverseOrderString)
                yield return new object[] { set.Key, set.Value };
        }
        [DynamicData(nameof(GetDataReverseOrderString), DynamicDataSourceType.Method)]
        [DataTestMethod]
        public void TestReverseOrderString(string input, string er)
        {
            string ar = LR6Program.ReverseOrderString(input);

            Assert.AreEqual(er, ar);
        }
    }
}
