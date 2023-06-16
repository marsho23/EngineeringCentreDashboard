using EngineeringCentreDashboard.Models;

namespace EngineeringCentreDashboard.Interfaces
{
    public interface IToDoDbContext
    {
        Task<ToDo> Get(int id);
        Task<ToDo> Add(ToDo toDo);
        Task<IEnumerable<ToDo>> GetAll();
        Task<ToDo> Update(ToDo toDo);
        Task Delete(int id);
    }
}
