using Application.Authorization;
using Application.Commands.CountryCommands;
using Application.Queries.CountryQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class CountryController(IMediator mediator, IAuthorizationService authorizationService) : Controller
{
    private readonly IMediator _mediator = mediator;
    private readonly IAuthorizationService _authorizationService = authorizationService;

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

        var isAuthorized = await _authorizationService.AuthorizeAsync(User, countryId, Requirements.Country);
        ViewData["authorized"] = isAuthorized.Succeeded;

        return View(country);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(CountryCreateDto country)
    {
        if (!ModelState.IsValid)
            return View();

        var result = await _mediator.Send(new CreateCountryCommand(country, User));
        if (result.IsFailed)
            return View();

        return RedirectToAction(nameof(Details), new { name = country.Name });
    }

    [HttpGet("[Controller]/[Action]/{name}")]
    [Authorize]
    public async Task<IActionResult> Edit(string name)
    {
        var countryId = await _mediator.Send(new GetCountryIdByNameQuery(name));
        if (countryId == -1)
            return this.RedirectBack();

        var isAuthorized = await _authorizationService.AuthorizeAsync(User, countryId, Requirements.Country);
        if (!isAuthorized.Succeeded)
            return Forbid();

        var countryDto = await _mediator.Send(new GetCountryCreateDtoQuery(countryId));

        if (countryDto is null || !ModelState.IsValid)
            return this.RedirectBack();

        ViewData["id"] = countryId;
        return View(countryDto);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Edit(int id, CountryCreateDto country)
    {
        var isAuthorized = await _authorizationService.AuthorizeAsync(User, id, Requirements.Country);
        if (!isAuthorized.Succeeded)
            return Forbid();

        if (!ModelState.IsValid)
            return this.RedirectBack();

        await _mediator.Send(new EditCountryCommand(id, country));

        return RedirectToAction(nameof(Details), new { name = country.Name });
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var isAuthorized = await _authorizationService.AuthorizeAsync(User, id, Requirements.Country);
        if (!isAuthorized.Succeeded)
            return Forbid();

        if (ModelState.IsValid)
            await _mediator.Send(new DeleteCountryCommand(id));

        return RedirectToAction(nameof(Index));
    }
}
