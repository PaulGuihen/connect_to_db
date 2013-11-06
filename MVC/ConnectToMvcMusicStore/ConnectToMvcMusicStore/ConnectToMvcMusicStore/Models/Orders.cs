using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ConnectToMvcMusicStore.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Username { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
    }

    

    public class OrdersDBContext : DbContext
    {
       /* protected override void OnModelCreating(Artists artists)
        {
            artists.IncludeMetadataInDatabase = false;
        }*/

        static OrdersDBContext()
        {
            Database.SetInitializer<Models.OrdersDBContext>(null);
        }

       // Database.SetInitializer<Models.YourDbContext>(null);

       // System.Data.Entity.Database.SetInitializer<MvcMusicStoreDBContext>(null); 

        public DbSet<Orders> OrdersDbSet { get; set; }
    }
}

/*
 
 
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ConnectToMvcMusicStore.Models
{
    public class ArtistsModels
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
    }   

    public class MvcMusicStoreDBContext  : DbContext
    {
        public DbSet<ArtistsModels> Artists { get; set; }
    }
}*/
