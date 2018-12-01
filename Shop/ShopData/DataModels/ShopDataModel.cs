namespace ShopData.DataModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopDataModel : DbContext
    {
        public ShopDataModel()
            : base("name=EntityFW")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<Transactions_View> Transactions_View { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
