using Notes.Persistence;

namespace Notes.Tests.Common;

public abstract class TestCommandBase: IDisposable
{
    protected NotesDbContext Context;

    public TestCommandBase()
    {
        Context = NotesContextFactory.Create();
    }

    public void Dispose()
    {
        NotesContextFactory.Destroy(Context);
    }
}