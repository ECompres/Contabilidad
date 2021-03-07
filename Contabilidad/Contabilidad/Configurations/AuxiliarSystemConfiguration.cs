using Contabilidad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contabilidad.Configurations
{
    public class AuxiliarSystemConfiguration : IEntityTypeConfiguration<AuxiliarSystem>
    {
        public void Configure(EntityTypeBuilder<AuxiliarSystem> builder)
        {

            builder.ToTable("AuxiliarSystem");
            
            builder.HasKey(a => a.ID);

            builder.HasMany(a => a.AccountingEntry)
                   .WithOne(b => b.AuxiliarSystem)
                   .HasForeignKey(fk => fk.IdAuxiliarSystem);
        }
    }
}
