using Ashdod_Port.Core.DTOs;
using Ashdod_Port.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ashdod_Port.Core.Interface
{
    public interface ISupplierService
    {
        public List<SupplierDTO> GetSuppliers();
        public Supplier GetSupplier(string id);
        public void AddSupplier(Supplier supplier);
        public bool UpdateSupplier(string id, Supplier supplier);
        public bool DeleteSupplierId(string id);
        public bool DeleteSupplier(Supplier supplier);

    }
}
