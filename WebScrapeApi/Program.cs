var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

Console.WriteLine("Installing browsers");

// The following line installs the default browsers. If you only need a subset of browsers,
// you can specify the list of browsers you want to install among: chromium, chrome,
// chrome-beta, msedge, msedge-beta, msedge-dev, firefox, and webkit.
// var exitCode = Microsoft.Playwright.Program.Main(new[] { "install", "webkit", "chrome" });
// If you need to install dependencies, you can add "--with-deps"
var exitCode = Microsoft.Playwright.Program.Main(new[] { "install" });
if (exitCode != 0)
{
    Console.WriteLine("Failed to install browsers");
    Environment.Exit(exitCode);
}

Console.WriteLine("Browsers installed");

app.UseHttpsRedirection();

app.MapGet("/", () => "Welcome to Poor Man's Web Scraper!");

app.MapControllers();

app.Run();
