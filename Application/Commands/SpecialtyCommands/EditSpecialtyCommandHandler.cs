namespace Application.Commands.SpecialtyCommands;
public class EditSpecialtyCommandHandler(DataContext context) : IRequestHandler<EditSpecialtyCommand, Unit>
{
    private readonly DataContext _context = context;

    public async Task<Unit> Handle(EditSpecialtyCommand request, CancellationToken cancellationToken)
    {
        var existingSpecialty = await _context.Specialties.FindAsync([request.Specialty.Id], cancellationToken: cancellationToken);

        if (existingSpecialty is null)
            return Unit.Value;

        existingSpecialty.Name = request.Specialty.Name;
        existingSpecialty.Description = request.Specialty.Description;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
