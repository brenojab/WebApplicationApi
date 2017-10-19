using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Owin;
using System.Web.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Serialization;

namespace WebApplicationApi
{

  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      HttpConfiguration config = new HttpConfiguration();
      WebApiConfig.Register(config);
      app.UseWebApi(config);
    }

  }

  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );

      var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
      jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    }
  }

  //public class Startup
  //{
  //    public Startup(IConfiguration configuration)
  //    {
  //        Configuration = configuration;
  //    }

  //    public IConfiguration Configuration { get; }

  //    // This method gets called by the runtime. Use this method to add services to the container.
  //    public void ConfigureServices(IServiceCollection services)
  //    {
  //        services.AddMvc();
  //    }

  //    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
  //    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
  //    {
  //        if (env.IsDevelopment())
  //        {
  //            app.UseDeveloperExceptionPage();
  //        }

  //        app.UseMvc();
  //    }
  //}
}
