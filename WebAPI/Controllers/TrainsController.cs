using Business.Abstract;
using Core.DTOs.Train;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        ITrainService _trainService;

        public TrainsController(ITrainService trainService)
        {
            _trainService = trainService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var train = _trainService.Get(x => x.Id == id);
            return Ok(train);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var trains = _trainService.GetAll();
            return Ok(trains);
        }
        [HttpPost]
        public IActionResult Add(TrainDto dto)
        {
            Train train = new Train();
            train.Name = dto.Name;
            _trainService.Add(train);
            return Ok(train);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var train = _trainService.Get(c => c.Id == id);
                if (train == null)
                {
                    return NotFound();
                }
                _trainService.Delete(train);
                return Ok("Başarıyla silindi.");
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TrainDto dto)
        {
            var train = _trainService.Get(c => c.Id == id);
            train.Name = dto.Name;
            _trainService.Update(train);
            return Ok(train);
        }
    }
}
