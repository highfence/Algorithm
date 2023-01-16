using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm_CSharp
{
	internal class Problems_2023_Week3
	{
		class Test_57
		{
			public static readonly object[] TestSource = new object[]
			{
				// new object[] { new int[][] { new int[] { 1, 3 }, new int[] { 6, 9 } }, new int[] { 2,5 }, new int[][] { new int[] { 1, 5 }, new int[] { 6, 9 } },
				// new object[] { new int[][] { new int[] { 1, 2 }, new int[]{3,5},new int[]{6,7},new int[]{8, 10}, new int[]{12, 16} }, new int[] {4, 8 }, new int[][] { new int[]{1,2}, new int[]{3,10}, new int[]{12,16} } } }
				new object[] { "[[1,3],[6,9]]", "[2,5]", "[[1,5],[6,9]]" },
				new object[] { "[[1,2],[3,5],[6,7],[8,10],[12,16]]", "[4, 8]", "[[1,2],[3,10],[12,16]]" },
				new object[] { "[]", "[5, 7]", "[[5, 7]]" }
			};

			[TestCaseSource(nameof(TestSource))]
			public void Test(string intervals, string newInterval, string expectedResult)
			{
				var arg1 = new TestArgument(intervals);
				var arg2 = new TestArgument(newInterval);
				var result = Insert(arg1.ToJaggedIntArray(), arg2.ToIntArray());

				Assert.That(result, Is.EqualTo(new TestArgument(expectedResult).ToJaggedIntArray()));	
			}

			public int[][] Insert(int[][] intervals, int[] newInterval)
			{
				var mergedIndexes = intervals.Select((v, i) => new { interval = v, index = i })
											 .Where(entry => (entry.interval[0] <= newInterval[0] && newInterval[0] <= entry.interval[1]) || (entry.interval[0] <= newInterval[1] && newInterval[1] <= entry.interval[1]) || (newInterval[0] <= entry.interval[0] && entry.interval[1] <= newInterval[1]))
											 .Select(entry => entry.index).ToArray();

				var result = intervals.Where((_, i) => mergedIndexes.Contains(i) == false).ToList();

				var mergedInterval = new int[] { mergedIndexes.Count() > 0 ? mergedIndexes.Select(idx => intervals[idx][0]).Min() : newInterval[0],
												mergedIndexes.Count() > 0 ? mergedIndexes.Select(idx => intervals[idx][1]).Max() : newInterval[1] };

				if (mergedInterval[0] > newInterval[0]) 
				{
					mergedInterval[0] = newInterval[0];
				}
				if (mergedInterval[1] < newInterval[1]) 
				{
					mergedInterval[1] = newInterval[1];
				}
				result.Add(mergedInterval);
				if (result.Count > 1)
				{
					result.Sort((a, b) => a[0] - b[0]);
				}

				return result.ToArray();
			}
		}

	}
}
