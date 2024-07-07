using Application.Queries.CharacterQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;
public class CharacterController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    public async Task<IActionResult> Index()
    {
        var characters = await _mediator.Send(new GetCharacterListQuery());

        return View(characters);
    }
}
