
using Catalog.Apis.Data;
using Catalog.Apis.Repository;
using Catalog.Apis.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using MongoDB.Driver.Core.Misc;
using Swashbuckle.AspNetCore.SwaggerUI; 

#region DI 




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen (c => c.SwaggerDoc("v1",new OpenApiInfo { Title ="Catalog.Apis",Version="v1"}));


builder.Services.Configure<DatabaseSettings>(op => builder.Configuration.GetSection("DatabaseSettings").Bind(op));    
//builder.Configuration.GetSection("DatabaseSettings").Bind(ap);
builder.Services.AddSingleton<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<ProductRepository, ProductRepository>();


#endregion


#region Middelware

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}



app.UseDeveloperExceptionPage();



app.UseSwagger();

//app.UseSwagger( c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));

//app.UseSwagger();

// Enable middleware to serve Swagger UI (HTML, CSS, JS, etc.)
app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1");
    });

    app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

#endregion


// ...


