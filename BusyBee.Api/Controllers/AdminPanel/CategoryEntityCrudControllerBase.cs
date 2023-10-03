using BusyBee.Api.Common;
using BusyBee.Api.Controllers.CrudBase;
using BusyBee.Core.Extensions;
using BusyBee.Core.Interfaces.Services.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace BusyBee.Api.Controllers.AdminPanel;

public class CategoryEntityCrudControllerBase<
    TPrimaryKey,
    TCreateCommand,
    TCreateCommandDto,
    TUpdateCommand,
    TUpdateCommandDto,
    TListResponse,
    TDetailedResponse,
    TAutocomplete,
    TQueryParams> : EntityCrudControllerBase<TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete,
    TQueryParams>
    where TPrimaryKey : IEquatable<TPrimaryKey>
    where TCreateCommandDto : TCreateCommand, IFormFileDto
    where TUpdateCommandDto : TUpdateCommand, IFormFileDto
{
    private readonly ICategoryCommonService<TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete,
        TQueryParams> _crudService;

    public CategoryEntityCrudControllerBase(
        ICategoryCommonService<TPrimaryKey, TCreateCommand, TUpdateCommand, TListResponse, TDetailedResponse, TAutocomplete, TQueryParams>
            crudService,
        ControllerCommonDependencies dependencies) : base(crudService, dependencies)
    {
        _crudService = crudService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<TDetailedResponse> CreateAsync([FromForm] TCreateCommandDto commandDto, CancellationToken token = default)
    {
        var command = Mapper.MapSelfIgnored<TCreateCommand>(commandDto);
        var keyAccessor = await _crudService.CreateAsync(command, commandDto.File?.OpenReadStream(),
            Path.GetExtension(commandDto.File?.FileName), token);
        await UnitOfWork.SaveChangesAsync(token);
        var id = keyAccessor.Value;
        var created = await CrudService.GetByIdAsync(id, token);
        var createdDto = Mapper.MapSelfIgnored<TDetailedResponse>(created);
        var getUrl = Url.Action(nameof(GetByIdAsync), null, ConvertEntityIdToRouteId(id), Request.Scheme);
        Response.Headers.Location = getUrl;
        Response.StatusCode = StatusCodes.Status201Created;
        return createdDto;
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<TDetailedResponse> UpdateAsync(TPrimaryKey id, [FromForm] TUpdateCommandDto commandDto,
        CancellationToken token = default)
    {
        var command = Mapper.MapSelfIgnored<TUpdateCommand>(commandDto);
        await _crudService.UpdateAsync(id, command, commandDto.File?.OpenReadStream(),
            Path.GetExtension(commandDto.File?.FileName), token);
        await UnitOfWork.SaveChangesAsync(token);
        var updated = await CrudService.GetByIdAsync(id, token);
        var updatedDto = Mapper.MapSelfIgnored<TDetailedResponse>(updated);
        Response.StatusCode = StatusCodes.Status202Accepted;
        return updatedDto;
    }

    [NonAction]
    public override Task<TDetailedResponse> CreateAsync(TCreateCommand commandDto, CancellationToken token = default)
    {
        return base.CreateAsync(commandDto, token);
    }

    [NonAction]
    public override Task<TDetailedResponse> UpdateAsync(TPrimaryKey id, TUpdateCommand commandDto, CancellationToken token = default)
    {
        return base.UpdateAsync(id, commandDto, token);
    }
}