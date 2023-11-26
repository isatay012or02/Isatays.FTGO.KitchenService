using Microsoft.EntityFrameworkCore;

namespace Isatays.FTGO.KitchenService.Api.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options) { }

	public DbSet<Ticket> Tickets { get; set; }
}
