using Application.Commands.BattleCommands;
using Application.Queries.BattleQueries;
using Application.Queries.CharacterQueries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.Battles;

namespace Web.Controllers;
public class BattleController(IMediator mediator, IMapper mapper) : Controller
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var battles = await _mediator.Send(new GetBattleListQuery());
        var battlesViewModels = _mapper.Map<IList<BattleDetailsViewModel>>(battles);

        var randomBattleName = await _mediator.Send(new GetRandomBattleNameQuery());
        var characterNames = await _mediator.Send(new GetAllCharacterNamesQuery());
        
        var viewModel = new BattleListViewModel()
        {
            Battles = battlesViewModels,
            BattleName = randomBattleName,
            CharacterNames = characterNames,
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRandomBattle(int characterId)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var newBattleId = await _mediator.Send(new CreateRandomBattleCommand(characterId));

        return Redirect(Request.Headers.Referer.ToString() + $"#b-{newBattleId}");
    }

    [HttpPost]
    public async Task<IActionResult> CreateSpecificBattle(int characterId, [FromForm] string? opponentName)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        if (string.IsNullOrWhiteSpace(opponentName))
            return RedirectToActionPreserveMethod(nameof(CreateRandomBattle), routeValues: new { characterId });

        var ret = Request.Headers.Referer.ToString() + "#opponentName";

        var opponentIdResult = await _mediator.Send(new GetCharacterIdByNameQuery(opponentName));
        if (opponentIdResult.IsFailed)
        {
            TempData["Error"] = "The provided opponent is not a valid character.";
            return Redirect(ret);
        }

        var opponentId = opponentIdResult.Value;

        var newBattleIdResult = await _mediator.Send(new CreateSpecificBattleCommand(characterId, opponentId));

        if (newBattleIdResult.IsFailed)
        {
            TempData["Error"] = "A character cannot fight itself.";
            return Redirect(ret);
        }

        var newBattleId = newBattleIdResult.Value;

        return Redirect(Request.Headers.Referer.ToString() + $"#b-{newBattleId}");

    }

    [HttpPost]
    public async Task<IActionResult> CreateNamedBattle(string characterName1, string characterName2, string battleName)
    {
        if (!ModelState.IsValid || characterName1 == characterName2)
            return RedirectToAction(nameof(Index));

        var characterId1Result = await _mediator.Send(new GetCharacterIdByNameQuery(characterName1));
        if (characterId1Result.IsFailed)
            return RedirectToAction(nameof(Index));

        var characterId2Result = await _mediator.Send(new GetCharacterIdByNameQuery(characterName2));
        if (characterId2Result.IsFailed)
            return RedirectToAction(nameof(Index));
        
        var battleId = await _mediator.Send(new CreateNamedBattleCommand(characterId1Result.Value, characterId2Result.Value, battleName));
        return RedirectToAction(nameof(Index), "Battle", $"b-{battleId}");
    }
}
