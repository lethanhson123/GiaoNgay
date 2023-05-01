




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null); ;


builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                    new HeaderApiVersionReader("x-api-version"),
                                                    new MediaTypeApiVersionReader("x-api-version"));
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Services.AddDbContext<GiaoNgayContext>();
builder.Services.AddTransient<IBankBusiness, BankBusiness>();
builder.Services.AddTransient<ICategoryMembershipBusiness, CategoryMembershipBusiness>();
builder.Services.AddTransient<ICategoryOrderDetailBusiness, CategoryOrderDetailBusiness>();
builder.Services.AddTransient<ICategoryOrderPaymentBusiness, CategoryOrderPaymentBusiness>();
builder.Services.AddTransient<ICategoryOrderStatusBusiness, CategoryOrderStatusBusiness>();
builder.Services.AddTransient<ICompanyBusiness, CompanyBusiness>();
builder.Services.AddTransient<ICompanyProfileBusiness, CompanyProfileBusiness>();
builder.Services.AddTransient<IDistrictBusiness, DistrictBusiness>();
builder.Services.AddTransient<IMembershipBusiness, MembershipBusiness>();
builder.Services.AddTransient<IMembershipProfileBusiness, MembershipProfileBusiness>();
builder.Services.AddTransient<IMembershipFileBusiness, MembershipFileBusiness>();
builder.Services.AddTransient<IOrderDeliveryBusiness, OrderDeliveryBusiness>();
builder.Services.AddTransient<IOrderDeliveryDetailBusiness, OrderDeliveryDetailBusiness>();
builder.Services.AddTransient<IOrderDeliveryPaymentHistoryBusiness, OrderDeliveryPaymentHistoryBusiness>();
builder.Services.AddTransient<IOrderDeliveryStatusBusiness, OrderDeliveryStatusBusiness>();
builder.Services.AddTransient<IProvinceBusiness, ProvinceBusiness>();
builder.Services.AddTransient<IStreetBusiness, StreetBusiness>();
builder.Services.AddTransient<IStreetWardBusiness, StreetWardBusiness>();
builder.Services.AddTransient<IWardBusiness, WardBusiness>();

builder.Services.AddTransient<IBankRepository, BankRepository>();
builder.Services.AddTransient<ICategoryMembershipRepository, CategoryMembershipRepository>();
builder.Services.AddTransient<ICategoryOrderDetailRepository, CategoryOrderDetailRepository>();
builder.Services.AddTransient<ICategoryOrderPaymentRepository, CategoryOrderPaymentRepository>();
builder.Services.AddTransient<ICategoryOrderStatusRepository, CategoryOrderStatusRepository>();
builder.Services.AddTransient<ICompanyProfileRepository, CompanyProfileRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<IDistrictRepository, DistrictRepository>();
builder.Services.AddTransient<IMembershipRepository, MembershipRepository>();
builder.Services.AddTransient<IMembershipProfileRepository, MembershipProfileRepository>();
builder.Services.AddTransient<IMembershipFileRepository, MembershipFileRepository>();
builder.Services.AddTransient<IOrderDeliveryDetailRepository, OrderDeliveryDetailRepository>();
builder.Services.AddTransient<IOrderDeliveryPaymentHistoryRepository, OrderDeliveryPaymentHistoryRepository>();
builder.Services.AddTransient<IOrderDeliveryRepository, OrderDeliveryRepository>();
builder.Services.AddTransient<IOrderDeliveryStatusRepository, OrderDeliveryStatusRepository>();
builder.Services.AddTransient<IProvinceRepository, ProvinceRepository>();
builder.Services.AddTransient<IStreetRepository, StreetRepository>();
builder.Services.AddTransient<IStreetWardRepository, StreetWardRepository>();
builder.Services.AddTransient<IWardRepository, WardRepository>();


var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseCors(options =>
             options.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
