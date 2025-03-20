
using Event_Plus.Context;
using Event_Plus.Interfaces;
using Event_Plus.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services // Acessa a coleção de serviços da aplicação (Dependency Injection)
    .AddControllers() // Adiciona suporte a controladores na API (MVC ou Web API)
    .AddJsonOptions(options => // Configura as opções do serializador JSON padrão (System.Text.Json)
    {
        // Configuração para ignorar propriedades nulas ao serializar objetos em JSON
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;

        // Configuração para evitar referência circular ao serializar objetos que possuem relacionamentos recursivos
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });



// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<EventContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();

builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();



builder.Services.AddControllers();

var app = builder.Build();



app.MapControllers();
app.Run();

