using Campania.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Campania.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaniaController : ControllerBase
    {
        private ModelContext _context;
        private readonly IWebHostEnvironment _enviroment;
        public CampaniaController(ModelContext contex,IWebHostEnvironment env )
        {
            _context = contex;
            _enviroment = env;

        }

        [HttpGet]   
        public async Task<List<Campanium>> Listar()
        {
            return await _context.Campania.ToListAsync();
        }

        [HttpPost]  
        public async Task<ActionResult<Campanium>> Guardar(Campanium c)
        {
            try
            {
                await _context.Campania.AddAsync(c);
                await _context.SaveChangesAsync();
                c.Idcampania = await _context.Campania.MaxAsync(u => u.Idcampania);

                return c;

            }
            catch (DbUpdateException)
            {

                return StatusCode(500, "Se encontro un error");
            }
        }

        //[HttpPost]
        //public void PostArchivo([FromForm] IFormFile file)
        //{
        //    try
        //    {
        //        var filePath = "D:\\Prueba_DavinciX\\Campania\\Campania.WebApi" + file.FileName;
        //        using (var stream = System.IO.File.Create(filePath))
        //        {
        //            file.CopyToAsync(stream);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //[HttpPost]

        //public async Task<IActionResult>Upload(IFormFile file)
        //{
        //    var fileName = System.IO.Path.Combine(_enviroment.ContentRootPath, "upload", file.FileName);

        //    await file.CopyToAsync(
        //        new System.IO.FileStream(fileName, System.IO.FileMode.Create));

        //    return RedirectToAction("Index");

        //}





        
    }
}
