using Application.Commands.NaturalResourceCommands;
using Application.Queries.NaturalResourceQueries;
using AutoMapper;
using Data.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers;
public class NaturalResourceController(IMediator mediator, IMapper mapper) : Controller
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var resources = await _mediator.Send(new GetNaturalResourceListQuery());

        return View(resources);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] ShortInfoViewModel resource)
    {
        if (!ModelState.IsValid)
            return this.RedirectBack();

        var resourceModel = _mapper.Map<NaturalResource>(resource);
        await _mediator.Send(new EditNaturalResourceCommand(resourceModel));

        return this.RedirectBack();
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
            return this.RedirectBack();

        await _mediator.Send(new DeleteNaturalResourceCommand(id));

        return this.RedirectBack();
    }
}
