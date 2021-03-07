using Contabilidad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contabilidad.Configurations
{
    public class AccountingAccountsConfiguration : IEntityTypeConfiguration<AccountingAccounts>
    {
        public void Configure(EntityTypeBuilder<AccountingAccounts> builder) 
        {
            builder.ToTable("AccountingAccounts");
            
            builder.HasKey(a => a.ID);
        }
    }
}
