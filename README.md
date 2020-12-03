# Configure OData with Swagger.
If you would like to configure OData with Swagger in Asp.net Core 3.1 & 5.0 then you are in the right place.

When you configure OData with Swagger then you would expect the following error message on Swagger Ui Page.

[![Swagger Ui OData Error](https://i.postimg.cc/50QBSt48/1.png)](https://postimg.cc/WFjq2TJ4)

So How can we solve this problem? Here is the solution.

**Note:**
I hope that you have already downloaded the following swagger & Odata nuget package on your existing OData api solution.
```
Microsoft.AspNetCore.OData
Microsoft.AspNetCore.Mvc.NewtonsoftJson
Swashbuckle.AspNetCore
```

### Step 1
Add following nuget package in your existing OData Api Solution.
[![Generic badge](https://img.shields.io/badge/Nuget-1.0.0-<COLOR>.svg)](https://www.nuget.org/packages/OData.Swagger/1.0.0)

#### Using Nuget Package Manger:
```
PM> Install-Package OData.Swagger -Version 1.0.0
```

#### Using .Net CLI:
```
> dotnet add package OData.Swagger --version 1.0.0
```

### Step 2
Go to Startup.cs file, Add the following service in ConfigureService Method.
```C#
 services.AddOdataSwaggerSupport();
```
That's it.

Full ConfigureService Method Code.
```C#
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers().AddNewtonsoftJson();

    services.AddOData();

    services.AddSwaggerGen((config) =>
    {
        config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
        {
            Title = "Swagger Odata Demo Api",
            Description = "Swagger Odata Demo",
            Version = "v1"
        });
    });

    services.AddOdataSwaggerSupport();
}
```

Full StartUp.cs file source code.
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OData.Swagger.Services;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.AddOData();

            services.AddSwaggerGen((config) =>
            {
                config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Swagger Odata Demo Api",
                    Description = "Swagger Odata Demo",
                    Version = "v1"
                });
            });

            services.AddOdataSwaggerSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI((config) =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Odata Demo Api");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.EnableDependencyInjection();
                endpoints.Select().Filter().OrderBy().Count().MaxTop(10);
            });
        }
    }
}
```

### Step 3
Run your Web api and call swagger ui page.

[![Swagger Ui OData Solved](https://i.postimg.cc/PJjktPN4/2.png)](https://postimg.cc/wy0r2xXy)

You can run sample example from the following link.<space><space>
https://github.com/KishorNaik/Sol_OData_Swagger_Support/tree/master/V3.1/Sol_Demo/Api
https://github.com/KishorNaik/Sol_OData_Swagger_Support/tree/master/V5.0/Sol_Demo/Api 

Example of OData in Asp.net core 3.1: <space><space>
https://github.com/KishorNaik/Sol_OData_WebApi

Example of Swagger in Asp.net core 3.1: <space><space>
https://github.com/KishorNaik/Sol_Swagger_WebApi

