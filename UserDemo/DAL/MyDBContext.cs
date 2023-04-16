using Microsoft.EntityFrameworkCore;

namespace UserDemo.DAL
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) :base(options){
          
        }    

        public DbSet<UserDTO> UserDTO { get; set; }
    }
}
