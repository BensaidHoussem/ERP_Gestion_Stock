var builder = WebApplication.CreateBuilder(args);

var build=new ConfigurationBuilder();
build.AddJsonFile("appsettings.json");
var config=build.Build();

builder.Services.Configure<DbContextSettings>(config);
builder.Services.AddControllers().AddNewtonsoftJson(option=>
option.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.InjectionAll();
builder.Services.AddHttpClient();

builder.Services.AddCors(option=>
option.AddPolicy("My Policy",builder=>{
    builder.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();

}));

// Add services to the container.
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

app.UseHttpsRedirection();
app.MapControllers();
app.UseCors("My Policy");
app.Run();


