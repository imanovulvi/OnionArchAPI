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
                new Detail() { Title = "Material", Description = "Cotton",  CategoryId=4 },
                new Detail() { Title = "Ram", Description = "8gb", CategoryId=2 },
                new Detail() { Title = "Uzunluq", Description = "125sm",  CategoryId = 6 },
                new Detail() { Title = "Cekilis", Description = "50px",  CategoryId = 3}
                );
        }
    }
}
