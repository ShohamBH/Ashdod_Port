using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Ashdod_Port.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportersControllers : ControllerBase
    {

        private readonly IDataContext _dataContext;
        private readonly ImporterService _importerService ;


        public ImportersControllers(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // private static List<Importer> importers = new List<Importer> { };

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_dataContext.ImportersLst);
        }

        // GET api/<Importers>/5
        [HttpGet("{id}")]
        public ActionResult<Importer> Get(string id)
        {
            Importer im = _importerService.GetImporter(id);
            if (im == null)
                return NotFound("id Importer not found");
            return Ok(im);
        }

        // POST api/<Importers>
        [HttpPost]
        public ActionResult Post([FromBody] Importer importer)
        {
            if (importer.Phone.Length != 10)
                return BadRequest("Phone number must be 10 digits and start with 0.");
            if(importer.Id.Length!=9)
                return BadRequest("ID must be 9 digits.");

            _importerService.AddImporter(importer);
            return Ok();
        }


        // PUT api/<Importers>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Importer importer)
        {
            int index = _dataContext.ImportersLst.FindIndex(i => i.Id == id);
            if (index == -1)
                return NotFound("Importer not found");
            _importerService.UpdateImporter(index, importer);
            return Ok();
        }

        // DELETE api/<Importers>/5
        [HttpDelete("deleteById/{id}")]
        public ActionResult Deleteid(string id)
        {
            int index = _dataContext.ImportersLst.FindIndex(i => i.Id == id);
            if (index == -1)
                return NotFound("Importer not found");
            _importerService.DeleteImporterId(index);
            return Ok();
        }
        [HttpDelete("{Object}")]
        public ActionResult Delete(Importer importer)
        {
            _importerService.DeleteContainer(importer);
            //bool removed = _dataContext.ImportersLst.Remove(importer);
            //if (!removed)
            //    return NotFound("Importer not found");
            return Ok();
        }
    }
}
