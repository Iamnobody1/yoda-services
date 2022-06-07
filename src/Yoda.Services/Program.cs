using Yoda.Services.Services.Authentication;
using Yoda.Services.Services.User;

var builder = WebApplication.CreateBuilder(args);
var allowedHosts = builder.Configuration["AllowedHosts"];
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
    policy =>
    {
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    }
    );
});
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);
app.Run();
