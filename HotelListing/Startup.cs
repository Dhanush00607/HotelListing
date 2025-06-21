public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Register services here, like controllers
        services.AddSwaggerGen(); // If using Startup.cs

        services.AddControllers();
        services.AddCors(o => {
            o.AddPolicy("Allow All", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });
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
