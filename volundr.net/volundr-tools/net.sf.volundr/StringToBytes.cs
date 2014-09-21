﻿using System;

namespace net.sf.volundr
{
	public sealed class StringToBytes
	{
		public static byte[] ToBytes (string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy (str.ToCharArray (), 0, bytes, 0, bytes.Length);
			return bytes;
		}
	}
}
