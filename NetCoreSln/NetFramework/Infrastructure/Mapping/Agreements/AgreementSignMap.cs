using Domains.Domains.Agreements;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Mapping.Agreements
{
    public class AgreementSignMap : ObjectEntityTypeConfiguration<AgreementSign>
    {
        public AgreementSignMap()
        {
            ToTable("AgreementSign");
            HasKey(bp => bp.Id);
            Property(bp => bp.Id).HasColumnName("SignID")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(bp => bp.AgreeMentId).HasColumnName("AgreeMentID");
            Property(bp => bp.StfId).HasColumnName("StfID");

            HasRequired(p => p.Agreement)
                .WithMany()
                .HasForeignKey(p => p.AgreeMentId); 
        }
    }
}
