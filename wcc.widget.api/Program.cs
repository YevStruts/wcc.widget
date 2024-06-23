using wcc.widget.data;
using wcc.widget.kernel.RequestHandlers;
using wcc.widget.api.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var environment = builder.Configuration.GetValue("Environment", "dev");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetLiveScoreQuery).Assembly));
builder.Services.AddTransient<IDataRepository, DataRepository>();

var app = builder.Build();

string ravenDbUrl = $"/{environment}/wcc-widget/ravendb";
var ravenDbSettings = await AWSParameterStore.Instance().GetParameterAsync(ravenDbUrl);
DocumentStoreHolder.Init(ravenDbSettings);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// if (!app.Environment.IsDevelopment())
// {
//     app.UseHttpsRedirection();
// }

app.UseAuthorization();

app.MapControllers();

app.Run();
