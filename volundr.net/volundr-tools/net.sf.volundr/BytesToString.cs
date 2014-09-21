using System;
using System.Text;

namespace net.sf.volundr
{
	public sealed class BytesToString
	{
		public static string Convert (byte[] bytes)
		{
			char[] chars = new char[bytes.Length / sizeof(char)];
			System.Buffer.BlockCopy (bytes, 0, chars, 0, bytes.Length);
			return new string (chars);
		}
	}

}

