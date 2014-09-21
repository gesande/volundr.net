using System;
using System.Collections.Generic;

namespace net.sf.volundr.statistics
{
	public sealed class StatisticsCalculator
	{
		private List<Int32> values;

		private StatisticsCalculator (List<Int32> values)
		{
			this.values = values;
		}

		public static StatisticsCalculator FromValues (List<Int32> values)
		{
			return new StatisticsCalculator (AsSorted (values));
		}

		private static List<Int32> AsSorted (List<Int32> latencies)
		{
			List<Int32> sortedLatencies = new List<Int32> (latencies);
			sortedLatencies.Sort ();
			return sortedLatencies;
		}

		public Int32 Percentile (int percentile)
		{
			var rank = NearestRank (percentile);
			long rounded = (long)Round (rank);
			int index = (int)(rounded - 1);
			return values.Count == 0 ? 0 : values [
				index >= values.Count ? values.Count - 1 : index];
		}

		private static double Round (double nearestRank)
		{
			return Math.Round (nearestRank, MidpointRounding.AwayFromZero);
		}

		private double NearestRank (int percentile)
		{
			return PercentileRankCalculator
				.NearestRank (percentile, values.Count);
		}

		public Int32 Median ()
		{
			return values.Count == 0 ? 0 : MedianResolver.ResolveFrom (values);
		}

		public Double Mean ()
		{
			if (values.Count == 0) {
				return 0.0;
			}
			long sum = 0;
			foreach (int latency in values) {
				sum += latency;
			}
			return (double)sum / values.Count;
		}

		public double Variance ()
		{
			long n = 0;
			double mean = 0;
			double s = 0.0;
			foreach (int x in values) {
				n++;
				double delta = x - mean;
				mean += delta / n;
				s += delta * (x - mean);
			}
			return Std (s, n);
		}

		public Int32 Max ()
		{
			return values.Count == 0 ? 0 : values [
				values.Count - 1];
		}

		public Int32 Min ()
		{
			return values.Count == 0 ? 0 : values [0];
		}

		public double StandardDeviation ()
		{
			return Math.Sqrt (Variance ());
		}

		private static double Std (double s, long n)
		{
			return (s / n);
		}
	}
}

