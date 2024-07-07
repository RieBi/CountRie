using Application.Queries.CharacterQueries;
using Application.Queries.CountryQueries;
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

    [HttpGet("[controller]/{name}")]
    public async Task<IActionResult> Details(string name)
    {
        var character = await _mediator.Send(new GetCharacterDetailsQuery(name));
        if (character is null || !ModelState.IsValid)
            return NotFound();

        return View(character);
    }
}
