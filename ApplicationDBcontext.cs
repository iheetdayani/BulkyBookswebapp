using BulkyBooksweb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBooksweb.Data
{
    public class ApplicationDBcontext:DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext>  options) :base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; } 
    }
   
}
