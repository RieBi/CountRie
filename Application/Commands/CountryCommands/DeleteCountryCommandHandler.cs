namespace Application.Commands.CountryCommands;
public class DeleteCountryCommandHandler(DataContext context) : IRequestHandler<DeleteCountryCommand, Unit>
{
    private readonly DataContext _context = context;

    public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
    {
        var countryToDelete = await _context.Countries.FindAsync([request.Id], cancellationToken: cancellationToken);

        if (countryToDelete is null)
            return Unit.Value;

        _context.Remove(countryToDelete);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
