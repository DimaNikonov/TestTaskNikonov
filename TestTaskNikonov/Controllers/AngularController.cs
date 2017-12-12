using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTaskNikonov.Models;

namespace TestTaskNikonov.Controllers
{
    
    [Route("api/Angular")]
    public class AngularController : Controller
    {
        private ApplicationContext db; 
        public AngularController(ApplicationContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<ApplicationForAngular> Get()
        {
            List<ApplicationForAngular> applications = new List<ApplicationForAngular>();
            var temp= db.Applications.ToList();
            foreach (var item in temp)
            {
                applications.Add(new ApplicationForAngular
                {
                    Id = item.Id,
                    Name = item.Name,
                    Size = item.Size,
                    DateUpdate = item.DateUpdate.ToShortDateString(),
                    Description = item.Description,
                    CategoryName = db.Categories.FirstOrDefault(x => x.Id == item.CategoryID).Name
                });
            }
            return applications;
        }
    }
}