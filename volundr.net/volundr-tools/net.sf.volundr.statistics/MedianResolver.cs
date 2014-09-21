using System;
using System.Collections.Generic;

namespace net.sf.volundr.statistics
{
	public sealed class MedianResolver
	{
		/// <summary>
		/// Resolve median value
		/// </summary>
		/// <returns>Returns the middle value if number of entries is not even in the list otherwise the middle two values and an average of them</returns>
		/// <param name="">list</param>
		public static int ResolveFrom (List<Int32> list)
		{
			Int32 result = 0;
			int size = list.Count;
			// If the number of entries in the list is not even.
			if (size % 2 == 1) {
				result = list [size / 2]; // Get the middle
				// value.
			} else { // If the number of entries in the list are even.
				Int32 lowerMiddle = list [size / 2];
				Int32 upperMiddle = list [size / 2 - 1];
				// Get the middle two values and average them.
				result = (lowerMiddle + upperMiddle) / 2;
			}
			return result;
		}

	}
}

