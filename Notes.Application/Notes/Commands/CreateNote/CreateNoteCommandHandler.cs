using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.CreateNote;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
{
    private readonly INotesDbContext _dbContext;

    public CreateNoteCommandHandler(INotesDbContext dbContext)
        => _dbContext = _dbContext;
    
    public async Task<Guid> Handle(CreateNoteCommand request,
        CancellationToken cancellationToken)
    {
        var note = new Note
        {
            UserId = request.UserID,
            Title = request.Title,
            Details = request.Details,
            Id = new Guid(),
            CreationDate = DateTime.Now,
            EditDate = null
        };

        await _dbContext.Notes.AddAsync(note, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
            
        return note.Id;
    }
}