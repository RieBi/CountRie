using Application.Commands.CountryCommands;
using Application.Queries.CountryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class CountryController(IMediator mediator) : Controller
{
    private readonly IMediator _mediator = mediator;

    public async Task<IActionResult> Index()
    {
        var countries = await _mediator.Send(new GetCountryListQuery());

        return View(countries);
    }

    [HttpGet("[Controller]/[Action]/{name}")]
    public async Task<IActionResult> Details(string name)
    {
        var country = await _mediator.Send(new GetCountryDetailsQuery(name));
        if (country is null || !ModelState.IsValid)
            return NotFound();

        return View(country);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CountryCreateDto country)
    {
        if (!ModelState.IsValid)
            return View();

        await _mediator.Send(new CreateCountryCommand(country));

        return View();
    }
}
