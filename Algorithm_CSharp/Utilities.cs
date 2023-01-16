using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Algorithm_CSharp
{
	internal class Utilities
	{

	}

	public class TestArgument
	{
		public string Value { get; set; }
		public TestArgument(string value) 
		{
			this.Value = value;
		}

		public static implicit operator TestArgument(string value)
		{
			return new TestArgument(value);
		}

		public static implicit operator string(TestArgument argument)
		{
			return argument.Value;
		}

		// string value "[[1,2],[3,10]]" translate to int[][] type
		public int[][] ToJaggedIntArray()
		{
			var value = Value.Replace(" ", "");

			var inDimensionString = value.Substring(1, value.Length - 2);
			var firstDimensionLength = Regex.Matches(inDimensionString, "]").Count;
			var result = new int[firstDimensionLength][];

			var innerStartIndex = 0;
			var innerEndIndex = 0;

			for (int innerIndex = 0; innerIndex < Regex.Matches(inDimensionString, "]").Count; ++innerIndex)
			{
				innerStartIndex = inDimensionString.IndexOf('[', innerEndIndex);
				innerEndIndex = inDimensionString.IndexOf(']', innerStartIndex);

				var intArray = inDimensionString.Substring(innerStartIndex, innerEndIndex - innerStartIndex).Replace("[", "").Replace("]", "").Split(',').Select(int.Parse).ToArray();
				result[innerIndex] = intArray;
			}

			return result; 
		}

		// string value "[2,5]" translate to int[] type
		public int[] ToIntArray()
		{
			return Value.Replace("[", "").Replace("]", "").Split(',').Select(int.Parse).ToArray();
		}
	}

	public class Test_Utilities
	{
		public readonly static object[] Source_TestArgument_StringToIntJaggedArray = new object[] 
		{
			new object[]{ "[[1,2],[3,10]]", new int[][] { new int[] { 1, 2 }, new int[] { 3, 10 } } }
		};

		[TestCaseSource(nameof(Source_TestArgument_StringToIntJaggedArray))]
		public void Test_TestArgument_StringToIntJaggedArray(string inputValue, int[][] expected)
		{
			var argument = new TestArgument(inputValue);
			Assert.That(expected, Is.EqualTo(argument.ToJaggedIntArray()));
		}
	}
}
