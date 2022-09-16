using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Discord.Interfaces.Services;
using Discord.Services;
using Discord.Controllers;
using Discord.Interfaces.Controllers;
using Discord.Interfaces.Repository;
using Discord.DataAccess;
using Discord.DataAccess.Repository;
using Discord.DataAccess.Abstraction;

namespace Discord
{
    internal class Startup
    {
        public IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string DbConnectionString => _configuration.GetConnectionString("DiscordDatabase");

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder().AddJsonFile(@"C:\Projects\Discord\Discord\appsettings.Development.json");
            _configuration = builder.Build();
            services.AddControllersWithViews();
            services.AddScoped<IDatabase, Database>();
            services.AddScoped<IUserController, UserController>();
            services.AddScoped<IServerController, ServerController>();
            services.AddScoped<IChatController, ChatController>();
            services.AddScoped<IMessageController, MessageController>();
            services.AddScoped<ICsvFileController, CsvFileController>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IServerService, ServerService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ICsvFileService, CsvFileService>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Swagger Demo API",
                        Description = "Demo API for showing Swagger",
                        Version = "v1"
                    });
            });
            services.AddScoped<IUserRepository, UserRepository>(_ =>
                new UserRepository(new Database(DbConnectionString)));
            services.AddScoped<IServerRepository, ServerRepository>(_ =>
                new ServerRepository(new Database(DbConnectionString)));
            services.AddScoped<IChatRepository, ChatRepository>(_ =>
                new ChatRepository(new Database(DbConnectionString)));
            services.AddScoped<IMessageRepository, MessageRepository>(_ =>
                new MessageRepository(new Database(DbConnectionString)));
            services.AddScoped<ICsvFileRepository, CsvFileRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            env.EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName.Development;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStatusCodePages();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
                options.RoutePrefix = "";
            });
        }
    }
}
