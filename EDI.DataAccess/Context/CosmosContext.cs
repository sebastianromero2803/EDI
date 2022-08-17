
using EDI.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace EDI.DataAccess.Context
{
    public class CosmosContext : DbContext
    {

        public CosmosContext(DbContextOptions<CosmosContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseCosmos(
                "https://advent-final.documents.azure.com:443/",
                "lLsQ9bUFgvY6bb015YWKDHTLYYxsZZkw0PKDrYOeEAnFJ7Fp1mYl3NUrssQZayRkHx9YxRbEysDrkp1PRzVYxw==",
                "advent-final"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemContainer>()
                .ToContainer("Containers")
                .HasOne(item => item.ContainerId);
        }
    }
}
