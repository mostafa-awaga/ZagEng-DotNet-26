using Microsoft.EntityFrameworkCore;
using TaskZagEng.Models;

namespace TaskZagEng.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
		public DbSet<JobListing> Jobs { get; set; }
	}
}
