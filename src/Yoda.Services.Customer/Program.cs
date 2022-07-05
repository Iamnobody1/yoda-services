using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD:src/Yoda.Services/Program.cs
using Yoda.Services.Data;
using Yoda.Services.Services.Country;
using Yoda.Services.Services.Customer;
using Yoda.Services.Services.District;
using Yoda.Services.Services.Map;
using Yoda.Services.Services.Monster;
using Yoda.Services.Services.MapMonster;
using Yoda.Services.Services.Order;
using Yoda.Services.Services.OrderDetailsService;
using Yoda.Services.Services.PostalCode;
using Yoda.Services.Services.Product;
using Yoda.Services.Services.Province;
=======
using Yoda.Services.Customer.Data;
using Yoda.Services.Customer.Services.Country;
using Yoda.Services.Customer.Services.Customer;
using Yoda.Services.Customer.Services.District;
using Yoda.Services.Customer.Services.Order;
using Yoda.Services.Customer.Services.OrderDetailsService;
using Yoda.Services.Customer.Services.PostalCode;
using Yoda.Services.Customer.Services.Product;
using Yoda.Services.Customer.Services.Province;
>>>>>>> 0be4c03c5c8be414574377d04a70e223d43485d3:src/Yoda.Services.Customer/Program.cs

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
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
        options.SerializerSettings.DateFormatString = builder.Configuration.GetValue<String>("DateFormatString");
    });
builder.Services.AddMvc();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IDistrictService, DistrictService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderDetailsService, OrderDetailsService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProvinceService, ProvinceService>();
builder.Services.AddTransient<IPostalCodeService, PostalCodeService>();
builder.Services.AddTransient<ISubDistrictService, SubDistrictService>();
builder.Services.AddTransient<IMapService, MapService>();
builder.Services.AddDbContext<YodaContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Yoda")));

var app = builder.Build();
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(nameof(allowedOrigins));
app.Run();
