using Microsoft.EntityFrameworkCore;
using BizzSecureDemo_22180016.Models;
namespace BizzSecureDemo_22180016.Data;
public class AppDbContext : DbContext
{
    public DbSet<AppUser> Users => Set<AppUser>();
    public DbSet<Order> Orders => Set<Order>();
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}