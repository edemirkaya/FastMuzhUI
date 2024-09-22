using Application.Features.ServiceCategories.Commands.Create;
using Application.Features.ServiceCategories.Commands.Delete;
using Application.Features.ServiceCategories.Commands.Update;
using Application.Features.ServiceCategories.Queries.GetById;
using Application.Features.ServiceCategories.Queries.GetList;
using Application.Features.ServiceCategories.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoryController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateServiceCategoryCommand createServiceCategoryCommand)
        {
            return Ok(await Mediator.Send(createServiceCategoryCommand));
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListServiceCategoryQuery query = new() { PageRequest = pageRequest };
            GetListResponse<GetListServiceCategoryListItemDto> response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery)
        {
            GetListByDynamicServiceCategoryQuery query = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
            GetListResponse<GetListByDynamicServiceCategoryListItemDto> response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            GetByIdServiceCategoryQuery query = new() { Id = id };
            GetByIdServiceCategoryResponse response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateServiceCategoryCommand updateServiceCategoryCommand)
        {
            return Ok(await Mediator.Send(updateServiceCategoryCommand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteServiceCategoryResponse response = await Mediator.Send(new  DeleteServiceCategoryCommand { Id = id });
            return Ok(response);
        }
    }
}
