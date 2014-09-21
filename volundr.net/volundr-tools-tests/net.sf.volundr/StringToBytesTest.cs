using NUnit.Framework;
using System;

namespace net.sf.volundr
{
	[TestFixture ()]
	public class StringToBytesTest
	{
		[Test ()]
		public void ToBytes ()
		{
			Assert.AreEqual (new byte[]{118, 0, 246, 0, 108, 0 , 117,0,110, 0, 100, 0, 114, 0}, StringToBytes.ToBytes ("völundr"));
		}
	}
}

