using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Framework.BusinessService.Interface;
using Framework.Entities.Interface;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Framework.DTO.Interface;
using Microsoft.AspNetCore.Routing;

namespace Framework.Api
{
    public static class BaseApi
    {
        public static void MapCrudEndpoints<TDto, TDtoGrid, TDtoAdd, TDtoEdit, TEntity, TEntityId, TService>(
            this IEndpointRouteBuilder endpoints, string baseRoute)
            where TDto : class, IBaseDtoEntity<TEntityId>, new()
            where TDtoGrid : class
            where TDtoAdd : class
            where TDtoEdit : class
            where TEntity : class, IBaseEntity<TEntityId>
            where TEntityId : struct
            where TService : IBaseService<TEntity, TEntityId>
        {
            var route = $"{baseRoute}/{{id?}}";

            endpoints.MapGet(baseRoute, async (TService service) =>
            {
                var items = await service.GetAllAsync<TDto>();
                return Results.Ok(items);
            });

            endpoints.MapGet($"{baseRoute}/{{id}}", async (TEntityId id, TService service) =>
            {
                var item = await service.GetById<TDto>(id);
                return item is not null ? Results.Ok(item) : Results.NotFound();
            });

            endpoints.MapPost(baseRoute, async (TDtoAdd item, TService service, IStringLocalizer localizer) =>
            {
                var createdId = await service.Add(item);

                var result = new TDto { Id = createdId };

                return Results.Created($"{baseRoute}/{createdId}", result);
            });

            endpoints.MapPut(baseRoute, async (TDtoEdit item, TService service, IStringLocalizer localizer) =>
            {
                var updatedId = await service.Update(item);

                var result = new TDto { Id = updatedId };

                return Results.Ok(result);
            });

            endpoints.MapDelete($"{baseRoute}/{{id}}", async (TEntityId id, TService service) =>
            {
                await service.Remove(id);
                return Results.NoContent();
            });
        }
    }
}