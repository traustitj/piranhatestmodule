using testmodule.Models;
using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.AspNetCore.Services;
using System;
using System.Threading.Tasks;
using testmodule.EFModels;

namespace testmodule.Controllers
{
    public class InitialController : Controller
    {
        public InitialController()
        {

        }

        [Route("/data")]
        public async Task<IActionResult> Index()
        {
            var db = new NameContext();
            db.Add<Name>(new Name
            {
                FirstName = "Trausti Thor",
                LastName = "Johannsson"
            });
            db.Add<Name>(new Name
            {
                FirstName = "Elsa Þóra",
                LastName = "Eggerstdóttir"
            });
            db.Add<Name>(new Name
            {
                FirstName = "Ósk",
                LastName = "Traustadóttir"
            });
            db.Add<Name>(new Name
            {
                FirstName = "Íris Rós",
                LastName = "Traustadóttir"
            });

            await db.SaveChangesAsync();

            return Ok();
        }
    }
}
