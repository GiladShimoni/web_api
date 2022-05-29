
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Session;
using web_api.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddControllers();
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true;
    options.Cookie.HttpOnly = false;
    options.Cookie.SameSite = SameSiteMode.None;
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});*/
builder.Services.AddSession(
    options => { options.IdleTimeout = TimeSpan.FromMinutes(5); });
builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow All",
        builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });

});
builder.Services.AddCors(options =>
{
    /*options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000")
            .AllowCredentials();
    });*/
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});
builder.Services.AddCors(options =>
{
    // options.AddDefaultPolicy(policy => policy.AllowAnyOrigin());

    options.AddPolicy("Allow All",
    builder =>
    {
        builder.WithOrigins("http://localhost:3001").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
        builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseCors("Allow All");
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseHttpsRedirection();
app.UseSession();
app.MapControllers();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<ChatHub>("/Hubs/ChatHub");
});
app.Run();