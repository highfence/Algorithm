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
				new object[] { new int[][] { new int[] { 1, 3 }, new int[] { 6, 9 } }, new int[] { 2,5 }, new int[][] { new int[] { 1, 5 }, new int[] { 6, 9 } },
				new object[] { new int[][] { new int[] { 1, 2 }, new int[]{3,5},new int[]{6,7},new int[]{8, 10}, new int[]{12, 16} }, new int[] {4, 8 }, new int[][] { new int[]{1,2}, new int[]{3,10}, new int[]{12,16} } } }
			};

			[TestCaseSource(nameof(TestSource))]
			public void Test(int[][] intervals, int[] newInterval, int[][] expectedInterval)
			{
				
			}

		}

	}
}
