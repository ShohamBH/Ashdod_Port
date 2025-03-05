<<<<<<< HEAD
﻿using Ashdod_Port.Core.DTOs;
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

=======
﻿using Ashdod_Port.Core.Entities;
namespace Ashdod_Port.Service
{
    public class SupplierService
    {
        public List<string> GetSuppliers()
        {
            return _dataContext.SuppliersLst;
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        }

        public Supplier GetSupplier(string id)
        {
<<<<<<< HEAD
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
=======
            return _dataContext.SuppliersLst.FirstOrDefault(s => s.Id == id);
        }

        public void AddSupplier( Supplier supplier)
        {
            _dataContext.SuppliersLst.Add(supplier);
        }
       
        public void UpdateSupplier(string id,  Supplier supplier,int index)
        {
            _dataContext.SuppliersLst[index] = supplier;
        }
      
        public void DeleteSupplierId(int s )
        {
            //int s = _dataContext.SuppliersLst.FindIndex(s => s.Id == id);
            //if (s == -1)
            //    NotFound("id Supplier not found");
            _dataContext.SuppliersLst.RemoveAt(s);
        }
      
        public void DeleteSupplier(Supplier supplier)
        {
           _dataContext.SuppliersLst.Remove(supplier);
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        }
    }
}
