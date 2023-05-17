#nullable disable

using Polly;
using SM.Integration.Application.AutoMapper;
using SM.Integration.Application.Htpp.Category;
using SM.Integration.Application.Interfaces;
using SM.Integration.Application.Services;
using SM.MQ.Configuration;
using SM.MQ.Extensions;
using SM.MQ.Models;
using SM.Util.Extensions;
using SM.Util.Options;

var builder = WebApplication.CreateBuilder(args);
const int timeWait = 30;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<HttpCategoryDelegatingHandler>();

builder.Services.AddHttpClient<ICategoryClient, CategoryClient>()
      .AddHttpMessageHandler<HttpCategoryDelegatingHandler>()
      .AddPolicyHandler(PollyExtensions.GetRetryPolicy())
      .AddTransientHttpErrorPolicy(p => p.CircuitBreakerAsync(2, TimeSpan.FromSeconds(timeWait)));

builder.Services.Configure<APIsOptions>(builder.Configuration.GetSection(nameof(APIsOptions)));

// Service
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

var builderMQ = new BuilderBus(builder.Configuration["RabbitMq:ConnectionString"])
{
    Publishers = new HashSet<IPublisher>
                {
                    new Publisher<RequestIn>(queue: builder.Configuration["RabbitMq:ConsumerCategory"]),
                    new Publisher<RequestIn>(queue: builder.Configuration["RabbitMq:ConsumerProduct"]),
                    new Publisher<RequestIn>(queue: builder.Configuration["RabbitMq:ConsumerSupplier"])
                },

    Retry = new Retry(retryCount: 3, interval: TimeSpan.FromSeconds(60))
};
builder.Services.AddEventBus(builderMQ);

// AutoMapping
builder.Services.AddAutoMapperSetup();

builder.Services.AddHealthChecks()
            .AddRabbitMQ(
               builder.Configuration["RabbitMq:ConnectionString"],
               name: "RabbitMQ");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
