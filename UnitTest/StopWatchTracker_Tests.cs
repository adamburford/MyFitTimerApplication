using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFitTimerAPI;
using System;

namespace UnitTest
{
	[TestClass]
	public class StopwatchTracker_Tests
	{
		[TestMethod]
		public void StopwatchTracker_IsRunning()
		{
			StopWatchTracker t = new StopWatchTracker();

			Assert.IsFalse(t.IsRunning);

			t.Start();

			Assert.IsTrue(t.IsRunning);

			t.Stop();

			Assert.IsFalse(t.IsRunning);

		}

		[TestMethod]
		public void StopwatchTracker_Elapsed()
		{
			StopWatchTracker t = new StopWatchTracker();

			Assert.AreEqual(t.Elapsed, TimeSpan.Zero);

			TimeSpan testPeriod = TimeSpan.FromMilliseconds(5000);
			TimeSpan delta = TimeSpan.FromMilliseconds(50);

			t.Start();
			System.Threading.Thread.Sleep(testPeriod);
			Assert.IsTrue(AreEqualTime(testPeriod, t.Elapsed, delta));
		}

		[TestMethod]
		public void StopwatchTracker_ElapsedMilliseconds()
		{
			StopWatchTracker t = new StopWatchTracker();

			Assert.AreEqual(t.ElapsedMilliseconds, 0);

			TimeSpan testPeriod = TimeSpan.FromMilliseconds(5000);
			TimeSpan delta = TimeSpan.FromMilliseconds(50);

			t.Start();
			System.Threading.Thread.Sleep(testPeriod);
			Assert.IsTrue(AreEqualTime(testPeriod, TimeSpan.FromMilliseconds( t.ElapsedMilliseconds), delta));
		}

		[TestMethod]
		public void StopwatchTracker_Start()
		{
			StopWatchTracker t = new StopWatchTracker();

			Assert.IsFalse(t.IsRunning);

			t.Start();

			Assert.IsTrue(t.IsRunning);
			System.Threading.Thread.Sleep(10);
			Assert.IsTrue(t.ElapsedMilliseconds > 0);
		}

		[TestMethod]
		public void StopwatchTracker_Stop()
		{
			StopWatchTracker t = new StopWatchTracker();

			Assert.IsFalse(t.IsRunning);

			t.Start();
			t.Stop();

			Assert.IsFalse(t.IsRunning);
			Assert.AreEqual(t.ElapsedMilliseconds, 0);
		}

		static bool AreEqualTime(TimeSpan expected, TimeSpan actual, TimeSpan maximumDelta)
		{
			return (actual - expected) < maximumDelta;
		}

	}
}
