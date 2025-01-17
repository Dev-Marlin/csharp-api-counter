using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;

namespace api_counter.wwwapi9.Repository
{
    public class Repository : IRepository
    {
        public Counter AddCounter(Counter counter)
        {
            CounterHelper.Counters.Add(counter);

            return counter;
        }

        public Counter DecrementCounter(int id)
        {
            Counter c = CounterHelper.Counters.Find(x => x.Id == id);
            c.Value--;
            return c;
        }

        public Counter GetCounter(int id)
        {
            Counter c = CounterHelper.Counters.Find(x => x.Id == id);
            return c;
        }

        public Counter IncrementCounter(int id)
        {
            Counter c = CounterHelper.Counters.Find(x => x.Id == id);
            c.Value++;
            return c;
        }
    }
}
