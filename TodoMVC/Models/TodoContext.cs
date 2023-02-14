using Microsoft.EntityFrameworkCore;

namespace TodoMVC.Models
{
    public class TodoContext :DbContext
    {
        public TodoContext(DbContextOptions<TodoContext>options):base(options)
        {

        }
        public DbSet<TodoModal> task_status { get; set; }
    }
}
