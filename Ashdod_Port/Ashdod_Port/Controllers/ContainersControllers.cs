using Ashdod_Port.Core.DTOs;
using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Service;
using Microsoft.AspNetCore.Mvc;

using Container = Ashdod_Port.Core.Entities.Container;

namespace Ashdod_Port.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersControllers : ControllerBase
    {
      
        private readonly IContrainerService _contrainerService;

        public ContainersControllers(IContrainerService contrainerService)
        {
           _contrainerService=contrainerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContainerDTO>> Get()
        {
            List<ContainerDTO> containers = _contrainerService.GetContainers();
            if (containers == null)
            return NotFound();
            return Ok(containers);
        }

        [HttpGet("containers/get1/importerId")]

        public ActionResult<IEnumerable<Container>> Get1(string importerId)
        {
            List<ContainerDTO> containers = _contrainerService.GetContainersByImporter(importerId);
            if (containers == null)
                return NotFound();
            return Ok(containers);
        }

        [HttpGet("containers/get2/supplierId")]

        public ActionResult<IEnumerable<Container>> Get2(string supplierId)
        {
            List<ContainerDTO> containers = _contrainerService.GetContainersBySupplier(supplierId);
            if (containers == null)
                return NotFound();
            return Ok(containers);

        }

        [HttpGet("{id}")]
        public ActionResult<Container> Get(int id)
        {
            if ( _contrainerService.GetContainer(id) != null)
                return Ok(_contrainerService.GetContainer(id));
            return NotFound("Id container not found");
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContainerDTO container)
        {
           
            if (await _contrainerService.AddContainerAsync(container))
                return Ok();
            return BadRequest("Weight must be positive");
        }
      

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ContainerDTO container)
        {
            var temp = new Container
            {
                Id = container.Id,
                Weight = container.Weight,
                ImporterName = container.ImporterName,
                SupplierName = container.SupplierName,
                Status = container.Status,
            };

            if (await _contrainerService.UpdateContainerAsync(id, temp))
                return Ok();

            return NotFound("Id container not found");
        }

        [HttpDelete("deleteById/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _contrainerService.DeleteContainerIdAsync(id))
                return Ok();
            
            return NotFound("Id container not found");
        }


        [HttpDelete]
        public ActionResult Delete([FromBody] Container container)
        {
            if (_contrainerService.DeleteContainer(container))
                return Ok();
            return NotFound("Container not found");
        }

        
    }
}