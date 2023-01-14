using System.Text;

namespace Algorithm_CSharp
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static readonly object[] TestSource_1497 =
        {
            new object[] { new int[] { 1, 2, 3, 4, 5, 10, 6, 7, 8, 9 }, 5, true },
            new object[] { new int[] { 1, 2, 3, 4, 5, 6 }, 7, true },
            new object[] { new int[] { 1, 2, 3, 4, 5, 6 }, 10, false },
        };

        [TestCaseSource(nameof(TestSource_1497))]
        public void Test_1497(int[] arr, int k, bool expectedResult)
        {
            var result = CanArrange(arr, k);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        public bool CanArrange(int[] arr, int k)
        {
            return false;
        }

        private static readonly object[] TestSource_1061 =
        {
            new object[] { "parker", "morris", "parser", "makkek" },
            new object[] { "hello", "world", "hold", "hdld" },
            new object[] { "leetcode", "programs", "sourcecode", "aauaaaaada" },
        };

        [TestCaseSource(nameof(TestSource_1061))]
        public void Test_1061(string s1, string s2, string baseStr, string expectedResult)
        {
            var result = SmallestEquivalentString(s1, s2, baseStr);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        public string SmallestEquivalentString(string s1, string s2, string baseStr)
        {
            Dictionary<char, char> translator = new();

            for (var i = 0; i < s1.Length; i++)
            {
                var c1 = s1[i];
                var c2 = s2[i];

                var lexicographcallySmallerOne = c1 < c2 ? c1 : c2;

                if (translator.ContainsKey(c1) == false)
                {
                    translator.Add(c1, lexicographcallySmallerOne);
                }
                if (translator.ContainsKey(c2) == false)
                {
                    translator.Add(c2, lexicographcallySmallerOne);
                }
                
                var translatedC1 = translator[c1];
                var translatedC2 = translator[c2];

                var bestOne = new[] { translatedC1, translatedC2, lexicographcallySmallerOne }.Min();

                var charactersInGroup = translator.Where(entry => entry.Value == translatedC1 || entry.Value == translatedC2 || entry.Value == lexicographcallySmallerOne).Select(entry => entry.Key);
                foreach (var character in charactersInGroup)
                {
                    translator[character] = bestOne;
                }
            }

            return new string(baseStr.Select(c => translator.ContainsKey(c) ? translator[c] : c).ToArray());
        }
    }
}