using ComplexDependencyInjection.Repositories;
using ComplexDependencyInjection.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddSingleton<IServiceSingleton, ServiceSingleton>();
        builder.Services.AddScoped<IServiceA, ServiceA>();
        builder.Services.AddScoped<IServiceB, ServiceB>();

        //Repositories
        builder.Services.AddScoped<IRepositoryA, RepositoryA>();
        builder.Services.AddTransient<IRepositoryB, RepositoryB>();
        builder.Services.AddTransient<IRepositoryC, RepositoryC>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}