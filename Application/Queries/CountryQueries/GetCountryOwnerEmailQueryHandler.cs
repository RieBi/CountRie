namespace Application.Queries.CountryQueries;
internal class GetCountryOwnerEmailQueryHandler(DataContext context) : IRequestHandler<GetCountryOwnerEmailQuery, string?>
{
    private readonly DataContext _context = context;

    public async Task<string?> Handle(GetCountryOwnerEmailQuery request, CancellationToken cancellationToken)
    {
        var ownerMail = await _context.Characters
                .Where(f => f.Id == request.CountryId)
                .Select(f => f.OwnerEmail)
                .SingleOrDefaultAsync(cancellationToken);

        return ownerMail;
    }
}
