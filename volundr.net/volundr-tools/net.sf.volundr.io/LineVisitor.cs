using System;

namespace net.sf.volundr.io
{
	public interface LineVisitor
	{
		void Visit(string line);

		void EmptyLine();
	}
}

