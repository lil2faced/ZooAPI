using Microsoft.AspNetCore.Mvc;
using ZooAPI.DTO.AnimalDTO;
using ZooAPI.Services;

namespace ZooAPI.Controllers
{
    [Route("api/Animal")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalService _service;
        public AnimalController(AnimalService animalService)
        {
            _service = animalService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IndexAnimalViewModel>> Get(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpGet]
        public async Task<ActionResult<List<IndexAnimalViewModel>>> Get()
        {
            return Ok(await _service.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateAnimalViewModel viewModel)
        {
            await _service.Create(viewModel);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update([FromBody] EditAnimalViewModel viewModel, int id)
        {
            await _service.EditById(viewModel, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteById(id);
            return Ok();
        }
    }
}
