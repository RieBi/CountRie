namespace Application.Queries.CharacterQueries;
internal class GetCharacterOwnerEmailQueryHandler(DataContext context) : IRequestHandler<GetCharacterOwnerEmailQuery, string?>
{
    private readonly DataContext _context = context;

    public async Task<string?> Handle(GetCharacterOwnerEmailQuery request, CancellationToken cancellationToken)
    {
        var ownerMail = await _context.Characters
                .Where(f => f.Id == request.CharacterId)
                .Select(f => f.OwnerEmail)
                .SingleOrDefaultAsync(cancellationToken);

        return ownerMail;
    }
}
