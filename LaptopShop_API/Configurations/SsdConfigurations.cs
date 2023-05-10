using LaptopShop_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaptopShop_API.Configurations
{
    public class SsdConfigurations : IEntityTypeConfiguration<Ssd>
    {
        public void Configure(EntityTypeBuilder<Ssd> builder)
        {
            builder.ToTable("SSD");
            builder.HasKey(p => p.Id);
            builder.Property(a => a.Ma).IsRequired();
            builder.Property(a => a.ThongSo).HasColumnName("ThongSo").HasColumnType("varchar(70)").IsRequired();

        }
    }
}
