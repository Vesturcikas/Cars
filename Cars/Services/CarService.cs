using Cars.Models;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Cars.Services
{
    public class CarService : ICarService
    {
        public DataObject dataObject { get; set; }
        public Answer answer { get; set; }                

        public Answer SortCars(DataObject dataObject)
        {
            this.dataObject = dataObject;
            Answer answer = new Answer();
            string carsList = CarsToString(dataObject.sortType);
            answer.result = "Hi " + dataObject.name + ", your cars:" + carsList;
            return answer;
        }

        private string CarsToString(string sType)
        {
            string carsString=null;
            List<string> carNames = new List<string>();
            SortedList<string, string> carsListByName = new SortedList<string, string>();

            foreach (var item in dataObject.cars)
            {
                carNames.Add(item.Value);
            }

            carNames.Sort();

            foreach (var item in carNames)
            {
                foreach (KeyValuePair<string, string> kvp in dataObject.cars)
                {
                    if (item == kvp.Value)
                    {
                        carsListByName.Add(kvp.Value, kvp.Key);
                    }
                }
            }

            switch (sType)
            {
                case "ASC":
                    {                        
                        for (int i = 0; i < carNames.Count; i++)
                        {
                            carsString = carsString + " {"+ carsListByName.GetValueOrDefault(carNames[i]) + "}(" + carNames[i] + ")";
                        }
                        return carsString;                        
                    };
                case "DESC":
                    {
                        for (int i = carNames.Count-1; i >= 0; i--)
                        {
                            carsString = carsString + " {" + carsListByName.GetValueOrDefault(carNames[i]) + "}(" + carNames[i] + ")";
                        }
                        return carsString;
                    };
                default: return "Nieko";                    
            }            
        }
    }
}
