using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using MMLib.SwaggerForOcelot.DependencyInjection;
using MMLib.SwaggerForOcelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

// Sadece Ocelot ve SwaggerForOcelot servislerini ekle
builder.Services.AddOcelot();
builder.Services.AddControllers();

builder.Services.AddSwaggerForOcelot(builder.Configuration);
builder.Services.AddSwaggerGen(c => { c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); });


var app = builder.Build();

// SwaggerForOcelot middleware'i ekle
app.UseSwaggerForOcelotUI();

// Ocelot middleware'i ekle
await app.UseOcelot();

app.Run();
