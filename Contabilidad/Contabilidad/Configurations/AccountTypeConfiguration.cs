using Contabilidad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contabilidad.Configurations
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.ToTable("AccountType");

            builder.HasKey(a => a.ID);

            builder.HasMany(a => a.AccountingAccounts)
                   .WithOne(b => b.AccountType)
                   .HasForeignKey(fk => fk.IdAccountType);
        }
    }
}
