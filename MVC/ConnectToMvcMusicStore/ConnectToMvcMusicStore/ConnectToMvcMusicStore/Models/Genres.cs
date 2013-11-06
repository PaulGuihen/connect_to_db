using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ConnectToMvcMusicStore.Models
{
    public class Genres
    {
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class GenresDBContext : DbContext
    {
        

        static GenresDBContext()
        {
            Database.SetInitializer<Models.GenresDBContext>(null);
        }



        public DbSet<Genres> GenresDbSet { get; set; }
    }
}