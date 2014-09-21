using System;
using System.Threading;

namespace net.sf.volundr.concurrent
{
	public sealed class ThreadEngineApi<ThreadStart>
	{
		private ThreadEngine engine;
		private System.Threading.ThreadStart[] runnables;

		public ThreadEngineApi ()
		{
			this.engine = new ThreadEngine ();
		}

		public ThreadEngineApi<ThreadStart> Runnables (params System.Threading.ThreadStart[] runnables)
		{
			this.runnables = runnables;
			return this;
		}

		public void Run ()
		{
			this.engine.Run (this.runnables);
		}

		public void Interrupt ()
		{
			this.engine.InterruptThreads ();
		}
	}
}

