using Accounting.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {

        public void Configure(EntityTypeBuilder<Account> builder)
        {

            builder.ToTable("Account");

            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.AccountingAccount)
                .WithMany(aa => aa.Accounts)
                .HasForeignKey(a => a.IdAccountingAccount);


            builder.HasOne(a => a.AccountingEntry)
                .WithMany(aa => aa.Accounts)
                .HasForeignKey(a => a.IdAccountingEntry);
        }
    }
}
