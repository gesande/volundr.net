using NUnit.Framework;
using System;
using  net.sf.volundr.valueof;

namespace net.sf.volundr.valueof
{
	[TestFixture ()]
	public class ValueOfFactoryTest
	{
		[Test ()]
		public void StringValue ()
		{
			ValueOf<String> some = ValueOfFactory.valueOfString("value");
			Assert.IsNotNull(some);
			Assert.IsNotNull (some.value() );
			Assert.AreEqual ("value", some.value() );
		}
		[Test ()]
		public void NullStringValue ()
		{
			ValueOf<String> some = ValueOfFactory.valueOfString(null);
			Assert.IsNotNull(some);
			Assert.IsNull(some.value() );
		}
	}
}

