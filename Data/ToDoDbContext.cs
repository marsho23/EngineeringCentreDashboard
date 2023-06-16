using EngineeringCentreDashboard.Interfaces;
using EngineeringCentreDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineeringCentreDashboard.Data
{
    public class ToDoDbContext : DbContext, IToDoDbContext
    {
        public DbSet<ToDo> ToDoItems { get; set; }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options):base(options) { }
       
        public async Task<ToDo> Get(int id)
        {
            return await ToDoItems.FindAsync(id);
        }

        public async Task<ToDo> Add(ToDo toDo)
        {
            await ToDoItems.AddAsync(toDo);
            await SaveChangesAsync();
            return toDo;
        }

        public async Task<IEnumerable<ToDo>> GetAll()
        {
            return await ToDoItems.ToListAsync();
        }

        public async Task<ToDo> Update(ToDo toDo)
        {
            ToDoItems.Update(toDo);
            await SaveChangesAsync();
            return toDo;
        }

        public async Task Delete(int id)
        {
            var toDo = await ToDoItems.FindAsync(id);
            if (toDo != null)
            {
                ToDoItems.Remove(toDo);
                await SaveChangesAsync();
            }
        }
    }
}
