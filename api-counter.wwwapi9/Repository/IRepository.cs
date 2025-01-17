using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public interface IRepository
    {
        public IEnumerable<Counter> Counters();
        public Counter GetCounterById(int id);

        public Counter AddCounter(Counter counter);

        public Counter IncrementCounter(int id);

        public Counter DecrementCounter(int id);

        public IEnumerable<Counter> GreaterThan(int number);

        public IEnumerable<Counter> LessThan(int number);
    }
}
