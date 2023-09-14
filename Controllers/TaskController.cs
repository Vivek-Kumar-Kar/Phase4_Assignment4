using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static List<Task> tasks = new List<Task>
        {
           new Task { Id = 1, Title = "Server Controls", Description = "Write and submit the project servers used in buiding it." },
           new Task { Id = 2, Title = "Important Passwords", Description = "Prepare a pdf or word file for all the passwords needed." },

        };

        [HttpGet]
        public ActionResult<IEnumerable<Task>> Get()
        {
            return tasks;
        }

        [HttpGet("{id}")]
        public ActionResult<Task> Get(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        public void Post([FromBody] Task task)
        {
            task.Id = tasks.Count + 1;
            tasks.Add(task);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Task updatedTask)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            tasks.Remove(task);
            return NoContent();
        }
    }
}
