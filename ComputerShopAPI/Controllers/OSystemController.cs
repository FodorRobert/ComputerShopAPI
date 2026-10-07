using ComputerShopAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComputerShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OSystemController : ControllerBase
    {
        public CMPShopDbContext context = new CMPShopDbContext();

        [HttpGet("getAll")]
        public object GetOSystem()
        {
            var users = context.Osystems.ToList();

            return new { message = "Sikeres lekérdezés", result = "" };
        }

        [HttpPost]
        public object AddNewOsystem(AddNewOSystemDTO addNewOSystem)
        {
            var osystem = new Osystem
            {
                Id = Guid.NewGuid(),
                Name = addNewOSystem.Name,
                Version = addNewOSystem.version,
                RegisterTime = DateTime.Now,
                UpdateTime = DateTime.Now
            };

            context.Osystems.Add(osystem);
            context.SaveChanges();

            return StatusCode(201, new { message = "Sikeres hozzáadás", result = osystem });
        }

        [HttpPut]
        public object UpdateOsystem([FromQuery] Guid id, [FromBody] AddNewOSystemDTO updateOSystem)
        {
            var osystem = context.Osystems.FirstOrDefault(o => o.Id == id);
            if (osystem == null)
            {
                osystem.Name = updateOSystem.Name;
                osystem.Version = updateOSystem.version;
                osystem.UpdateTime = DateTime.Now;

                context.Osystems.Update(osystem);
                context.SaveChanges();

                return StatusCode(200, new { message = "Sikeres frissítés", result = osystem });
            }
            return StatusCode(404, new
            {
                message = "Nem található a rendszer",
                result = ""
            });
        }

        [HttpDelete]
        public object DeleteOsystem([FromQuery] Guid id)
        {
            var osystem = context.Osystems.Find(id);
            if (osystem != null)
            {
                context.Osystems.Remove(osystem);
                context.SaveChanges();
                return StatusCode(200, new { message = "Sikeres törlés", result = osystem });
            }
            return StatusCode(404, new { message = "Nem található a rendszer", result = "" });

        }
    }
}
