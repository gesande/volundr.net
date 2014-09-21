using System;
using System.Text;
using System.IO;

namespace net.sf.volundr.io
{
	public sealed class StreamToLines
	{
		private LineVisitor visitor;
		private LineReader lineReader;

		public StreamToLines (LineVisitor visitor, Encoding encoding)
		{
			this.visitor = visitor;
			this.lineReader = new LineReader (encoding);
		}

		public void ReadFrom (Stream stream)
		{
			this.lineReader.Read (stream, visitor);
		}

	}
}

