using AutoMapper;
using FM.API.DTO;
using FM.Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace FM.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get/all")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _service.GetAll();
            var result = _mapper.Map<List<ProductDTO>>(products);
            return Ok(result);
        }
    }
}
