using Application.Commands.BattleCommands;
using Application.Queries.BattleQueries;
using Application.Queries.CharacterQueries;
using AutoMapper;
using Data.Models;
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

        return View(battlesViewModels);
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
    public async Task<IActionResult> CreateSpecificBattle(int characterId, [FromForm] string opponentName)
    {
        if (string.IsNullOrWhiteSpace(opponentName))
            return RedirectToActionPreserveMethod(nameof(CreateRandomBattle), routeValues: new { characterId });

        var ret = Request.Headers.Referer.ToString() + "#opponentName";

        if (!ModelState.IsValid)
            return BadRequest();

        var opponentId = await _mediator.Send(new GetCharacterIdByName(opponentName));
        if (opponentId is null)
        {
            TempData["Error"] = "The provided opponent is not a valid character.";
            return Redirect(ret);
        }

        var newBattleId = await _mediator.Send(new CreateSpecificBattleCommand(characterId, opponentId.Value));

        if (newBattleId == -1)
        {
            TempData["Error"] = "A character cannot fight itself.";
            return Redirect(ret);
        }

        return Redirect(Request.Headers.Referer.ToString() + $"#b-{newBattleId}");

    }
}
