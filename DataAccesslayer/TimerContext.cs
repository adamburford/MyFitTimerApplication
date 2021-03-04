using Microsoft.EntityFrameworkCore;
using MyFitTimerData.Models;

namespace MyFitTimerData
{
	public class TimerContext : DbContext
	{
		public DbSet<Run> Runs { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Data Source=runs.db");
			base.OnConfiguring(optionsBuilder);
		}
	}
}
