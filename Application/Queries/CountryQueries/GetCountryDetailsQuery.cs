namespace Application.Queries.CountryQueries;
public class GetCountryDetailsQuery(int id) : IRequest<CountryDetailsDto?>
{
    public int Id { get; set; } = id;
}
