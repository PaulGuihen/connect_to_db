﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ConnectToMvcMusicStore.Models
{
    public class Carts : Controller
    {
      
    
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
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

    

