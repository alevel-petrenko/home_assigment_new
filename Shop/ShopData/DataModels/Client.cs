namespace ShopData.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool? IsDeleted { get; set; }

        public int? CategoryId { get; set; }

        public virtual UserCategory UserCategory { get; set; }
    }
}
