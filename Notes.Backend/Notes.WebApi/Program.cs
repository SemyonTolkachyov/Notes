using Notes.Persistence;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);
using (var scope = builder.Services.BuildServiceProvider().CreateScope()) // invoke method of Db initialization
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<NotesDbContext>(); // for accessing dependencies
        DbInitializer.Initialize(context); // initialize database
    }
    catch(Exception e) { }
}

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();