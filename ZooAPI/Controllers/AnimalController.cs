using Microsoft.AspNetCore.Http;
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
        public ActionResult<IndexAnimalViewModel> Get(int id)
        {
            return Ok(_service.GetById(id));
        }
        [HttpPost]
        public ActionResult Post([FromBody] CreateAnimalViewModel viewModel)
        {
            _service.Create(viewModel);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] EditAnimalViewModel viewModel, int id)
        {
            _service.EditById(viewModel, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeleteById(id);
            return Ok();
        }
    }
}
