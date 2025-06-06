using EventService.Models;

namespace EventService.Services
{
    public class EventManagerService
    {
        private readonly List<Event> _events = new();
        private int _nextId = 1;

        public List<Event> GetAll() => _events;

        public Event? GetById(int id) => _events.FirstOrDefault(e => e.Id == id);

        public Event Add(Event newEvent)
        {
            newEvent.Id = _nextId++;
            _events.Add(newEvent);
            return newEvent;
        }

        public bool Delete(int id)
        {
            var existing = _events.FirstOrDefault(e => e.Id == id);
            if (existing == null) return false;

            _events.Remove(existing);
            return true;
        }

        public bool Update(int id, Event updated)
        {
            var existing = _events.FirstOrDefault(e => e.Id == id);
            if (existing == null) return false;

            existing.Title = updated.Title;
            existing.Description = updated.Description;
            existing.Date = updated.Date;
            existing.Location = updated.Location;

            return true;
        }
    }
}
