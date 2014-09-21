using System;
using System.IO;
using System.Text;

namespace net.sf.volundr.io
{
	public interface StringToStream
	{
		Stream FromString(string value);
	}


}

