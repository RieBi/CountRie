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

    [HttpGet("[controller]/{name}")]
    public async Task<IActionResult> Details(string name)
    {
        var country = await _mediator.Send(new GetCountryDetailsQuery(name));
        if (country is null || !ModelState.IsValid)
            return NotFound();

        return View(country);
    }
}
