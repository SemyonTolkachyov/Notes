namespace Notes.Persistence;

public class DbInitializer
{
    public void Initialize(NotesDbContext context)
    {
        context.Database.EnsureCreated();
    }
}