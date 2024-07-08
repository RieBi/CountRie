using Application.Commands.BattleCommands;
using Data.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;
public class BattleController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;


    public IActionResult Index()
    {
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> CreateRandomBattle(int characterId)
    {
        if (!ModelState.IsValid)
            return NotFound();

        var newBattleId = await _mediator.Send(new CreateRandomBattleCommand(characterId));

        return Redirect(Request.Headers.Referer.ToString() + $"#b-{newBattleId}");
    }
}
