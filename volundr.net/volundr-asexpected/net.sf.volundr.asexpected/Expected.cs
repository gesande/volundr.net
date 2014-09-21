using System;

namespace net.sf.volundr.asexpected
{
	public interface Expected<PARENT>
	{
		Expected<PARENT> String(string str);
		Expected<PARENT> Line(string line);

		/// <summary>
		/// Ends the expectation, i.e. does the assert.
		/// </summary>
		PARENT End();

	}
}

