using EngineeringCentreDashboard.Interfaces;
using EngineeringCentreDashboard.Models;

namespace EngineeringCentreDashboard.Business
{
    public class ToDoHelper : IToDoHelper
    {
        private readonly IToDoDbContext _toDoDbContext;
        public ToDoHelper(IToDoDbContext toDoDbContext)
        {
             _toDoDbContext = toDoDbContext;
        }

        public ToDo Add(ToDo toDo)
        {
            _toDoDbContext.Add(toDo);
            return toDo;
        }

        public ToDo Get(int id)
        {
            ToDo toDo = _toDoDbContext.Get(id).Result;
            return toDo;
        }
        public IEnumerable<ToDo> GetAll()
        {
            return _toDoDbContext.GetAll().Result;
        }

        public ToDo Update(ToDo toDo)
        {
            _toDoDbContext.Update(toDo);
            return toDo;
        }

        public int Delete(int id)
        {
            _toDoDbContext.Delete(id);
            return id;
        }
    }
}
