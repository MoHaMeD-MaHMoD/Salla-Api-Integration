using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SallaIntegration.Interfaces;
using SallaIntegration.Repository;
using SallaIntegration.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<SallaOAuthService>();
builder.Services.AddScoped<IAccessTokenRepository, AccessTokenRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient<ProductApiClientService>();
builder.Services.AddHttpClient<OrderApiClientService>();

builder.Services.AddDbContext<TokenDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AccessTokenConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();

// Add the token validation middleware
app.UseMiddleware<TokenValidationMiddleware>();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
