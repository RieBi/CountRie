namespace Application.Commands.SpecialtyCommands;
internal class CreateSpecialtyCommandHandler(DataContext context) : IRequestHandler<CreateSpecialtyCommand, int>
{
    private readonly DataContext _context = context;

    public async Task<int> Handle(CreateSpecialtyCommand request, CancellationToken cancellationToken)
    {
        _context.Specialties.Add(request.Specialty);
        await _context.SaveChangesAsync(cancellationToken);

        return request.Specialty.Id;
    }
}
