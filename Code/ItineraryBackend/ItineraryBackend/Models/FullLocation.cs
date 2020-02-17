using System;
namespace ItineraryBackend.Models
{
    public class FullLocation
    {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Name}||{Lat}||{Long}||{Date}";
        }
    }
}
