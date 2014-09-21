using System;
using System.Text;
using NUnit.Framework;

namespace net.sf.volundr.asexpected
{
	/// <summary>
	/// Original idea for this was got from Ville Oikarinen.
	/// </summary>
	public abstract class AbstractExpected<PARENT> : Expected<PARENT>
	{
		private StringBuilder expected = new StringBuilder ();

		protected abstract PARENT Parent ();

		protected abstract String Actual ();

		public Expected<PARENT> String (string str)
		{
			Expected ().Append (str);
			return this;
		}

		public Expected<PARENT> Line (string line)
		{
			return String (line).String ("\n");
		}

		public PARENT End ()
		{
			string buildExpected = this.expected.ToString ();
			string actual = Actual ();
			if (!buildExpected.Equals (actual)) {
				Console.Error.WriteLine ("If the actual output is what you want, copy-paste this to the test:\n"
				+ ToTestExpectationCode (actual));
			}
			Assert.AreEqual (buildExpected, actual);
			return Parent ();
		}

		private static String ToTestExpectationCode (string s)
		{
			return s.Replace ("\"", "\\\\\"")
				.Replace ("(.*)\n", "expected.line(\"$1\");\n")
				.Replace (".line\\(\"\"\\)\n", "")
			+ "expected.end();\n";
		}


		private StringBuilder Expected ()
		{
			return this.expected;
		}
	}
}

