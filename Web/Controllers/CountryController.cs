using Application.Queries.CountryList;
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
}
