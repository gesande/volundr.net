using System;
using System.Threading;

namespace net.sf.volundr.concurrent
{
	public sealed class ThreadEngine
	{
		private Thread[] threads;

		public void Run (params ThreadStart[] runnables)
		{
			Validate (runnables);
			if (runnables.Length == 0) {
				//TODO: change this so that its injected (either e.g. log4net / console out version)
				Console.Out.WriteLine ("There was nothing to do, no runnables were given. Exiting"); 
			}
			InitializeWith (runnables);
			StartThreads ();
			JoinThreads ();
			ClearThreads ();
		}

		public void InterruptThreads ()
		{
			foreach (Thread t in this.threads) {
				t.Interrupt ();
			}
		}

		private void Validate (ThreadStart[] runnables)
		{
			if (runnables == null) {
				throw new ArgumentNullException ("runnables");
			}
		}

		private void InitializeWith (ThreadStart[] runnables)
		{
			this.threads = new Thread[runnables.Length];
			for (int i = 0; i < threads.Length; i++) {
				this.threads [i] = new Thread (runnables [i]);
			}
		}

		private void StartThreads ()
		{
			foreach (Thread t in this.threads) {
				t.Start ();
			}
		}

		private void JoinThreads ()
		{
			foreach (Thread t in this.threads) {
				t.Join ();
			}

		}

		private void ClearThreads ()
		{
			this.threads = null;
		}
	}
}

