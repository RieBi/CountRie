using Application.Commands.SpecialtyCommands;
using Application.Queries.SpecialtyQueries;
using AutoMapper;
using Data.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers;
public class SpecialtyController(IMediator mediator, IMapper mapper) : Controller
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var specialties = await _mediator.Send(new GetSpecialtyListQuery());

        return View(specialties);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] ShortInfoViewModel specialty)
    {
        if (!ModelState.IsValid)
            return this.RedirectBack();

        var specialtyModel = _mapper.Map<Specialty>(specialty);
        await _mediator.Send(new CreateSpecialtyCommand(specialtyModel));

        return this.RedirectBack();
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] ShortInfoViewModel specialty)
    {
        if (!ModelState.IsValid)
            return this.RedirectBack();

        var specialtyModel = _mapper.Map<Specialty>(specialty);
        await _mediator.Send(new EditSpecialtyCommand(specialtyModel));

        return this.RedirectBack();
    }
}
