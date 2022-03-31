using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NRGi_aspirant_opgave.Data;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

// Serilog initializens
Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console(/*new RenderedCompactJsonFormatter()*/)
            .CreateLogger();

// The try catch is used to catch start up errors
try
{
    Log.Information("Starting up");
    var builder = WebApplication.CreateBuilder(args);

    // Wires Serilog into the WebApplicationBuilder
    builder.Host.UseSerilog((ctx, lc) => lc
                .WriteTo.Console()
                .ReadFrom.Configuration(ctx.Configuration));

    // Is used with real db
    //builder.Services.AddDbContext<PropertiesContext>(options =>
    //    options.UseSqlServer(builder.Configuration.GetConnectionString("PropertiesContext")));

    //builder.Services.AddDbContext<ConditionReportsContext>(options =>
    //    options.UseSqlServer(builder.Configuration.GetConnectionString("ConditionReportsContext")));

    // Is used with InMemory local db
    builder.Services.AddDbContext<PropertiesContext>(options =>
    options.UseInMemoryDatabase("PropertiesContext"));

    builder.Services.AddDbContext<ConditionReportsContext>(options =>
    options.UseInMemoryDatabase("ConditionReportsContext"));

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Add Serilog's request logging middleware
    app.UseSerilogRequestLogging();

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
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
