using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ConnectToMvcMusicStore.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
    public class OrderDetailsDBContext : DbContext
    {


        static OrderDetailsDBContext()
        {
            Database.SetInitializer<Models.OrderDetailsDBContext>(null);
        }



        public DbSet<OrderDetails> OrderDetailsDbSet { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}