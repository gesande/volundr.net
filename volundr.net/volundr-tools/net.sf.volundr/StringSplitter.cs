using System;
using System.Text.RegularExpressions;

namespace net.sf.volundr
{
	public sealed class StringSplitter
	{
		private Regex pattern;

		private StringSplitter (Regex pattern){
			this.pattern = pattern;
		}

		public static StringSplitter From(string pattern){
			return new StringSplitter (new Regex (pattern));
		}

		public static StringSplitter From(Regex pattern){
			return new StringSplitter (pattern);
		}

		public string[] Split (string input)
		{
			return pattern.Split (input);
		}
	}
}

