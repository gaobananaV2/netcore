using Domains.Domains.Users;
namespace Infrastructure.Mapping.Users
{
    public class GroupMap : ObjectEntityTypeConfiguration<Group>
    {
        public GroupMap()
        {
            ToTable("Group");
            HasKey(bp => bp.Code);
            Property(bp => bp.Code).HasColumnName("GroupId");
            Property(bp => bp.Name).HasColumnName("Name"); 
            Ignore(bp => bp.Id);
        }
    }
}