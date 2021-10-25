using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyTodo.Data;
using MyTodo.Protocols.Db.Repositories;
using MyTodo.Protocols.Services;
using MyTodo.Repositories;
using MyTodo.Services;

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

            // v2
            services.AddScoped<IGetAllTodosService, GetAllTodosService>();
            services.AddScoped<IGetTodoByIdService, GetTodoByIdService>();
            services.AddScoped<ICreateTodoService, CreateTodoService>();
            services.AddScoped<IUpdateTodoService, UpdateTodoService>();
            services.AddScoped<IDeleteTodoService, DeleteTodoService>();
            
            services.AddScoped<IGetAllTodosRepository, TodoRepository>();
            services.AddScoped<IGetTodoRepository, TodoRepository>();
            services.AddScoped<ICreateTodoRepository, TodoRepository>();
            services.AddScoped<IUpdateTodoRepository, TodoRepository>();
            services.AddScoped<IDeleteTodoRepository, TodoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
