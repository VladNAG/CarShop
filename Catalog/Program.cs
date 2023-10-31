using Catalog.Infrostructure;
using Catalog.Interfeces;
using Catalog.Servises;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IProductServise, ProductServis>();
builder.Services.AddSingleton<IDataProvider, DataProvider>();

builder.Services.AddCors();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();