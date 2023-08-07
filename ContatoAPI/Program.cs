using ContatoAPI.Application.Commands;
using ContatoAPI.Infrastructure;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContextoBd>(options => options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddFluentValidation(fv => {
    fv.RegisterValidatorsFromAssemblyContaining<AdicionarPessoaCommandValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<ContatoAdicionarPessoaValidator>();

    fv.RegisterValidatorsFromAssemblyContaining<EditarPessoaCommandValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<ContatoEditarPessoaValidator>();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.IgnoreNullValues = true;
}); ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAll");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
