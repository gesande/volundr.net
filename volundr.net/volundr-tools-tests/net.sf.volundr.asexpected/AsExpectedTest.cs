using NUnit.Framework;
using System;

namespace net.sf.volundr.asexpected
{
	[TestFixture ()]
	public class AsExpectedTest
	{
		[Test ()]
		public void Expected ()
		{
			AsExpected<AsExpectedTest> expected = new AsExpected<AsExpectedTest> ("actual", this);
			var end = expected.String ("actual").End ();
			Assert.AreEqual (this, end);
		}

		[Test ()]
		public void LineExpected ()
		{
			AsExpected<AsExpectedTest> expected = new AsExpected<AsExpectedTest> ("actual\n", this);
			var end = expected.Line ("actual").End ();
			Assert.AreEqual (this, end);
		}

		[Test (), ExpectedException(typeof(AssertionException))]
		public void NotExpected ()
		{
			//bool failed = false;
			AsExpected<AsExpectedTest> expected = new AsExpected<AsExpectedTest> ("actual\n", this);
			expected.Line ("not actual").End ();
			//TODO: should be like this:
			/*
			try {
			} catch (Exception ex) {
				Console.Error.WriteLine (ex.GetType ());
				Assert.AreEqual ("expected:<[not ]actual\\n\" + \"> but was:<[]actual\\n" + ">", ex.Message);
				failed = true;
			}
			Assert.IsTrue (failed);
			*/
		}

	}
}

