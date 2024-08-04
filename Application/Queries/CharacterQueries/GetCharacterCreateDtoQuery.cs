using Application.Commands.CharacterCommands;

namespace Application.Queries.CharacterQueries;
public record GetCharacterCreateDtoQuery(int Id) : IRequest<CharacterCreateDto?>;
