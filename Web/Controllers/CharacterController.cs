using Application.Authorization;
using Application.Commands.CharacterCommands;
using Application.Queries.CharacterQueries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.Battles;
using Web.ViewModels.Characters;

namespace Web.Controllers;
public class CharacterController(IMediator mediator, IMapper mapper, IAuthorizationService authorizationService) : Controller
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;
    private readonly IAuthorizationService _authorizationService = authorizationService;

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

        var isAuthorized = await _authorizationService.AuthorizeAsync(User, character.Id, Requirements.Character);
        ViewData["authorized"] = isAuthorized.Succeeded;

        return View(characterViewModel);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CharacterCreateDto character)
    {
        if (!ModelState.IsValid)
            return View();

        var result = await _mediator.Send(new CreateCharacterCommand(character, User));
        if (result.IsFailed)
            return View();

        return RedirectToAction(nameof(Details), new { name = character.Name });
    }

    [HttpGet("[Controller]/[Action]/{name}")]
    [Authorize]
    public async Task<IActionResult> Edit(string name)
    {
        var characterIdResult = await _mediator.Send(new GetCharacterIdByNameQuery(name));
        if (characterIdResult.IsFailed)
            return this.RedirectBack();

        var characterId = characterIdResult.Value;

        var isAuthorized = await _authorizationService.AuthorizeAsync(User, characterId, Requirements.Character);
        if (!isAuthorized.Succeeded)
            return Forbid();

        var characterDto = await _mediator.Send(new GetCharacterCreateDtoQuery(characterId));

        if (characterDto is null || !ModelState.IsValid)
            return this.RedirectBack();

        ViewData["id"] = characterId;
        return View(characterDto);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Edit(int id, CharacterCreateDto character)
    {
        var isAuthorized = await _authorizationService.AuthorizeAsync(User, id, Requirements.Character);
        if (!isAuthorized.Succeeded)
            return Forbid();

        if (!ModelState.IsValid)
            return this.RedirectBack();

        await _mediator.Send(new EditCharacterCommand(id, character));

        return RedirectToAction(nameof(Details), new { name = character.Name });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var isAuthorized = await _authorizationService.AuthorizeAsync(User, id, Requirements.Character);
        if (!isAuthorized.Succeeded)
            return Forbid();

        if (ModelState.IsValid)
            await _mediator.Send(new DeleteCharacterCommand(id));

        return RedirectToAction(nameof(Index));
    }
}
