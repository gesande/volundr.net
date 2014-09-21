using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace net.sf.volundr.statistics
{
	[TestFixture ()]
	public class StatisticsCalculatorTest
	{

		[Test ()]
		public void StatsOdd ()
		{
			List<Int32> values = new List<Int32> ();
			for (int i = 100; i > -1; i--) {
				values.Add (i);
			}
			StatisticsCalculator stat = StatisticsCalculator
				.FromValues (values);
			AssertEquals ("Min doesn't match!", 0, stat.Min ());
			AssertEquals ("Max doesn't match!", 100, stat.Max ());
			AssertEquals ("Mean doesn't match!", 50.0, stat.Mean ());
			AssertEquals ("Median doesn't match!", 50, stat.Median ());
			AssertEquals ("50 percentile doesn't match!", 50, stat.Percentile (50));
			AssertEquals ("90 percentile doesn't match!", 90, stat.Percentile (90));
			AssertEquals ("95 percentile doesn't match!", 95, stat.Percentile (95));
			AssertEquals ("96 percentile doesn't match!", 96, stat.Percentile (96));
			AssertEquals ("97 percentile doesn't match!", 97, stat.Percentile (97));
			AssertEquals ("98 percentile doesn't match!", 98, stat.Percentile (98));
			AssertEquals ("99 percentile doesn't match!", 99, stat.Percentile (99));
			AssertEquals ("Standard deviation doesn't match!", 29.154759474226502,
				stat.StandardDeviation ());
			AssertEquals ("Standard deviation doesn't match!", 850.0,
				stat.Variance ()); 
		}

		[Test ()]
		public void StatsEven ()
		{
			List<Int32> values = new List<Int32> ();
			for (int i = 100; i > 0; i--) {
				values.Add (i);
			}
			StatisticsCalculator stat = StatisticsCalculator
				.FromValues (values);
			AssertEquals ("Min doesn't match!", 1, stat.Min ());
			AssertEquals ("Max doesn't match!", 100, stat.Max ());
			AssertEquals ("Mean doesn't match!", 50.5, stat.Mean ());
			AssertEquals ("Median doesn't match!", 50, stat.Median ());
			AssertEquals ("50 percentile doesn't match!", 51, stat.Percentile (50));
			AssertEquals ("90 percentile doesn't match!", 91, stat.Percentile (90));
			AssertEquals ("95 percentile doesn't match!", 96, stat.Percentile (95));
			AssertEquals ("96 percentile doesn't match!", 97, stat.Percentile (96));
			AssertEquals ("97 percentile doesn't match!", 98, stat.Percentile (97));
			AssertEquals ("98 percentile doesn't match!", 99, stat.Percentile (98));
			AssertEquals ("99 percentile doesn't match!", 100, stat.Percentile (99));
			AssertEquals ("Standard deviation doesn't match!", 28.86607004772212,
				stat.StandardDeviation ());
			AssertEquals ("Standard deviation doesn't match!", 833.25,
				stat.Variance ());
		}

		protected static void AssertEquals (string message, double expected, double actual)
		{
			Assert.AreEqual (expected, actual, message);
		}

		protected static void AssertEquals (string message, int expected, int actual)
		{
			Assert.AreEqual (expected, actual, message);
		}

	}
}

