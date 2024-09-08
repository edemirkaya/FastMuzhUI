using Application.Features.ServiceCategories.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    }
}
