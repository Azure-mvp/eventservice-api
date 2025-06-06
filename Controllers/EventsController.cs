using Microsoft.AspNetCore.Mvc;
using EventService.Models;
using EventService.Services;

namespace EventService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventManagerService _eventService;

        public EventsController(EventManagerService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetAll()
        {
            return Ok(_eventService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Event> GetById(int id)
        {
            var ev = _eventService.GetById(id);
            if (ev == null) return NotFound();
            return Ok(ev);
        }

        [HttpPost]
        public ActionResult<Event> Add(Event newEvent)
        {
            var created = _eventService.Add(newEvent);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _eventService.Delete(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
