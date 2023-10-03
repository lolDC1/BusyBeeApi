using BusyBee.Api.Controllers.CrudBase;
using BusyBee.Api.Models.User;
using BusyBee.Core.Extensions;
using BusyBee.Core.Interfaces.Services.Domain;
using BusyBee.Core.Models.Common;
using BusyBee.Core.Models.User;
using BusyBee.Core.Models.User.UserPortfolioFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusyBee.Api.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController : EntityCrudControllerBase<
    Guid,
    UserCommand,
    UserCommand,
    UserResponse,
    UserResponse,
    ListItem<Guid>,
    UserQueryParams>
{
    private readonly IUserService _service;

    public UsersController(IUserService service, ControllerCommonDependencies dependencies) : base(service, dependencies)
    {
        _service = service;
    }

    [HttpGet]
    [Route("after-registration")]
    public async Task<UserResponse> AfterRegistration(CancellationToken token = default)
    {
        var keyAccessor = await _service.AfterRegistration(token);
        await UnitOfWork.SaveChangesAsync(token);

        var id = keyAccessor.Value;
        var created = await CrudService.GetByIdAsync(id, true, token: token);
        var getUrl = Url.Action(nameof(GetByIdAsync), null, ConvertEntityIdToRouteId(id), Request.Scheme);
        Response.Headers.Location = getUrl;
        Response.StatusCode = StatusCodes.Status201Created;
        return created!;
    }

    // [HttpPut("{id}")]
    // [ProducesResponseType(StatusCodes.Status202Accepted)]
    // public async Task<UserResponse> UpdateAsync(Guid id, [FromForm] UserCommandDto commandDto, CancellationToken token = default)
    // {
    //     var command = Mapper.MapSelfIgnored<UserCommand>(commandDto);
    //     await _service.UpdateAsync(id, command, commandDto.File?.OpenReadStream(),
    //         Path.GetExtension(commandDto.File?.FileName), token);
    //     await UnitOfWork.SaveChangesAsync(token);
    //     var updated = await CrudService.GetByIdAsync(id, true, token: token);
    //     Response.StatusCode = StatusCodes.Status202Accepted;
    //     return updated!;
    // }

    [HttpPut("photo")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task UpdatePhotoAsync([FromForm] UserCommandDto commandDto, CancellationToken token = default)
    {
        if (commandDto.File is null) throw new ArgumentException();

        await _service.UpdatePhotoAsync(commandDto.File.OpenReadStream(), Path.GetExtension(commandDto.File.FileName), token);
        await UnitOfWork.SaveChangesAsync(token);
        Response.StatusCode = StatusCodes.Status202Accepted;
    }

    [HttpPost]
    [Route("portfolio")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task CreatePortfolioFileAsync([FromForm] UserPortfolioFileCommandDto commandDto,
        CancellationToken token = default)
    {
        if (commandDto.File is null) throw ExceptionFactory.ValidationProblem("File must be");

        var command = Mapper.MapSelfIgnored<UserPortfolioFileCommand>(commandDto);
        await _service.CreatePortfolioFileAsync(command, commandDto.File.OpenReadStream(), commandDto.File.FileName, token);
        await UnitOfWork.SaveChangesAsync(token);
    }

    [HttpDelete("portfolio/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task DeletePortfolioFileAsync(Guid id, CancellationToken token = default)
    {
        await _service.DeletePortfolioFileByIdAsync(id, token);
        await UnitOfWork.SaveChangesAsync(token);
        Response.StatusCode = StatusCodes.Status204NoContent;
    }

    [HttpGet]
    [Route("me")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<UserResponse?> GetMeAsync(CancellationToken token = default)
    {
        return await _service.GetMe(token: token);
    }

    [AllowAnonymous]
    [HttpGet("anon/{id}")]
    [ActionName(nameof(GetByIdAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task<UserResponse> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        return base.GetByIdAsync(id, token);
    }

    [NonAction]
    public override Task<UserResponse> CreateAsync(UserCommand commandDto, CancellationToken token = default)
    {
        return base.CreateAsync(commandDto, token);
    }

    [NonAction]
    public override Task DeleteAsync(Guid id, CancellationToken token = default)
    {
        return base.DeleteAsync(id, token);
    }

    [NonAction]
    public override Task<PagedResult<UserResponse>> QueryAsync(UserQueryParams request, CancellationToken token = default)
    {
        return base.QueryAsync(request, token);
    }

    [NonAction]
    public override Task<PagedResult<ListItem<Guid>>> AutocompleteAsync(UserQueryParams request, CancellationToken token = default)
    {
        return base.AutocompleteAsync(request, token);
    }

    [NonAction]
    public override Task<List<ListItem<Guid>>> AutocompleteAllAsync(CancellationToken token = default)
    {
        return base.AutocompleteAllAsync(token);
    }
}