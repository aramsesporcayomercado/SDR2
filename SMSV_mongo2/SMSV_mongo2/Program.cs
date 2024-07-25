using SMSV_mongo2.Models;
using SMSV_mongo2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DatabaseSettings>(

    builder.Configuration.GetSection("ConnectionSettings")
    );
//resolving the dependencies here
builder.Services.AddTransient<IAlertasService,AlertasService>();

builder.Services.AddTransient<IPacientesService, PacientesService>();

builder.Services.AddTransient<IMembresiasService, MembresiasService>();

builder.Services.AddTransient<IPaquetesService, PaquetesService>();

builder.Services.AddTransient<IClientesService, ClientesService>();

builder.Services.AddTransient<IMonitorSignosService, MonitorSignosService>();

builder.Services.AddTransient<IPadecimientosService, PadecimientosService>();

builder.Services.AddTransient<IReporteFallasService, ReporteFallasService>();



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
