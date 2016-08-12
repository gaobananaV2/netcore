namespace Data.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFContext : DbContext
    {
        public EFContext()
            : base("name=EFModel")
        {
            Database.SetInitializer<EFContext>(null);
        }

        public DbSet<WeiBo> WeiBos{ get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeiBo>().ToTable("WeiBo");
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<WeiBo>()
            //    .HasKey(k => k.WeiBoId) //��������
            //    .Property(q => q.Content).IsRequired();//���ò���Ϊ��
        }
    }


    public class WeiBo :BaseModel
    {
        public int WeiBoId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
