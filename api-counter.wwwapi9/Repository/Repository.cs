using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api_counter.wwwapi9.Repository
{
    public class Repository : IRepository
    {
        public Counter AddCounter(Counter counter)
        {
            CounterHelper.Counters.Add(counter);

            return counter;
        }

        public IEnumerable<Counter> Counters()
        {
            return CounterHelper.Counters;
        }
        public Counter GetCounterById(int id)
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

        public Counter DecrementCounter(int id)
        {
            Counter c = CounterHelper.Counters.Find(x => x.Id == id);
            c.Value--;
            return c;
        }

        public IEnumerable<Counter> GreaterThan(int number)
        {
            return CounterHelper.Counters.Where(x => x.Value > number);
        }

        public IEnumerable<Counter> LessThan(int number)
        {
            return CounterHelper.Counters.Where(x => x.Value < number);
        }
    }
}
