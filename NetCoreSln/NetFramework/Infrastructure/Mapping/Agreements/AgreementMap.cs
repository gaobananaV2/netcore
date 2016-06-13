using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Domains.Domains.Agreements;

namespace Infrastructure.Mapping.Agreements
{
    public partial class AgreementMap : ObjectEntityTypeConfiguration<Agreement>
    {
        public AgreementMap()
        {
            ToTable("Agreement");
            HasKey(bp => bp.Id);
            Property(bp => bp.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(bp => bp.CategoryCode).HasColumnName("CategoryCode"); 
           
            HasRequired(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryCode);

        }
    }
}
