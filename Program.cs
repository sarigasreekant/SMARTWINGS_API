using ForexDataService;
using DataAccess;

using ForexDataService;
using ForexModel;
using Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.AspNetCore.ResponseCompression;

using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;
var MyAllowSpecificOrigins = "forex";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

GlobalConnection.ConnectionString = builder.Configuration.GetConnectionString("SqlConnection"); //sql connection
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = true;

    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = JwtAuthenticationManager.ValidIssuer,
        ValidAudience = JwtAuthenticationManager.ValidAudience,
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        LifetimeValidator = TokenLifetimeValidator.Validate,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtAuthenticationManager.JWT_SECURITY_KEY))

    };
});
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<ICustomerIdDetailsDataService, CustomerIdDetailsDataService>();
builder.Services.AddScoped<ICustomerOtherDocumentDataService, CustomerOtherDocumentDataService>();
builder.Services.AddScoped<ICustomer_mstDataService, Customer_mstDataService>();
builder.Services.AddScoped<IRateSheetDataService, RateSheetDataService>();
builder.Services.AddScoped<ICurrencyDataService, CurrencyDataService>();
builder.Services.AddScoped<IDropDwnListDataService, DropDwnListDataService>();
builder.Services.AddScoped<IForexHederDataService, ForexHederDataService>();
builder.Services.AddScoped<IApplicationErorrLogService, ApplicationErorrLogService>();
builder.Services.AddScoped<IPromoActivityDataService, PromoActivityDataService>();
builder.Services.AddScoped<IUserMstDataService, UserMstDataService>();
builder.Services.AddScoped<IRemittanceDataService, RemittanceDataService>();
builder.Services.AddScoped<IRemServiceProfileDataService, RemServiceProfileDataService>();
builder.Services.AddScoped<IApplicationErorrLogService, ApplicationErorrLogService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseAuthentication();

app.Run();
