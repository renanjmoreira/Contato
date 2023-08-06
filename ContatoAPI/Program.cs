using ContatoAPI.Application.Commands;
using ContatoAPI.Infrastructure;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ContextoBd>(options => options.UseInMemoryDatabase("InMemoryDb"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddFluentValidation(fv => {
    fv.RegisterValidatorsFromAssemblyContaining<AdicionarPessoaCommandValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<ContatoAdicionarPessoaValidator>();

    fv.RegisterValidatorsFromAssemblyContaining<EditarPessoaCommandValidator>();
    fv.RegisterValidatorsFromAssemblyContaining<ContatoEditarPessoaValidator>();
});


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
