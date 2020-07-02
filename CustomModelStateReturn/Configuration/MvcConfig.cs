using CustomModelStateReturn.Controllers.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CustomModelStateReturn.Configuration
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfig(this IServiceCollection services)
        {
            services.AddControllers()
                    .ConfigureApiBehaviorOptions(options =>
                    {
                        options.SuppressMapClientErrors = true;
                        options.InvalidModelStateResponseFactory = actionContext =>
                        {
                            return new UnprocessableEntityObjectResult(new ResponseBase
                            {
                                Succeeded = false,
                                Errors = RenderErrorsFromModelState(actionContext.ModelState)
                            });
                        };
                    });

            return services;
        }

        private static IEnumerable<ResponseError> RenderErrorsFromModelState(ModelStateDictionary modelState)
        {
            foreach (var modelErrors in modelState)
            {
                foreach (var error in modelErrors.Value.Errors)
                {
                    yield return new ResponseError
                    {
                        Property = modelErrors.Key,
                        Message = error.Exception != null
                                  ? error.Exception.Message
                                  : error.ErrorMessage
                    };
                }
            }
        }
    }
}
