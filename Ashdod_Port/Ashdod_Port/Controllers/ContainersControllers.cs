using Ashdod_Port.Core.Interface;
using Ashdod_Port.Service;
using Microsoft.AspNetCore.Mvc;

using Container = Ashdod_Port.Core.Entities.Container;

namespace Ashdod_Port.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainersControllers : ControllerBase
    {
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
        }

        [HttpGet("{id}")]
        public ActionResult<Container> Get(int id)
        {
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
        }


        [HttpDelete]
        public ActionResult Delete([FromBody] Container container)
        {

            //bool removed = _dataContext.ContainersList.Remove(container);

            //if (!removed)
            //    return NotFound("Container not found");


            _contrainerService.DeleteContainer(container);
            return Ok();
        }
    }
}