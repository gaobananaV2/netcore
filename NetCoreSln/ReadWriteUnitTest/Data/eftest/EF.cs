namespace ReadWriteUnitTest.Data.eftest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EF : DbContext
    {
        public EF()
            : base("name=EF")
        {
        }

        public DbSet<WeiBo> WeiBos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }


    public class WeiBo
    {
        public int WeiBoId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
