using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var provider = builder.Services.BuildServiceProvider();
var configurations = provider.GetRequiredService<IConfiguration>();
builder.Services.AddCors(options =>
{
    var frontedUrl = configurations.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder => { builder.WithOrigins(frontedUrl).AllowAnyMethod().AllowAnyHeader(); });
});
//builder.Services.AddCors(c =>
//{
//    c.AddPolicy("frontend_url", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//});

//JSON Serializer
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
    = new DefaultContractResolver());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseCors();

app.Run();
