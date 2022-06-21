using Yoda.Service2.Data;
using Microsoft.EntityFrameworkCore;
using Yoda.Services.Data;
using Yoda.Services.Services.Authentication;
using Yoda.Services.Services.Order;
using Yoda.Services.Services.OrderDetailsService;
using Yoda.Services.Services.Customer;
using Yoda.Services.Services.User;
using Yoda.Service2.Services.Product;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration["AllowedOrigins"];
Console.WriteLine("AllowedOrigins: " + allowedOrigins);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderDetailsService, OrderDetailsService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddDbContext<YodaContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=yoda;Username=postgres;Password=postgres;"));
// builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//         .AddEntityFrameworkStores<ApplicationDbContext>()
//         .AddDefaultTokenProviders();

builder.Services.AddMvc();

// Add application services.
// builder.Services.AddTransient<IEmailSender, AuthMessageSender>();
// builder.Services.AddTransient<ISmsSender, AuthMessageSender>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
