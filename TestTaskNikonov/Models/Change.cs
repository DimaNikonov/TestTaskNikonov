using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskNikonov.Models
{
    public class Change
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int? IdApplication { get; set; }
        public DateTime DateChange { get; set; }
        public string Description { get; set; }

        public Application Application { get; set; }
        public User User { get; set; }
    }
}
