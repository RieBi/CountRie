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
        var countryId = await _mediator.Send(new GetCountryIdByNameQuery(name));
        if (countryId == -1)
            return this.RedirectBack();

        var country = await _mediator.Send(new GetCountryDetailsQuery(countryId));
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

        return RedirectToAction(nameof(Details), new { name = country.Name });
    }

    [HttpGet("[Controller]/[Action]/{name}")]
    public async Task<IActionResult> Edit(string name)
    {
        var countryId = await _mediator.Send(new GetCountryIdByNameQuery(name));
        if (countryId == -1)
            return this.RedirectBack();

        var countryDto = await _mediator.Send(new GetCountryCreateDtoQuery(countryId));

        if (countryDto is null || !ModelState.IsValid)
            return this.RedirectBack();

        ViewData["id"] = countryId;
        return View(countryDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, CountryCreateDto country)
    {
        if (!ModelState.IsValid)
            return this.RedirectBack();

        await _mediator.Send(new EditCountryCommand(id, country));

        return RedirectToAction(nameof(Details), new { name = country.Name });
    }
}
