
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebApi.DbOperations;

namespace WebApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

        
        

            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore API", Version = "v1" });
            });
            services.AddDbContext<BookStoreDbContext>(options =>
                options.UseInMemoryDatabase("BookStoreDb"));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","BookStore API v1"));
        
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
        app.UseHttpsRedirection();
    }

    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(endpoints => endpoints.MapControllers());
}
        }
    }
