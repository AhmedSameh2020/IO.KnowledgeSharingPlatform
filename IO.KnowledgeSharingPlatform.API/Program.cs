using IO.KnowledgeSharingPlatform.Application.Handlers;
using IO.KnowledgeSharingPlatform.Application.Interfaces.Repository;
using IO.KnowledgeSharingPlatform.Application.Interfaces.Services;
using IO.KnowledgeSharingPlatform.Infrastructure.Repository;
using IO.KnowledgeSharingPlatform.Infrastructure.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddMediatR(
    typeof(PostTedTalkHandler).Assembly
);
builder.Services.AddTransient<ITedTalkUnitOfWork, TedTalkUnitOfWork>();
builder.Services.AddTransient<ITedTalkService, TedTalkService>();
builder.Services.AddDbContext<KnowledgeSharingPlatformContext>(options => options.UseSqlServer(configuration.GetConnectionString("KnowledgeSharingPlatformDatabase")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var context = services.GetRequiredService<KnowledgeSharingPlatformContext>();
    if (!context.Database.CanConnect())
    {
        context.Database.Migrate();

        var tedTalkService = services.GetRequiredService<ITedTalkService>();
        tedTalkService.SeedTedTalks();
    }
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
