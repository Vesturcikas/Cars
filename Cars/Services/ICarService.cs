using Cars.Models;

namespace Cars.Services
{
    public interface ICarService
    {
        Answer SortCars(DataObject dataObject);
    }
}
