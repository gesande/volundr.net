using System;

namespace net.sf.volundr.asexpected
{
	public sealed class AsExpected<PARENT> : AbstractExpected<PARENT>
	{
		private  string actual;
		private  PARENT parent;

		public AsExpected (string actual, PARENT parent)
		{
			this.actual = actual;
			this.parent = parent;
		}

		protected override PARENT Parent ()
		{
			return this.parent;
		}

		protected override String Actual ()
		{
			return this.actual;
		}
	}
}

