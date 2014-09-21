using System;
using NUnit.Framework;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace net.sf.volundr.io
{
	[TestFixture ()]
	public class GZipStreamToLinesTest
	{

		[Test ()]
		public void ReadStream ()
		{
			Stream stream = StringToMemoryStreamBuilder.Builder (Encoding.UTF8).WriteLine ("line1").WriteLine ("line2").Done ();
			Console.WriteLine ("uncompressed stream length= " + stream.Length);
			var memoryStream = new MemoryStream ();
			var gZipStream = new GZipStream (memoryStream, CompressionMode.Compress);
			stream.CopyTo (gZipStream);
			gZipStream.Flush ();
			memoryStream.Position = 0;
			Console.WriteLine ("compressed stream length= " + memoryStream.Length);
			var visitingLines = new VisitingLines ();
			var compressed = new MemoryStream (memoryStream.ToArray ());
			Console.WriteLine ("(copied) compressed stream length= " + compressed.Length);
			new GZipStreamToLines (visitingLines, Encoding.UTF8).ReadFrom (memoryStream);
			visitingLines.NoEmptyLines ().Lines (2).Line (0, "line1").Line (1, "line2");
		}
	}


}

