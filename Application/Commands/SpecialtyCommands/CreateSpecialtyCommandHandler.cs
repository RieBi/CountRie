namespace Application.Commands.SpecialtyCommands;
public class CreateSpecialtyCommandHandler(DataContext context) : IRequestHandler<CreateSpecialtyCommand, int>
{
    private readonly DataContext _context = context;

    public async Task<int> Handle(CreateSpecialtyCommand request, CancellationToken cancellationToken)
    {
        await _context.Specialties.AddAsync(request.Specialty, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return request.Specialty.Id;
    }
}
