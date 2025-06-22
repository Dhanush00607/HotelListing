using HotelListing.Configurations;
using HotelListing.Data;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>(options =>

           options.UseSqlServer(Configuration.GetConnectionString("sqlConnection"))
        );
        // Register services here, like controllers
        services.AddSwaggerGen(); // If using Startup.cs

        services.AddControllers();
        services.AddCors(o => {
            o.AddPolicy("Allow All", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });
        services.AddAutoMapper(typeof(MapperInitializer));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        // Set up the HTTP request pipeline
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseCors("Allow All");
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
