using System;
using NUnit.Framework;

namespace net.sf.volundr
{
	[TestFixture ()]
	public class StringSplitterTest
	{
		[Test ()]
		public void EmptyNot ()
		{
			string[] result = StringSplitter.From (";").Split (";");
			Assert.AreEqual (2, result.Length); //two empty fields, works differently than in Java
		}

		[Test ()]
		public void NoSeparator ()
		{
			string[] result = StringSplitter.From (";").Split ("");
			Assert.AreEqual (1, result.Length);
			Assert.AreEqual ("", result [0]);
		}

		[Test ()]
		public void Fields ()
		{
			string[] result = StringSplitter.From (";").Split ("1;2");
			Assert.AreEqual (2, result.Length);
			Assert.AreEqual ("1", result [0]);
			Assert.AreEqual ("2", result [1]);
		}

	}

}

