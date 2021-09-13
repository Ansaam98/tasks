using Microsoft.EntityFrameworkCore;
using tasks.Entities;

namespace tasks.Data
{
    public class DataContext :DbContext
    {
     public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }   

        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<UserEntity> Users { get; set; }
    }
}