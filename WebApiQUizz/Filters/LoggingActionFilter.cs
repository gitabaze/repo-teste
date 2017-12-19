using Autofac.Integration.WebApi;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApiQUizz.Helpers;

namespace WebApiQUizz.Filters
{
    public class LoggingActionFilter : IAutofacActionFilter
    {
        readonly ILogger _logger;

        public LoggingActionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            _logger.Write(actionContext.ActionDescriptor.ActionName);
            return Task.FromResult(0);
        }

        public Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            _logger.Write(actionExecutedContext.ActionContext.ActionDescriptor.ActionName);
            return Task.FromResult(0);
        }
    }
}