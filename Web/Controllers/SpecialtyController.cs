using Application.Commands.SpecialtyCommands;
using Application.Queries.SpecialtyQueries;
using AutoMapper;
using Data.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Create([FromForm] ShortInfoViewModel specialty)
    {
        if (!ModelState.IsValid)
            return this.RedirectBack();

        var specialtyModel = _mapper.Map<Specialty>(specialty);
        await _mediator.Send(new CreateSpecialtyCommand(specialtyModel));

        return this.RedirectBack();
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Edit([FromForm] ShortInfoViewModel specialty)
    {
        if (!ModelState.IsValid)
            return this.RedirectBack();

        var specialtyModel = _mapper.Map<Specialty>(specialty);
        await _mediator.Send(new EditSpecialtyCommand(specialtyModel));

        return this.RedirectBack();
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
            return this.RedirectBack();

        await _mediator.Send(new DeleteSpecialtyCommand(id));

        return this.RedirectBack();
    }
}
