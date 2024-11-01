using UserInfoApp.Service;

namespace UserInfoApp.Middleware
{
    public class ValidationMiddleware
    {
        private ValidationService _validationService;
        private RequestDelegate _next;

        public ValidationMiddleware(ValidationService validationService, RequestDelegate next)
        {
            _validationService = validationService;

            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _validationService.SendHeader(context);
            
            await _next.Invoke(context);
        }
    }
}