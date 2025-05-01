using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using IO.Swagger.Filters;

namespace IO.Swagger
{
    /// <summary>
    /// Configures services and request pipeline.
    /// </summary>
    public class Startup
    {
        private readonly IWebHostEnvironment _hostingEnv;
        private IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor to initialize environment and configuration.
        /// </summary>
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            _hostingEnv = env;
            Configuration = configuration;
        }

        /// <summary>
        /// Adds services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC with custom JSON and XML formatters
            services.AddMvc(options =>
            {
                options.InputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>();
                options.OutputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonOutputFormatter>();
            })
            .AddNewtonsoftJson(opts =>
            {
                opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                opts.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
            })
            .AddXmlSerializerFormatters();

            // Configure Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("1.0.0", new OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "Calculator API",
                    Description = "Calculator API (ASP.NET Core 7.0)",
                    Contact = new OpenApiContact
                    {
                        Name = "Swagger Codegen Contributors",
                        Url = new Uri("https://github.com/swagger-api/swagger-codegen")
                    }
                });
                c.CustomSchemaIds(type => type.FullName);
                c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");
                c.DocumentFilter<BasePathFilter>("/lital-e6f/calculateApi/1.0.0");
                c.OperationFilter<GeneratePathParamsValidationFilter>();
            });
        }

        /// <summary>
        /// Configures the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            // Enable Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/1.0.0/swagger.json", "Calculator API");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable development exception page
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Production exception handling
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
        }
    }
}
