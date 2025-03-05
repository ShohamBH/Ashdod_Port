<<<<<<< HEAD
﻿using Ashdod_Port.Core.DTOs;
using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;
=======
﻿using Ashdod_Port.Core.Interface;
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
using Ashdod_Port.Service;
using Microsoft.AspNetCore.Mvc;

using Container = Ashdod_Port.Core.Entities.Container;

<<<<<<< HEAD
namespace Ashdod_Port.Api.Controllers
=======
namespace Ashdod_Port.Controllers
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersControllers : ControllerBase
    {
<<<<<<< HEAD
      
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

=======
        private readonly IDataContext _dataContext;
        private readonly ContrainerService _contrainerService;

        public ContainersControllers(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
       
        //private static List<Container> containers = new List<Container> { };

        [HttpGet]
        public ActionResult<IEnumerable<Container>> Get()
        {
            return Ok(_dataContext.ContainersList);
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        }

        [HttpGet("{id}")]
        public ActionResult<Container> Get(int id)
        {
<<<<<<< HEAD
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
=======
            Container con = _contrainerService.GetContainer(id);
            if (con == null)
                return NotFound("Id container not found");
            return Ok(con);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Container container)
        {
            if (container.Weight <= 0)
                return BadRequest("Weight must be positive");

           _contrainerService.AddContainer(container);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Container container)
        {
            int index = _dataContext.ContainersList.FindIndex(c => c.IdNum == id);

            if (index == -1)
                return NotFound("Id container not found");
            _contrainerService.UpdateContainer(id, container,index);

            //_dataContext.ContainersList[index] = container;
            //_dataContext.ContainersList[index].IdNum = id;//שישאר ב ו ג שהיה 

            return Ok();
        }

        [HttpDelete("deleteById/{id}")]
        public ActionResult Delete(int id)
        {
            int index = _dataContext.ContainersList.FindIndex(c => c.IdNum == id);

            if (index == -1)
                return NotFound("Id container not found");
            _contrainerService.DeleteContainerId(index);
            //_dataContext.ContainersList.RemoveAt(index);
            return Ok();
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        }


        [HttpDelete]
        public ActionResult Delete([FromBody] Container container)
        {
<<<<<<< HEAD
            if (_contrainerService.DeleteContainer(container))
                return Ok();
            return NotFound("Container not found");
        }

        
=======

            //bool removed = _dataContext.ContainersList.Remove(container);

            //if (!removed)
            //    return NotFound("Container not found");


            _contrainerService.DeleteContainer(container);
            return Ok();
        }
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
    }
}