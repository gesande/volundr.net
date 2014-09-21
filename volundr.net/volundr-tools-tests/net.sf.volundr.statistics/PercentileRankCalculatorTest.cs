using NUnit.Framework;
using System;

namespace net.sf.volundr.statistics
{
	[TestFixture ()]
	public class PercentileRankCalculatorTest
	{

		[Test ()]
		public void NearestRank ()
		{
			var samples = 2;
			AssertEquals (0.5, NearestRank (0, samples));
			AssertEquals (0.6, NearestRank (5, samples));
			AssertEquals (0.7, NearestRank (10, samples));
			AssertEquals (0.8, NearestRank (15, samples));
			AssertEquals (0.9, NearestRank (20, samples));
			AssertEquals (1.0, NearestRank (25, samples));
			AssertEquals (1.1, NearestRank (30, samples));
			AssertEquals (1.2, NearestRank (35, samples));
			AssertEquals (1.3, NearestRank (40, samples));
			AssertEquals (1.4, NearestRank (45, samples));
			AssertEquals (1.5, NearestRank (50, samples));
			AssertEquals (1.6, NearestRank (55, samples));
			AssertEquals (1.7, NearestRank (60, samples));
			AssertEquals (1.8, NearestRank (65, samples));
			AssertEquals (1.9, NearestRank (70, samples));
			AssertEquals (2.0, NearestRank (75, samples));
			AssertEquals (2.1, NearestRank (80, samples));
			AssertEquals (2.2, NearestRank (85, samples));
			AssertEquals (2.3, NearestRank (90, samples));
			AssertEquals (2.4, NearestRank (95, samples));
			AssertEquals (2.5, NearestRank (100, samples));
		}

		[Test ()]
		public void NearestRankWith100Samples ()
		{
			var samples = 100;
			AssertEquals (0.5, NearestRank (0, samples));
			AssertEquals (5.5, NearestRank (5, samples));
			AssertEquals (10.5, NearestRank (10, samples));
			AssertEquals (15.5, NearestRank (15, samples));
			AssertEquals (20.5, NearestRank (20, samples));
			AssertEquals (25.5, NearestRank (25, samples));
			AssertEquals (30.5, NearestRank (30, samples));
			AssertEquals (35.5, NearestRank (35, samples));
			AssertEquals (40.5, NearestRank (40, samples));
			AssertEquals (45.5, NearestRank (45, samples));
			AssertEquals (50.5, NearestRank (50, samples));
			AssertEquals (55.5, NearestRank (55, samples));
			AssertEquals (60.5, NearestRank (60, samples));
			AssertEquals (65.5, NearestRank (65, samples));
			AssertEquals (70.5, NearestRank (70, samples));
			AssertEquals (75.5, NearestRank (75, samples));
			AssertEquals (80.5, NearestRank (80, samples));
			AssertEquals (85.5, NearestRank (85, samples));
			AssertEquals (90.5, NearestRank (90, samples));
			AssertEquals (95.5, NearestRank (95, samples));
			AssertEquals (100.5, NearestRank (100, samples));
		}

		private double NearestRank (int percentile, int samples)
		{
			return PercentileRankCalculator.NearestRank (percentile, samples);
		}

		void AssertEquals (double expected, double actual)
		{
			Assert.AreEqual (expected, actual);
		}

	}
}

