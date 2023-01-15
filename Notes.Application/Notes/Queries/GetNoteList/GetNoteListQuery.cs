using MediatR;

namespace Notes.Application.Notes.Queries.GetNoteList;

public class GetNoteListQuery : IRequest
{
    public Guid UserId { get; set; }
}