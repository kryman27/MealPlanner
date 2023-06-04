using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvParser
{
    public class SingleEntry
    {
        public string Product { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public double Proteins { get; set; }
        public double Energy { get; set; }

        public SingleEntry(string product, double fat, double carbs, double proteins, double energy)
        {
            Product = product;
            Fat = fat;
            Carbohydrates = carbs;
            Proteins = proteins;
            Energy = energy;
        }
    }
}
