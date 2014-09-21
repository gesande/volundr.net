using System;

namespace net.sf.volundr.statistics
{
	public sealed class PercentileRankCalculator
	{

		/// <summary>
		/// Calculates the nearest rank.
		/// <seealso cref="http://en.wikipedia.org/wiki/Percentile"/>
		/// </summary>
		/// <param name="percentile">percentile (0-100).</param>
		/// <param name="sampleCount">number of samples</param>
		public static double NearestRank (int percentile,
		                                  long sampleCount)
		{
			return percentile * sampleCount / 100.0000 + 0.5000;
		}

	}
}

