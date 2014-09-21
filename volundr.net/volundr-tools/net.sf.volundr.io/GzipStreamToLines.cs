using System;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace net.sf.volundr.io
{
	public class GZipStreamToLines
	{

		private StreamToLines reader;

		public GZipStreamToLines (LineVisitor visitor, Encoding encoding)
		{
			this.reader = new StreamToLines (visitor, encoding);
		}

		public void ReadFrom (Stream compressed)
		{
			Console.WriteLine ("compressed: can read " + compressed.CanRead);
			Console.WriteLine ("compressed: can seek " + compressed.CanSeek);
			Console.WriteLine ("compressed: can write " + compressed.CanWrite);
			MemoryStream decompressed = new MemoryStream ();
		var stream = new DeflateStream (compressed, CompressionMode.Decompress);
			Console.WriteLine ("GZipStream: can read " + stream.CanRead);
			Console.WriteLine ("GZipStream: can seek " + stream.CanSeek);
			Console.WriteLine ("GZipStream: can write " + stream.CanWrite);

			Console.WriteLine ("decompressed: can read " + decompressed.CanRead);
			Console.WriteLine ("decompressed: can seek " + decompressed.CanSeek);
			Console.WriteLine ("decompressed: can write " + decompressed.CanWrite);
			stream.CopyTo (decompressed);

			decompressed.Position = 0;
			reader.ReadFrom (decompressed);
		}
	}
}

