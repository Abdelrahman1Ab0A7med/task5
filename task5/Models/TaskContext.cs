using Microsoft.EntityFrameworkCore;

namespace task5.Models
{
	public class TaskContext : DbContext
	{
		public DbSet<Course> courses { get; set; }
		public DbSet<User> users { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
		=> optionsBuilder.UseSqlServer("Data Source =ABDOLABTOP;Initial Catalog =MVCTask5 ;Integrated Security = True ;TrustServerCertificate=True; ");
	}
}
