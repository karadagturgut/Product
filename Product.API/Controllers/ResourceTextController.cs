using Microsoft.AspNetCore.Mvc;
using Product.Entity.DTO;
using Product.Service.Service;

namespace Product.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResourceTextController : ControllerBase
    {
        private readonly IResourceTextService _resourceTextService;

        public ResourceTextController(IResourceTextService resourceTextService)
        {
            _resourceTextService = resourceTextService;
        }

        [HttpPost(Name = "Add")]
        public IActionResult Add(ResourceDTO model)
        {
            var result = _resourceTextService.Add(model);
            return Ok(result);
        }

        [HttpPost(Name = "Remove")]
        public IActionResult Remove(ResourceDTO model)
        {
            var result = _resourceTextService.Delete(model);
            return Ok(result);
        }

        [HttpPost(Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var result = _resourceTextService.GetById(id);
            return Ok(result);
        }

        [HttpPost(Name = "GetByKey")]
        public IActionResult GetByKey(ResourceDTO model)
        {
            var result = _resourceTextService.GetByKey(model);
            return Ok(result);
        }


    }
}
