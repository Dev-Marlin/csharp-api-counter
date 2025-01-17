using System.Runtime.CompilerServices;
using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Repository;
using Microsoft.AspNetCore.Mvc;

namespace api_counter.wwwapi9.EndPoints
{
    public static class CounterEndpoints
    {
        public static void InitialiseEndpoints(this WebApplication app) 
        {
            var counters = app.MapGroup("/");

            counters.MapGet("/", GetCounters);
        }

        // Methods for the endpoints
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetCounters(IRepository repository)

        {
            return TypedResults.Ok(CounterHelper.Counters);
        }

    }
}
