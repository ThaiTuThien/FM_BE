using AutoMapper;
using FM.API.DTO;
using FM.Application.IService;
using FM.Domain.Entities;
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

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDTO dto)
        {
            var products = _mapper.Map<Product>(dto);
            var result = await _service.Add(products);
            if(result) return Ok(result);
            return BadRequest();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDTO dto)
        {
            var idConvert = dto.Productid.ToOracleGuid();
            var productExist = await _service.FindById(idConvert);
            if(productExist == null) return NotFound();

            var products = _mapper.Map(dto, productExist);
            var result = await _service.Update(products);
            if(result) return Ok(result);
            return BadRequest();
        }
    }
}
