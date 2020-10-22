using SpentCalculator.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpentCalculator.Exceptions
{
    public class JsonExceptionMiddleware
    {
        public JsonExceptionMiddleware()
        { }

        public async Task Invoke(HttpContext context)
        {
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null && contextFeature.Error != null)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
            }
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new ProblemDetails {
                Status = context.Response.StatusCode,
                Title = "Internal Server Error",
                Detail = contextFeature.Error.Message,
                Instance = contextFeature.Error.Source
            }));
        }
    }
}
