﻿using LaptopShop_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaptopShop_API.Configurations
{
    public class RamConfigurations : IEntityTypeConfiguration<Ram>
    {
        public void Configure(EntityTypeBuilder<Ram> builder)
        {
            builder.ToTable("RAM");
            builder.HasKey(p => p.Id);
            builder.Property(a => a.Ma).IsRequired();
            builder.Property(a => a.ThongSo).HasColumnName("ThongSo").HasColumnType("varchar(70)").IsRequired();
        }
    }
}
