using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskNikonov.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public string Description { get; set; }
        public DateTime DateUpdate { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
