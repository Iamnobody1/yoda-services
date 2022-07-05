using Microsoft.EntityFrameworkCore;
using Yoda.Services.MiniGame.Data;
using Yoda.Services.MiniGame.Services.Monster;
using Yoda.Services.MiniGame.Services.MapMonster;
using Yoda.Services.MiniGame.Services.Map;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration["AllowedOrigins"];
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        nameof(allowedOrigins),
        policy =>
        {
            policy.WithOrigins(allowedOrigins.Split(';'))
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
    );
});
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
        options.SerializerSettings.DateFormatString = builder.Configuration.GetValue<String>("DateFormatString");
    });
builder.Services.AddMvc();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IMapService, MapService>();
builder.Services.AddTransient<IMonsterService, MonsterService>();
builder.Services.AddTransient<IMapMonsterService, MapMonsterService>();
builder.Services.AddDbContext<MinigameContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Minigame")));

var app = builder.Build();
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(nameof(allowedOrigins));
app.Run();
