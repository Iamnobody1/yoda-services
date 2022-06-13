using Yoda.Services.Services.Authentication;
using Yoda.Services.Services.User;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration["AllowedOrigins"];
Console.WriteLine("allowedSpecificOrigins: " + allowedOrigins);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
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
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.UseCors(nameof(allowedOrigins));
app.UseDeveloperExceptionPage();
app.Run();
