using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace net.sf.volundr.io
{
	[TestFixture ()]
	public class StringToMemoryStreamTest
	{
		[Test ()]
		public void FromString ()
		{
			VisitingStreamLines visitor = NewVisitingStreamLines ();
			new LineReader (Encoding.UTF8).Read (new StringToMemoryStream (Encoding.UTF8).FromString ("to bytes"), visitor);
			visitor.NoEmptyLines ().GotJustOneLine("to bytes");
		}

		VisitingStreamLines NewVisitingStreamLines ()
		{
			return new VisitingStreamLines ();
		}

		class VisitingStreamLines : LineVisitor {
			private bool noEmptyLines=false;
			private int lines =0;
			private string line=null;

			public void Visit(string line){
				this.line = line;
				lines++;
			}

			public void EmptyLine() {
				this.noEmptyLines = true;
			}

			public VisitingStreamLines NoEmptyLines ()
			{
				Assert.IsFalse (noEmptyLines);
				return this;
			}

			public VisitingStreamLines GotJustOneLine (string expected)
			{
				Assert.AreEqual (1, lines);
				Assert.IsNotNull (line);
				Assert.AreEqual (expected, line);
				return this;
			}
		}
	}
}
 
