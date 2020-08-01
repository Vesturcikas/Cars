using System.Collections.Generic;


namespace Cars.Models
{
    public class DataObject
    {
        public string name { get; set; }
        public string sortType { get; set; }
        public Dictionary<string, string> cars { get; set; }
    }
}
