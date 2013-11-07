using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ConnectToMvcMusicStore.Models
{
    public class Carts
    {
      
    
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class CartsDBContext : DbContext
    {
        

        static CartsDBContext()
        {
            Database.SetInitializer<Models.CartsDBContext>(null);
        }



        public DbSet<Carts> CartsDbSet { get; set; }
    }
}

    

