using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyTodo.Facades;
using MyTodo.Facades.Interfaces;
using MyTodo.Middlewares;
using MyTodo.Repositories.Db;
using MyTodo.Repositories.Db.Data;
using MyTodo.Repositories.Interfaes.Db;
using MyTodo.Services;
using MyTodo.Services.Interfaces;

namespace MyTodo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>();
            services.AddScoped<AppDbContext, AppDbContext>();
            services.AddSwaggerGen();
            services.AddMemoryCache();
            services.AddHangfire(x =>
            {
                x.UseMemoryStorage();
            });
            services.AddHangfireServer();

            services.AddScoped<IGetAllTodosRepository, TodoRepository>();
            services.AddScoped<IGetTodoRepository, TodoRepository>();
            services.AddScoped<ICreateTodoRepository, TodoRepository>();
            services.AddScoped<IUpdateTodoRepository, TodoRepository>();
            services.AddScoped<IDeleteTodoRepository, TodoRepository>();

            services.AddScoped<IGetAllTodosService, GetAllTodosService>();
            services.AddScoped<IGetTodoByIdService, GetTodoByIdService>();
            services.AddScoped<ICreateTodoService, CreateTodoService>();
            services.AddScoped<IUpdateTodoService, UpdateTodoService>();
            services.AddScoped<IDeleteTodoService, DeleteTodoService>();
            services.AddSingleton<IEnqueueJobService, HangfireEnqueueJobService>();
            services.AddScoped<ISendEmailService, FakeSendEmailService>();

            services.AddScoped<ITodoFacade, TodoFacade>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Todo");
                c.RoutePrefix = string.Empty;
            });

            app.UseHangfireDashboard();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
