using System.Runtime.CompilerServices;
using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Models;
using api_counter.wwwapi9.Repository;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace api_counter.wwwapi9.EndPoints
{
    public static class CounterEndpoints
    {
        public static void InitializeEndpoints(this WebApplication app) 
        {
            var counters = app.MapGroup("/counters");

            counters.MapGet("/", GetCounters);

            counters.MapGet("/{id}", GetCounterById);

            counters.MapGet("/greaterthan/{number}", GreaterThan);

            counters.MapGet("/lessthan/{number}", LessThan);

            counters.MapPut("/increment/{number}", IncrementCounter);

            counters.MapPut("/decrement/{number}", DecrementCounter);
        }

        // Methods for the endpoints
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounters(IRepository repository)
        {
            return TypedResults.Ok(repository.Counters());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounterById(IRepository repository, int id)
        {
            return TypedResults.Ok(repository.GetCounterById(id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GreaterThan(IRepository repository, int number)
        {
            return TypedResults.Ok(repository.GreaterThan(number));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> LessThan(IRepository repository, int number)

        {
            return TypedResults.Ok(repository.LessThan(number));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> IncrementCounter(IRepository repository, int id)
        {
            Counter c = repository.IncrementCounter(id);

            if (c == null)
                return TypedResults.NotFound($"Counter by id: {id} does not exist");

            return TypedResults.Ok(c);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> DecrementCounter(IRepository repository, int id)

        {
            Counter c = repository.DecrementCounter(id);

            if (c == null)
                return TypedResults.NotFound($"Counter by id: {id} does not exist");

            return TypedResults.Ok(c);
        }

    }
}
