using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace API.Extensions
{
    public class ExecutionTimeFilter : IActionFilter
    {
        private Stopwatch _stopwatch;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Detengo tiempo
            _stopwatch.Stop();

            // Imprimo en consola el metodo y el tiempo de ejecucion y muestro los milisegundos
            Console.WriteLine($"Tiempo de ejecución ({context.ActionDescriptor.DisplayName}): ({_stopwatch.Elapsed}) {_stopwatch.ElapsedMilliseconds} ms");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Inicio tiempo
            _stopwatch = Stopwatch.StartNew();
        }
    }
}
