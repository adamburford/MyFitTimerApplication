using System;
using System.Collections.Generic;
using System.Text;

namespace MyFitTimerData.Models
{
	public class Run
	{
		/// <summary>
		/// Primary Key
		/// </summary>
		/// 
		public Int32 RunId { get; set; }

		/// <summary>
		/// Time Elapsed
		/// </summary>
		/// <remarks>
		/// In Milliseconds
		/// </remarks>
		public TimeSpan Time { get; set; }

		/// <summary>
		/// Creates a new Run time
		/// </summary>
		/// <param name="time">Time elapsed in the run in milliseconds</param>
		public Run(TimeSpan time)
		{
			Time = time;
		}

		public Run(DateTime startTime, DateTime stopTime)
		{
			Time = stopTime - startTime;
		}

	}
}
