using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace net.sf.volundr.io
{
	[TestFixture ()]
	public class LineReaderTest
	{
		static MemoryStream NewStream ()
		{
			MemoryStream stream = new MemoryStream ();
			StreamWriter writer = new StreamWriter (stream, Encoding.UTF8);

			writer.Write ("line1");
			writer.WriteLine ();
			writer.Write ("line2");
			writer.WriteLine ();

			writer.Flush ();
			stream.Position = 0;

			return stream;
		}

		[Test ()]
		public void Read ()
		{
			Stream stream = NewStream ();
			List<String> lines = new List<String> ();
			VisitingLines visitor = new VisitingLines (lines);
			new LineReader (Encoding.UTF8).Read (stream, visitor);
			Assert.IsFalse (visitor.EmptyLinesDetected ());
			Assert.AreEqual (2, visitor.Lines.Count);
			Assert.IsTrue (visitor.Lines.Contains ("line1"));
			Assert.IsTrue (visitor.Lines.Contains ("line2"));
		}

		[Test ()]
		public void ReadEmptyLines ()
		{
			MemoryStream stream = new MemoryStream ();
			StreamWriter writer = new StreamWriter (stream, Encoding.UTF8);

			writer.Write ("line1");
			writer.WriteLine ();
			writer.WriteLine ();
			writer.Write ("line2");
			writer.WriteLine ();
			writer.Flush ();
			stream.Position = 0;

			List<String> lines = new List<String> ();
			VisitingLines visitor = new VisitingLines (lines);
			new LineReader (Encoding.UTF8).Read (stream, visitor);
			
			Assert.IsTrue (visitor.EmptyLinesDetected ());
			Assert.AreEqual (2, visitor.Lines.Count);
			Assert.IsTrue (visitor.Lines.Contains ("line1"));
			Assert.IsTrue (visitor.Lines.Contains ("line2"));
			Assert.AreEqual (1, visitor.EmptyLines.Count);
		}

		class VisitingLines : LineVisitor
		{
			private List<string> lines;
			private List<string> emptyLines = new List<String> ();

			public VisitingLines (List<string> lines)
			{
				this.lines = lines;
				this.emptyLines = new List<String> ();
			}

			public void Visit (String line)
			{
				lines.Add (line);
			}

			public List<String> Lines {
				get{ return lines; }
			}

			public void EmptyLine ()
			{
				emptyLines.Add ("");
			}

			public Boolean EmptyLinesDetected ()
			{
				return emptyLines.Count > 0;
			}

			public List<String> EmptyLines {
				get { return  this.emptyLines; }
			}

		}
	}
}

