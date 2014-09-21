using System;

namespace net.sf.volundr.valueof
{
	public sealed class ValueOfFactory
	{
		private ValueOfFactory ()
		{
		}

		public static ValueOf<String> valueOfString(String value){
			return new StringValueOf(value);
		}
	}
}

