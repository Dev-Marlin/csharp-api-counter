using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public interface IRepository
    {
        public Counter GetCounter(int id);

        public Counter AddCounter(Counter counter);

        public Counter IncrementCounter(int id);

        public Counter DecrementCounter(int id);
    }
}
