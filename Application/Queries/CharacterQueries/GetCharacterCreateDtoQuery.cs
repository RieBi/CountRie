using Application.Commands.CharacterCommands;

namespace Application.Queries.CharacterQueries;
public class GetCharacterCreateDtoQuery(int id) : IRequest<CharacterCreateDto?>
{
    public int Id { get; } = id;
}
