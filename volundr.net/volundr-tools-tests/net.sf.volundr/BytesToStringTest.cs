using NUnit.Framework;
using System;
using System.Text;

namespace net.sf.volundr
{
	[TestFixture ()]
	public class BytesToStringTest
	{
		[Test ()]
		public void Convert ()
		{
			Assert.AreEqual("völundr", BytesToString.Convert (new byte[]{118, 0, 246, 0, 108, 0 , 117,0,110, 0, 100, 0, 114, 0}));
		}
	}
}

