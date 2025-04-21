using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {

        private readonly IGetTodosUseCase _getUseCase;
        private readonly IAddTodoUseCase _addUseCase;

        public TodosController(IGetTodosUseCase getUseCase, IAddTodoUseCase addUseCase)
        {
            _getUseCase = getUseCase;
            _addUseCase = addUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _getUseCase.HandleAsync(new GetTodosRequest());
            return Ok(response.Todos);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTodoRequest request)
        {
            var resp = await _addUseCase.HandleAsync(request);
            return CreatedAtAction(nameof(Get), new { }, null);
        }
    }
}
