var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//default route
app.MapGet("/", () => "Hello World!");

// route with parameters
app.MapGet("/users/{userId}/posts/{slug}", (int userId, string slug) =>
{
    return $"User Id : {userId}, Slug : {slug}";
});

// This route only accepts id of type int and greater than 0
app.MapGet("/products/{id:int:min(0)}", (int id) =>
{
    return $"Products : Id  : {id}";
});

// Route with default to 2016
app.MapGet("/report/{year?}", (int? year = 2016) =>
{
    return $"Report for year : {year}";
});

// Route with default to empty
app.MapGet("/reports/{year?}", (int? year) =>
{
    return $"Report for year : {year}";
});

// Catch All Route
// catches all route after files in filePath, usefull in receiveing a path to files
app.MapGet("/files/{*filePath}", (string filePath) =>
{
    return $"File Path : {filePath}";
});

// Route with query parameters
app.MapGet("/search", (string? q, int page = 1) =>
{
    return $"Searching for {q} on page {page}";
});

// Path with using all the techniques
app.MapGet("/store/{category}/{productId:int?}/{*extraPath}", (string category, int? productId, string? extraPath, bool inStock = true) =>
{
    return $"Search for product with id : {productId} in category : {category}, having path : {extraPath} and in stock to be {inStock}";
});

app.Run();