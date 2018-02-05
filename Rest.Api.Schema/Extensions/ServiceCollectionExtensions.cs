using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Rest.Api.Schema.Conventions;
using Rest.Api.Schema.Documents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rest.Api.Schema.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRestfulSchema(this IServiceCollection services)
        {
            services.Configure<MvcOptions>(
                options => options.Conventions.Add(new RestfulSchemaConvention()));

            services.AddTransient<IDocument, Document>();

            return services;
        }
    }
}
