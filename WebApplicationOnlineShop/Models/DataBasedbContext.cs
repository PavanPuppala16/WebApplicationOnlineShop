using Microsoft.EntityFrameworkCore;

namespace WebApplicationOnlineShop.Models
{
    public class DataBasedbContext:DbContext
    {
        public DataBasedbContext()
        {

        }
        public DataBasedbContext(DbContextOptions<DataBasedbContext> options) : base(options)
        {

        }

        //public virtual DbSet<PRODUCT> PRODUCT { get; set; }

    }
}
