using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rest.Api.Schema.Middleware
{
    public class RestfulSchemaMiddleware
    {
        private readonly RequestDelegate next;

        public RestfulSchemaMiddleware(RequestDelegate next)
            => this.next = next ?? throw new ArgumentNullException(nameof(next));

        public async Task Invoke(HttpContext context)
        {
            await next(context);
        }
    }
}
