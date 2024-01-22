using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Product.Entity.DTO;
using Product.Service.Service;

namespace Product.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResourceTextController : ControllerBase
    {
        private readonly IResourceTextService _resourceTextService;
        private readonly IMemoryCache _cache;

        public ResourceTextController(IResourceTextService resourceTextService, IMemoryCache cache)
        {
            _resourceTextService = resourceTextService;
            _cache = cache;
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

        [HttpPost(Name = "GetByKeyList")]
        public IActionResult GetByKeyList(ResourceDTO model)
        {
            var result = _resourceTextService.GetByKeyList(model);
            _cache.Set("GetByKeyList", result, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) });
            return Ok(result);
        }
    }
}
