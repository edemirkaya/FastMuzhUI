using Application.Features.MasterProfiles.Queries.GetList;
using Application.Features.ServiceCategories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterProfileController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListMasterProfileQuery query = new() { PageRequest = pageRequest };
            GetListResponse<GetListMasterProfileListItemDto> response = await Mediator.Send(query);

            return Ok(response);
        }
    }
}
