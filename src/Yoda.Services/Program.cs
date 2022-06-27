using Microsoft.EntityFrameworkCore;
using Yoda.Services.Data;
using Yoda.Services.Services.Customer;
using Yoda.Services.Services.Order;
using Yoda.Services.Services.OrderDetailsService;
using Yoda.Services.Services.Product;
using Yoda.Services.Services.Province;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration["AllowedOrigins"];
Console.WriteLine("AllowedOrigins: " + allowedOrigins);
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
        options.SerializerSettings.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ssZ";
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderDetailsService, OrderDetailsService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProvinceService, ProvinceService>();
builder.Services.AddDbContext<YodaContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=yoda;Username=postgres;Password=postgres;"));
builder.Services.AddMvc();

var app = builder.Build();
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
