using Microsoft.EntityFrameworkCore;
using UrubuDoPix.Data.Map;
using UrubuDoPix.Models;

namespace UrubuDoPix.Data
{
    public class UrubuDoPixDBContext : DbContext
    {
        public UrubuDoPixDBContext(DbContextOptions<UrubuDoPixDBContext> options) :base(options) { 
                       
        
        }   
        public DbSet<PixModel> Pix { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PixMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
