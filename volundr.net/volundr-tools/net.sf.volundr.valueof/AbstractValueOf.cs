using System;

namespace  net.sf.volundr.valueof
{
	public abstract class AbstractValueOf<TYPE> : ValueOf<TYPE>
	{
		private TYPE fieldValue;

		protected AbstractValueOf (TYPE value)
		{
			this.fieldValue = value;
		}

		public TYPE value() {
			return this.fieldValue;
		}

	}
}

