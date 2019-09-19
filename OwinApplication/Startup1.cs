using System;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using NSwag.AspNet.Owin;
using Owin;

namespace OwinApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());


            app.UseWebApi(config);

            app.UseSwaggerUi3(typeof(Startup).Assembly, settings => { });

            string webPath = @"C:\Temp";

            FileServerOptions fileServerOptions = new FileServerOptions()
            {
                RequestPath = PathString.Empty,
                FileSystem = new PhysicalFileSystem(webPath),
                EnableDirectoryBrowsing = true,
            };

            app.UseFileServer(fileServerOptions);
        }
    }
}
