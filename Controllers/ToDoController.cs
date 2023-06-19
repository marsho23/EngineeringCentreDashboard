using EngineeringCentreDashboard.Filters;
using EngineeringCentreDashboard.Interfaces;
using EngineeringCentreDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;

namespace EngineeringCentreDashboard.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoHelper _helper;
        public ToDoController(IToDoHelper helper)
        {
            _helper = helper;
        }

        [HttpPost]
        [ValidateModelState]
        public IActionResult Add([FromBody] ToDo toDo)
        {
            _helper.Add(toDo);
            return Ok(toDo);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            ToDo toDo = _helper.Get(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return Ok(toDo);
        }



        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<ToDo> toDoList = _helper.GetAll();
            return Ok(toDoList);
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] ToDo toDo)
        {
            if (id != toDo.Id)
            {
                return BadRequest();
            }

            ToDo updatedToDo = _helper.Update(toDo);
            if (updatedToDo == null)
            {
                return NotFound();
            }

            return Ok(updatedToDo);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _helper.Delete(id);
            return Ok(id);
        }
    }
}
