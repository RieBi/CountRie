using Application.Converters;
using Application.Services.UserManagement;

namespace Application.Commands.CountryCommands;
internal class CreateCountryCommandHandler(DataContext context, IUserInfoService userInfo) : IRequestHandler<CreateCountryCommand, int>
{
    private readonly DataContext _context = context;
    private readonly IUserInfoService _userInfo = userInfo;

    public async Task<int> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await new CountryConverter(_context)
            .TryConvertFromDto(request.CountryCreateDto, cancellationToken);

        if (country is null)
            return -1;

        country.OwnerEmail = await _userInfo.GetUserEmailAsync(request.User);

        _context.Countries.Add(country);
        await _context.SaveChangesAsync(cancellationToken);

        return country.Id;
    }
}
