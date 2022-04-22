using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithJSON
{
    class GameSale
    {

        private const string DEFAULT_NAME = "Name not provided";
        private const string DEFAULT_PLATFORM = "Platform not provided";
        private const string DEFAULT_DATE = "Date not provided";

        private string name;
        private string date;
        private string platform;
        private int totalCopies;
        private double totalRevenues;

        public GameSale(string name, string platform, string date,int totalCopies, double totalRevenues)
        {
            Name = name;
            Date = date;
            Platform = platform;
            TotalCopies = totalCopies;
            TotalRevenues = totalRevenues;
        }

        public string Name { get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    name = DEFAULT_NAME;
                else
                    name = value;
            }
        }
        public string Date { get => date;
            set
            {
                if (DateTime.TryParse(value, out DateTime d))
                    date = value;
                else
                    date = DEFAULT_DATE;
            }
        }
        public string Platform { get => platform;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    platform = value;
                else
                    platform = DEFAULT_PLATFORM;
            }
        }
        public int TotalCopies { get => totalCopies; 
            set
            {
                if (value >= 0)
                    totalCopies = value;
            }
                
        }
        public double TotalRevenues { get => totalRevenues;
            set
            {
                if (value >= 0)
                    totalRevenues = value;
            }
        }


        public override string ToString()
        {
            return $"{Name} {Platform} {Date} {TotalCopies} {TotalRevenues}";
        }
    }
}
