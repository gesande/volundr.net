using System;
using System.IO;
using System.Text;

namespace net.sf.volundr.io
{
	public sealed class StringToMemoryStreamBuilder
	{
		private Stream stream;
		private StreamWriter writer;

		private StringToMemoryStreamBuilder (Stream stream, StreamWriter writer)
		{
			this.stream = stream;
			this.writer = writer;
		}

		public static StringToMemoryStreamBuilder Builder(Encoding encoding){
			MemoryStream stream = new MemoryStream ();
			return new StringToMemoryStreamBuilder (stream, new StreamWriter (stream, encoding));
		}

		public StringToMemoryStreamBuilder WriteLine(string line){
			writer.WriteLine(line);
			return this;
		}

		public StringToMemoryStreamBuilder Write(string line){
			writer.Write(line);
			return this;
		}

		public Stream Done(){
			writer.Flush ();
			stream.Position = 0;
			return stream;
		}
	}
}

