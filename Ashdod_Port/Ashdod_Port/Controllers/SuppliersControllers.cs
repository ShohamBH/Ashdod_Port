using Ashdod_Port.Core.DTOs;
using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Service;
using Microsoft.AspNetCore.Mvc;


namespace Ashdod_Port.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersControllers : ControllerBase
    {

        private readonly ISupplierService _supplierService;

        public SuppliersControllers(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplierDTO>> Get()
        {
            return Ok(_supplierService.GetSuppliers());
        }

        [HttpGet("{id}")]
        public ActionResult<Supplier> Get(string id)
        {

            if (_supplierService.GetSupplier(id) == null)
                return NotFound("id Supplier not found");
            return Ok(_supplierService.GetSupplier(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] Supplier supplier)
        {
            _supplierService.AddSupplier(supplier);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Supplier supplier)
        {
            if (_supplierService.UpdateSupplier(id, supplier))
                return Ok();
            return NotFound("id Supplier not found");
        }

        [HttpDelete("deleteById/{id}")]
        public ActionResult DeleteById(string id)
        {
            if (_supplierService.DeleteSupplierId(id))
                return Ok();
            return NotFound("id Supplier not found");
        }



        [HttpDelete("{object}")]
        public ActionResult Delete(Supplier supplier)
        {
            if (_supplierService.DeleteSupplier(supplier))
                return Ok(); return NotFound("Supplier not found");
        }
    }
}
