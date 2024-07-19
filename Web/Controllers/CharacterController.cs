using Application.Commands.CharacterCommands;
using Application.Commands.CountryCommands;
using Application.Queries.CharacterQueries;
using Application.Queries.CountryQueries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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

    [HttpGet("[Controller]/[Action]/{name}")]
    public async Task<IActionResult> Details(string name)
    {
        var character = await _mediator.Send(new GetCharacterDetailsQuery(name));
        if (character is null || !ModelState.IsValid)
            return NotFound();

        var characterBattles = await _mediator.Send(new GetCharacterBattlesQuery(character.Id));
        var characterViewModelBattles = _mapper.Map<IList<BattleDetailsViewModel>>(characterBattles);
        var characterNames = await _mediator.Send(new GetAllCharacterNamesQuery());

        var characterViewModel = _mapper.Map<CharacterDetailsViewModel>(character);
        characterViewModel.Battles = characterViewModelBattles;
        characterViewModel.AvailableCharactersNames = characterNames;

        return View(characterViewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CharacterCreateDto character)
    {
        if (!ModelState.IsValid)
            return View();

        await _mediator.Send(new CreateCharacterCommand(character));

        return RedirectToAction(nameof(Details), new { name = character.Name });
    }

    [HttpGet("[Controller]/[Action]/{name}")]
    public async Task<IActionResult> Edit(string name)
    {
        var characterId = await _mediator.Send(new GetCharacterIdByNameQuery(name));
        if (characterId == -1)
            return this.RedirectBack();

        var characterDto = await _mediator.Send(new GetCharacterCreateDtoQuery(characterId));

        if (characterDto is null || !ModelState.IsValid)
            return this.RedirectBack();

        ViewData["id"] = characterId;
        return View(characterDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, CharacterCreateDto character)
    {
        if (!ModelState.IsValid)
            return this.RedirectBack();

        await _mediator.Send(new EditCharacterCommand(id, character));

        return RedirectToAction(nameof(Details), new { name = character.Name });
    }
}
