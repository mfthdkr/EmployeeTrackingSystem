﻿using EmployeeTrackingSystem.CoreLayer.DTOs.Common;
using EmployeeTrackingSystem.CoreLayer.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using EmployeeTrackingSystem.CoreLayer.Services;

namespace EmployeeTrackingSystem.WebAPI.Filter
{
    public class NotFoundFilter<TEntity, TDto> : IAsyncActionFilter where TEntity : BaseEntity where TDto : class
    {
        private readonly IService<TEntity, TDto> _service;

        public NotFoundFilter(IService<TEntity, TDto> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity.Data)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(TEntity).Name}({id}) not found"));
        }
    }
}
