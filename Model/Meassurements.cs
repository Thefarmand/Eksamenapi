using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eksamen19122018.Model
{
    public class Meassurements
    {
        //public int _id { get; set; }
        //public double _pressure { get; set; }
        //public double _humidity { get; set; }
        //public double _temperature { get; set; }
        //public DateTime _timestamp { get; set; }

        private int _id;
        private double _pressure;
        private double _humidity;
        private double _temperature;
        private DateTime _timestamp;

        public Meassurements(int id, double pressure, double humidity, double temperature, DateTime timestamp)
        {
            _id = id;
            _pressure = pressure;
            _humidity = humidity;
            _timestamp = timestamp;
            _temperature = temperature;
        }

        public Meassurements()
        {
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public double Pressure
        {
            get => _pressure;
            set => _pressure = value;
        }

        public double Humidity
        {
            get => _humidity;
            set => _humidity = value;
        }

        public double Temperature
        {
            get => _temperature;
            set => _temperature = value;
        }

        public DateTime Timestamp
        {
            get => _timestamp;
            set => _timestamp = value;
        }

        public override string ToString()
        {
            return ($"{nameof(Id)}:{Id}, {nameof(Pressure)}:{Pressure}, {nameof(Humidity)}:{Humidity}, {nameof(Temperature)}:{Temperature}, {nameof(Timestamp)}:{Timestamp}");
        }
    }
}
