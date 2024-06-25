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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {

        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.HasData(
                new Detail() { Id=1,Title = "Material", Description = "Cotton",  CategoryId=4 },
                new Detail() { Id = 2, Title = "Ram", Description = "8gb", CategoryId=2 },
                new Detail() { Id = 3, Title = "Uzunluq", Description = "125sm",  CategoryId = 6 },
                new Detail() { Id = 4, Title = "Cekilis", Description = "50px",  CategoryId = 3}
                );
        }
    }
}
