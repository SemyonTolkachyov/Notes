using AutoMapper;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Persistence;
using Notes.Tests.Common;
using Shouldly;

namespace Notes.Tests.Notes.Query;

[Collection("QueryCollection")]
public class GetNoteDetailsQueryHandlerTests
{
    private readonly NotesDbContext _context;
    private readonly IMapper _mapper;

    public GetNoteDetailsQueryHandlerTests(QueryTestFixter fixter)
    {
        _context = fixter.Context;
        _mapper = fixter.Mapper;
    }

    [Fact]
    public async Task GetNoteListQueryHandler_Success()
    {
        //Arrange
        var handler = new GetNoteDetailsQueryHandler(_context, _mapper);
        //Act
        var result = await handler.Handle(new GetNoteDetailsQuery
        {
            UserId = NotesContextFactory.UserBId,
            Id = Guid.Parse("F08B6128-099B-4BD7-9CBC-CAA423FD7178")
        }, CancellationToken.None);
        //Assert
        result.ShouldBeOfType<NoteDetailsVm>();
        result.Id.ShouldBe(Guid.Parse("F08B6128-099B-4BD7-9CBC-CAA423FD7178"));
        result.Title.ShouldBe("Title2");
        result.Details.ShouldBe("Details2");
        result.CreationDate.ShouldBe(DateTime.Today);
        result.EditDate.ShouldBe(null);
    }
}