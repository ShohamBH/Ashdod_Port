using Ashdod_Port.Core.DTOs;
using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace Ashdod_Port.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportersControllers : ControllerBase
    {

        private readonly IImporterService _importerService;

        public ImportersControllers(IImporterService importerService)
        {
            _importerService = importerService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ImporterDTO>> Get()
        {
            return Ok(_importerService.GetImporters());
        }

        
        [HttpGet("{id}")]
        public ActionResult<Importer> Get(string id)
        {
            if (_importerService.GetImporter(id) == null)
                return NotFound("id Importer not found");
            return Ok(_importerService.GetImporter(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Importer importer)
        {
           
            if (importer.Phone.Length != 10)
                return BadRequest("Phone number must be 10 digits and start with 0.");
            if (importer.Id.Length != 9)
                return BadRequest("ID must be 9 digits.");

            _importerService.AddImporter(importer);
            return Ok();
        }


        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Importer importer)
        {
            var temp = new Importer
            {
                Id = importer.Id,
                Name = importer.Name,
                City = importer.City,
                Phone = importer.Phone,
                Password = importer.Password,
                Num = importer.Num,
                Containers = importer.Containers,
            };
            if (_importerService.UpdateImporter(id, temp))
                return Ok();
            return NotFound("Importer not found");
        }

      
        [HttpDelete("deleteById/{id}")]
        public ActionResult DeleteById(string id)
        {
            if (_importerService.DeleteImporterId(id))
                return Ok();
            return NotFound("Importer not found");
        }

        [HttpDelete("{Object}")]
        public ActionResult Delete(Importer importer)
        {
            if (_importerService.DeleteImporter(importer))
                return Ok();
            return NotFound("Importer not found");
        }
    }
}
