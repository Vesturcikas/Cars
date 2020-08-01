using Cars.Models;
using Cars.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public ActionResult<Answer> GetSortedCars(DataObject dataObject)
        {
            return _carService.SortCars(dataObject);
        }
    }
}
