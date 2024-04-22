using App.Common.Exceptions.Person;
using App.Common.Exceptions.Profile;
using FluentValidation;
using FluentValidation.Results;
using System.Net;
using System.Text.Json;

namespace server.CustomMiddleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                HandleException(context, exception);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exception)
            {
                case NotFoundPersonException:
                    code = HttpStatusCode.NotFound;
                    break;

                case ProfileAlreadyExistsException:
                    code = HttpStatusCode.NotFound;
                    break;

                case ValidationException:
                    code = HttpStatusCode.UnprocessableEntity;
                    var exc = exception as ValidationException;

                    result = JsonSerializer.Serialize(
                        new
                        {
                            Success = false,
                            Errors = GetErrors(exc.Errors)
                        });
                    break;

                default:
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }

        private List<string> GetErrors(IEnumerable<ValidationFailure> exceptions)
        {
            List<string> result = new List<string>();

            foreach (var exc in exceptions)
            {
                result.Add(exc.ErrorMessage);
            }

            return result;
        }
    }
}
