using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Interfaces;
using Notes.Persistence;

namespace Notes.Tests.Common;

public class QueryTestFixter: IDisposable
{
    public NotesDbContext Context;
    public IMapper Mapper;

    public QueryTestFixter()
    {
        Context = NotesContextFactory.Create();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
        });
        Mapper = configurationProvider.CreateMapper();
    }

    public void Dispose()
    {
        NotesContextFactory.Destroy(Context);
    }
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection: ICollectionFixture<QueryTestFixter> {}
}