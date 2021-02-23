using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            data = new List<Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }

        public void Add(Racer racer)
        {
            if (data.Count < this.Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = data.FirstOrDefault(r => r.Name == name);
            if (racer == null)
            {
                return false;
            }
            data.Remove(racer);
            return true;
        }

        public Racer GetOldestRacer()
        {
            return data.OrderByDescending(r => r.Age).FirstOrDefault();
        }

        public Racer GetRacer(string name)
        {
            Racer racer = data.FirstOrDefault(r => r.Name == name);
            return racer;
        }

        public Racer GetFastestRacer()
        {
            return data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Racers participating at {Name}: ");
            foreach (Racer racer in data)
            {
                result.AppendLine($"{racer.Name}, {racer.Age} ({racer.Country})");
            }
            return result.ToString();
        }
    }
}
