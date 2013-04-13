using System.Data.Entity;
using MiHs.DAL.DomainObjects;

namespace MiHs.DAL
{
    public class MihDbContext : DbContext
    {
        public DbSet<YoutubeVideo> YoutubeVideos { get; set; }
    }
}