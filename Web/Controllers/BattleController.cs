using Application.Commands.BattleCommands;
using Application.Queries.BattleQueries;
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
            return NotFound();

        var newBattleId = await _mediator.Send(new CreateRandomBattleCommand(characterId));

        return Redirect(Request.Headers.Referer.ToString() + $"#b-{newBattleId}");
    }
}
