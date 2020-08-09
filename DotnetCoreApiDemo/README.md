# dotnet-core-api-template

## Features

> This is a development project template, it is NOT production ready. It only kickstarting your project so that you don't need to build from scratch.

1. pre-Configured Autofac 5.2.0 registrations setup.
2. Ready Swagger 5.5.1 endpoint. 
3. pre-Configured Serilog 2.9.0 console sinks.
4. pre-Configured AutoMapper 10.0.0.
5. pre-Installed Newtonsoft.Json 12.0.3

## Commands

The commands to install nuget packages

```bash
dotnet add package Newtonsoft.Json
dotnet add package Autofac
dotnet add package Autofac.Extensions.DependencyInjection
dotnet add package Serilog
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Settings.Configuration
dotnet add package Serilog.Sinks.Console
dotnet add package AutofacSerilogIntegration
dotnet add package Swashbuckle.AspNetCore
dotnet add package Swashbuckle.AspNetCore.Examples
dotnet add package Swashbuckle.AspNetCore.Annotations
dotnet add package AutoMapper
dotnet add package AutoMapper.Contrib.Autofac.DependencyInjection
```

## Installed and configured

- Newtonsoft Json
- Autofac
- Serilog
- Swagger
- AutoMapper

## Documentation

- Pre-configured Autofac ContainerBuilder() that you can populate IServiceCollection and register your autofac modules in Startup.cs. Taking ApiModule from the template as an example, you can also create modules for your Service Layer, Repository Layer, etc.

```c#
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            ...
            builder.RegisterModule<ApiModule>();

            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }
```

Serilog & Automapper are registered in the ApiModule,

```c#
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterLogger();
            builder.AddAutoMapper(x=>x.AddProfile<ApiAutoMapperProfile>());
        }
    }
```

- Pre-configured swagger endpoint, that you can access via https://localhost:5001/swagger

```c#
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            ...
            if (!Environment.IsProduction())
            {
                services.AddSwaggerGen(
                    c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Swagger", Version = "v1" });
                    });
            }
            ...
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ...
            if (!Environment.IsProduction())
            {
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("./v1/swagger.json", "Api V1");
                });
            }
            ...
        }
```

- Pre-configured Serilog with console sinks in the appsettings.json

```json
  "Serilog": {
    "Using": [ "Serilog.Sinks.Console" ],
    "MinimumLevel": "Information",
    "WriteTo": [
      {
        "Name": "Console"        
      }
    ]
  }
```

And Serilog configuration in the program.cs

```c#
        public static IWebHostBuilder CreateHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                ...
                .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .ReadFrom.Configuration(hostingContext.Configuration)
                    .Enrich.FromLogContext());
        }  
```

And registered in ApiModule,

```c#
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterLogger();
            ...
        }
    }
```

- Pre-configured AutoMapper with created example profile,

```c#
    public class ApiAutoMapperProfile : Profile
    {
        public ApiAutoMapperProfile()
        {
            CreateMap<Foo, FooDto>();
            ...
        }
    }
```

And register the profile in ApiModule for AutoMapper,

```c#
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ...
            builder.AddAutoMapper(x=>x.AddProfile<ApiAutoMapperProfile>());
        }
    }
```

Usage of AutoMapper in Controller, inject into the constructor

```c#
        private readonly IMapper _mapper;

        public FooController(..., IMapper mapper)
        {
            ...
            _mapper = mapper;
        }
```

Consumed in the controller method,

```c#
    var dto = _mapper.Map<List<Foo>, List<FooDto>>(result);
```

## Support

Reach out to me at one of the following places!

- [Follow me @ Github](https://github.com/superwalnut)

- [Twitter](https://twitter.com/superwalnuts)

- [![ko-fi](https://www.ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/Z8Z61I9HB)

---

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**

-------