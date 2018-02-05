using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Rest.Api.Schema.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Api.Schema.Middleware
{
    public class RestfulSchemaMiddleware
    {
        private readonly IDocument documenter;
        private readonly RequestDelegate next;

        public RestfulSchemaMiddleware(RequestDelegate next, IDocument documenter)
        {
            this.documenter = documenter ?? throw new ArgumentNullException(nameof(documenter));
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            //await next(context);

            var document = documenter.Create();

            var json = JsonConvert.SerializeObject(document);

            context.Response.StatusCode = 200;
            await context.Response.WriteAsync(json);

            context.Response.Body.Close();
        }
    }
}
