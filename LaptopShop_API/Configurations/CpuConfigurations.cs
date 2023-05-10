﻿using LaptopShop_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaptopShop_API.Configurations
{
    public class CpuConfigurations : IEntityTypeConfiguration<Cpu>
    {
        public void Configure(EntityTypeBuilder<Cpu> builder)
        {
            builder.ToTable("CPU");
            builder.HasKey(p => p.Id);
            builder.Property(a => a.Ma).IsRequired();
            builder.Property(a => a.Name).HasColumnName("Name").HasColumnType("varchar(70)").IsRequired();
        }
    }
}
