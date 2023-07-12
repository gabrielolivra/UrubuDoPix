using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrubuDoPix.Models;

namespace UrubuDoPix.Data.Map
{
    public class PixMap : IEntityTypeConfiguration<PixModel>

    {
        public void Configure(EntityTypeBuilder<PixModel> builder)
        {
            builder.HasKey("Id");
            builder.Property(x => x.Investimento).IsRequired().HasMaxLength(5);
            builder.Property(x => x.Retorno).IsRequired().HasMaxLength(10);
        }
    }
}
