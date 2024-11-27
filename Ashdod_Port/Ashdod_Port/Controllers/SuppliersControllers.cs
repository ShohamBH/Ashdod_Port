using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ashdod_Port.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersControllers : ControllerBase
    {

        private readonly IDataContext _dataContext;
        private readonly SupplierService _supplierService;

        public SuppliersControllers(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        // private static List<Supplier> suppliers = new List<Supplier> {  };
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_dataContext.SuppliersLst);
        }

        // GET api/<Suppliers>/5
        [HttpGet("{id}")]
        public ActionResult<Supplier> Get(string id)
        {
            Supplier s = _supplierService.GetSupplier(id);
            if (s == null)
                return NotFound("id Supplier not found");
            return Ok(s);
        }

        // POST api/<Suppliers>
        [HttpPost]
        public ActionResult Post([FromBody] Supplier supplier)
        {
            _supplierService.AddSupplier(supplier);
            return Ok();
        }

        // PUT api/<Suppliers>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Supplier supplier)
        {
            int index = _dataContext.SuppliersLst.FindIndex(s => s.Id == id);
            if (index == -1)
                NotFound("id Supplier not found");
            _supplierService.UpdateSupplier(id, supplier,index);
            return Ok();
        }

        // DELETE api/<Suppliers>/5
        [HttpDelete("deleteById/{id}")]
        public ActionResult Deleteid(string id)
        {
            int s = _dataContext.SuppliersLst.FindIndex(s => s.Id == id);
            if (s == -1)
                NotFound("id Supplier not found");
            _supplierService.DeleteSupplierId(s);
            return Ok();
        }
        [HttpDelete("{object}")]
        public ActionResult Delete(Supplier supplier)
        {
            //bool removed = _dataContext.SuppliersLst.Remove(supplier);
            //if (!removed)
            //    return NotFound("Supplier not found");
            _supplierService.DeleteSupplier(supplier);
            return Ok();
        }
    }
}
