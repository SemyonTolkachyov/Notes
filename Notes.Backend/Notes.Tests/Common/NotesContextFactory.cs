using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistence;

namespace Notes.Tests.Common;

public class NotesContextFactory
{
    public static Guid UserAId = Guid.NewGuid();
    public static Guid UserBId = Guid.NewGuid();
    public static Guid NoteIdForDelete = Guid.NewGuid();
    public static Guid NoteIdForUpdate = Guid.NewGuid();

    public static NotesDbContext Create()
    {
        var options = new DbContextOptionsBuilder<NotesDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new NotesDbContext(options);
        context.Database.EnsureCreated();
        context.Notes.AddRange(
            new Note
            {
                CreationDate = DateTime.Today,
                Details = "Details1",
                EditDate = null,
                Id = Guid.Parse("F90E5960-DA13-45C3-930A-258D674445EE"),
                Title = "Title1",
                UserId = UserAId
            },
            new Note
            {
                CreationDate = DateTime.Today,
                Details = "Details2",
                EditDate = null,
                Id = Guid.Parse("F08B6128-099B-4BD7-9CBC-CAA423FD7178"),
                Title = "Title2",
                UserId = UserBId
            },
            new Note
            {
                CreationDate = DateTime.Today,
                Details = "Details3",
                EditDate = null,
                Id = NoteIdForDelete,
                Title = "Title3",
                UserId = UserAId
            },
            new Note
            {
                CreationDate = DateTime.Today,
                Details = "Details4",
                EditDate = null,
                Id = NoteIdForUpdate,
                Title = "Title4",
                UserId = UserBId
            }
        );
        context.SaveChanges();
        return context;
    }

    public static void Destroy(NotesDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}