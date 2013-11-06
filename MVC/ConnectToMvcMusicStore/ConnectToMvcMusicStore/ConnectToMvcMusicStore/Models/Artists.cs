using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


using System.Text;




namespace ConnectToMvcMusicStore.Models
{
   

    public class Artists
    {
        [Key]
        public int ArtistId { get; set; }
        public string Name { get; set; }
    }

    

    public class MvcMusicStoreDBContext : DbContext
    {
       /* protected override void OnModelCreating(Artists artists)
        {
            artists.IncludeMetadataInDatabase = false;
        }*/

        static MvcMusicStoreDBContext()
        {
            Database.SetInitializer<Models.MvcMusicStoreDBContext>(null);
        }

       // Database.SetInitializer<Models.YourDbContext>(null);

       // System.Data.Entity.Database.SetInitializer<MvcMusicStoreDBContext>(null); 

        public DbSet<Artists> ArtistsDbSet { get; set; }
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