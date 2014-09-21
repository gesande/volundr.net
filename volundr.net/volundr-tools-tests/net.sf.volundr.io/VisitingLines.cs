using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace net.sf.volundr.io
{
	public sealed class VisitingLines : LineVisitor
	{
		private int emptyLines = 0;
		private List<String> lines = new List<String> ();

		public void Visit (string line)
		{
			lines.Add (line);
		}

		public void EmptyLine ()
		{
			emptyLines++;
		}

		public VisitingLines NoEmptyLines ()
		{
			Assert.AreEqual (0, emptyLines);
			return this;
		}

		public VisitingLines Lines (int lines)
		{
			Assert.AreEqual (lines, this.lines.Count);
			return this;
		}

		public VisitingLines Line (int index, string expected)
		{
			Assert.AreEqual (expected, lines [index]);
			return this;
		}
	}
}

