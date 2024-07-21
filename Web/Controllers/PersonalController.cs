using Application.Queries.PersonalQueries;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels.Personal;

namespace Web.Controllers;
public class PersonalController(IMediator mediator, IMapper mapper) : Controller
{
    private readonly IMediator _mediator = mediator;
    private readonly IMapper _mapper = mapper;


    [Authorize]
    public async Task<IActionResult> Index()
    {
        var userCreatedDto = await _mediator.Send(new GetUserCreatedEntitiesQuery(User));
        var viewModel = _mapper.Map<UserCreatedViewModel>(userCreatedDto);

        return View(viewModel);
    }
}
