using NUnit.Framework;
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace net.sf.volundr.io
{
	[TestFixture ()]
	public class StreamToLinesTest
	{
		[Test ()]
		public void Write ()
		{
			Stream stream = StringToMemoryStreamBuilder.Builder (Encoding.UTF8).WriteLine ("line1").WriteLine ("line2").WriteLine ("line3").Done ();
			VisitingLines visitor = new VisitingLines ();
			StreamToLines streamToLines = new StreamToLines (visitor, Encoding.UTF8);
			streamToLines.ReadFrom (stream);
			visitor.NoEmptyLines ().Lines (3).Line (0, "line1").Line (1, "line2").Line (2, "line3");
		}

	}
}

