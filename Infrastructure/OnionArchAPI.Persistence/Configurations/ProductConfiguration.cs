﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchAPI.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product {Id=1, BrandId = 1, Title = "Kofta", Description = "test", Price = 34 },
                 new Product { Id = 2, BrandId = 3, Title = "Iphone", Description = "test", Price = 158 },
                  new Product { Id = 3, BrandId = 2, Title = "Notebook", Description = "test", Price = 346 },
                   new Product { Id =4, BrandId = 1, Title = "salvar", Description = "test", Price = 12 }
                );
        }
    }
}
