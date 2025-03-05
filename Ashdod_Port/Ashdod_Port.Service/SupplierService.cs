using Ashdod_Port.Core.DTOs;
using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Data;
using AutoMapper;

namespace Ashdod_Port.Service
{


    public class SupplierService:ISupplierService
    {
        private readonly DataContextServies _dataContext;
        private readonly IMapper _mapper;
        public SupplierService(DataContextServies dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public List<SupplierDTO> GetSuppliers()
        {
            return _mapper.Map<List<SupplierDTO>>(_dataContext.SuppliersLst.ToList());

        }

        public Supplier GetSupplier(string id)
        {
            Supplier s = _dataContext.SuppliersLst.FirstOrDefault(s => s.Id == id);
            return s;
        }

        public void AddSupplier(Supplier supplier)
        {
            _dataContext.SuppliersLst.Add(supplier);
            _dataContext.SaveChanges();
        }

       
        public bool UpdateSupplier(string id, Supplier supplier)
        {
            var temp = _dataContext.SuppliersLst.FirstOrDefault(i => i.Id == id);
            if (temp == null)
                return false;

            temp.Name = supplier.Name;
            temp.City = supplier.City;
            temp.Phone = supplier.Phone;
            temp.Password = supplier.Password;
            temp.Num = supplier.Num;
            temp.Containers = supplier.Containers;

            _dataContext.SaveChanges();
            return true;
        }

        public bool DeleteSupplierId(string id)
        {
            var supplier = _dataContext.SuppliersLst.Find(id);
            if (supplier == null)
                return false;

            // Remove related records first
            var containers = _dataContext.ContainersList.Where(c => c.Supplier.Id == id).ToList();
            _dataContext.ContainersList.RemoveRange(containers);

            // Now remove the supplier
            _dataContext.SuppliersLst.Remove(supplier);
            _dataContext.SaveChanges();
            return true;
        }
        public bool DeleteSupplier(Supplier supplier)
        {
            bool removed = _dataContext.SuppliersLst.ToList().Remove(supplier);
            if (!removed)
                return false;
            _dataContext.SuppliersLst.Remove(supplier);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
