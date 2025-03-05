<<<<<<< HEAD
﻿using Ashdod_Port.Core.DTOs;
using Ashdod_Port.Core.Entities;
=======
﻿using Ashdod_Port.Core.Entities;
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Service;
using Microsoft.AspNetCore.Mvc;

<<<<<<< HEAD

namespace Ashdod_Port.Api.Controllers
=======
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ashdod_Port.Controllers
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersControllers : ControllerBase
    {

<<<<<<< HEAD
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

=======
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
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        [HttpPost]
        public ActionResult Post([FromBody] Supplier supplier)
        {
            _supplierService.AddSupplier(supplier);
            return Ok();
        }

<<<<<<< HEAD
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
=======
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
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        }
    }
}
