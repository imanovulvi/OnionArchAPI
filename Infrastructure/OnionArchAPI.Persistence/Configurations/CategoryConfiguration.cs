using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchAPI.Domen.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchAPI.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category() { Id = 1, Name = "Electronika", ParentId = 0, Priorty = 1 },
                new Category() { Id = 2, Name = "Notebook", ParentId = 1, Priorty = 1 },
                new Category() { Id = 3, Name = "Phone", ParentId = 1, Priorty = 2 },
                new Category() { Id = 4, Name = "Geyim", ParentId = 0, Priorty = 3 },
                new Category() { Id = 5, Name = "Tshort", ParentId = 4, Priorty = 1 },
                new Category() { Id = 6, Name = "Cins", ParentId = 4, Priorty = 2 }
                );
        }
    }
}
