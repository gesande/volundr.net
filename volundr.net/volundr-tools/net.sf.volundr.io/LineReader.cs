using System;
using System.IO;
using System.Text;

namespace net.sf.volundr.io
{
	public sealed class LineReader
	{
		private Encoding encoding;

		public LineReader (Encoding encoding)
		{
			this.encoding = encoding;
		}

		public void Read (Stream stream, LineVisitor visitor)
		{
			using (BufferedStream buffered = new BufferedStream (stream)) {
				using (StreamReader reader = new StreamReader (buffered, encoding)) {
					string line;
					while ((line = reader.ReadLine ()) != null) {
						if (line.Length > 0) {
							visitor.Visit (line);
						} else {
							visitor.EmptyLine ();
						}
					}
				}
			}
		}
	}
}

