namespace ShopData.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transactions_View
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public Single? Amount { get; set; }

        public int? ClientId { get; set; }

        public DateTime? Date { get; set; }

        public string ClientName { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
