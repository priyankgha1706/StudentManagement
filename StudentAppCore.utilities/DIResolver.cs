using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StudentAppCore.Core.IRepositories;
using StudentAppCore.Core.IServices;
using StudentAppCore.Resources.Repositories;
using StudentCoreApp.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentAppCore.utilities
{
  public class DIResolver
    {
        public static void configureservice(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IServices, StudentServices>();

            services.AddScoped<IRepositories, StudentRepositories>();

        }

    }
}
