using EngineeringCentreDashboard.Models;

namespace EngineeringCentreDashboard.Interfaces
{
    public interface IToDoHelper
    {
        ToDo Get(int id);
        ToDo Add(ToDo toDo);
        IEnumerable<ToDo> GetAll();
        ToDo Update(ToDo toDo);
        int Delete(int id);
    }
}
