using backEnd.src.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace backEnd.src.Model.Context;

public class PostgreContext : DbContext {
  public PostgreContext() { }
  public PostgreContext(DbContextOptions<PostgreContext> options) : base(options) {
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); //!para permitir usar data 'local'
  }

  public DbSet<ToDoUser> Users { get; set; }
  public DbSet<ToDoList> Lists { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<ToDoList>().Property("UserId").IsRequired();
    modelBuilder.Entity<ToDoList>().Property("UserId").HasColumnName("user_id");
  }
}