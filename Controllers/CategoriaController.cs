using Loja_ECommerce_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loja_ECommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            var categorias = await _categoriaService.GetAllAsync();
            return Ok(categorias);
        }
    }
}
