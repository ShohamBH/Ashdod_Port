<<<<<<< HEAD
﻿using Ashdod_Port.Core.DTOs;
using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Net.Http.Headers;

namespace Ashdod_Port.Api.Controllers
=======
﻿using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Ashdod_Port.Controllers
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportersControllers : ControllerBase
    {

<<<<<<< HEAD
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
=======
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
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
                return BadRequest("ID must be 9 digits.");

            _importerService.AddImporter(importer);
            return Ok();
        }


<<<<<<< HEAD
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
=======
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
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        }
    }
}
