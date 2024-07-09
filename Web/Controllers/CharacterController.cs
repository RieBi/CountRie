using Application.Queries.CharacterQueries;
using Application.Queries.CountryQueries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.Battles;
using Web.ViewModels.Characters;

namespace Web.Controllers;
public class CharacterController(IMediator mediator, IMapper mapper) : Controller
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var characters = await _mediator.Send(new GetCharacterListQuery());

        return View(characters);
    }

    [HttpGet("[controller]/{name}")]
    public async Task<IActionResult> Details(string name)
    {
        var character = await _mediator.Send(new GetCharacterDetailsQuery(name));
        if (character is null || !ModelState.IsValid)
            return NotFound();

        var characterBattles = await _mediator.Send(new GetCharacterBattlesQuery(character.Id));
        var characterViewModelBattles = _mapper.Map<IList<BattleDetailsViewModel>>(characterBattles);

        var characterViewModel = _mapper.Map<CharacterDetailsViewModel>(character);
        characterViewModel.Battles = characterViewModelBattles;

        return View(characterViewModel);
    }
}
