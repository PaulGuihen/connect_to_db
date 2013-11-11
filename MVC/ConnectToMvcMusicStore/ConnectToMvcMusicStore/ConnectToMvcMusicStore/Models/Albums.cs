using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ConnectToMvcMusicStore.Models
{
    public class Albums
    {
         [Key]
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title{ get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
       
    }

    

    public class AlbumsDBContext : DbContext
    {
       /* protected override void OnModelCreating(Artists artists)
        {
            artists.IncludeMetadataInDatabase = false;
        }*/

        static AlbumsDBContext()
        {
            Database.SetInitializer<Models.AlbumsDBContext>(null);
        }

       // Database.SetInitializer<Models.YourDbContext>(null);

       // System.Data.Entity.Database.SetInitializer<MvcMusicStoreDBContext>(null); 

        public DbSet<Albums> AlbumsDbSet { get; set; }
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
    
