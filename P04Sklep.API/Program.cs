using P04Sklep.API.Services.ProductService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>(); //obiekt jest tworzony za ka¿dym razem dla nowego zapytania HTTP od klienta
// - jedno zapytanie tworzy jedn¹ instancjê

//builder.Services.AddSingleton<IProductService, ProductService>(); - nowa instancja klasy Produkt service zostanie utworzna tylko 1 raz na ca³y cykl trwania naszej aplikacji

//builder.Services.AddTransient<IProductService, ProductService>(); - obiekt jest tworzony za ka¿dym razem kiedy odwo³ujemy siê do konstruktora, nawet podczas trwania cyklu jednego zapytania.

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

app.Run();
