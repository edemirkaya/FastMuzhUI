using Application.Features.ServiceCategories.Commands.Create;
using Application.Features.ServiceCategories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
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
    }
}
