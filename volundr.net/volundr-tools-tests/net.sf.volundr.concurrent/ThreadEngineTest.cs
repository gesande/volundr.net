using NUnit.Framework;
using System;
using System.Threading;

namespace net.sf.volundr.concurrent
{
	[TestFixture ()]
	public class ThreadEngineTest
	{
		[Test ()]
		public void Run ()
		{
			var start1 = new ThreadStart (Executable.Execute1);
			var start2 = new ThreadStart (Executable.Execute2);
			new ThreadEngine ().Run (start1, start2);
			Assert.AreEqual(2, Executable.executed);
		}

		class Executable
		{
			public static int executed;

			public static void Execute1 ()
			{
				executed++;
			}

			public static void Execute2 ()
			{
				executed++;
			}
		}
	}
}