using Microsoft.EntityFrameworkCore;
using Yoda.Services.Data;
using Yoda.Services.Services.Country;
using Yoda.Services.Services.Customer;
using Yoda.Services.Services.District;
using Yoda.Services.Services.Order;
using Yoda.Services.Services.OrderDetailsService;
using Yoda.Services.Services.PostalCode;
using Yoda.Services.Services.Product;
using Yoda.Services.Services.Province;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigins = builder.Configuration["AllowedOrigins"];
Console.WriteLine("AllowedOrigins: " + allowedOrigins);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
        options.SerializerSettings.DateFormatString = builder.Configuration.GetValue<String>("DateFormatString");
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IDistrictService, DistrictService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderDetailsService, OrderDetailsService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProvinceService, ProvinceService>();
builder.Services.AddTransient<IPostalCodeService, PostalCodeService>();
builder.Services.AddTransient<ISubDistrictService, SubDistrictService>();
builder.Services.AddDbContext<YodaContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Yoda")));
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
