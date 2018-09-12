using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class DBInitializer :DropCreateDatabaseAlways<PhoneContext>
    {
        protected override void Seed(PhoneContext context)
        {
            context.Phones.Add(new Phone() { Name = "Mi", Price = 7000, Producer = "China" });
            context.Phones.Add(new Phone() { Name = "Nokia", Price = 6000, Producer = "China" });
            context.Phones.Add(new Phone() { Name = "Samsung", Price = 10000, Producer = "Korea" });

            base.Seed(context);
        }
    }
}