using System;
using System.IO;
using System.Text;

namespace net.sf.volundr.io
{
	public sealed class StringToMemoryStream : StringToStream
	{
		private Encoding encoding;

		public StringToMemoryStream (Encoding encoding)
		{
			this.encoding = encoding;
		}

		public Stream FromString (string value)
		{
			return StringToMemoryStreamBuilder.Builder (encoding).WriteLine (value).Done();
		}

	}

}

