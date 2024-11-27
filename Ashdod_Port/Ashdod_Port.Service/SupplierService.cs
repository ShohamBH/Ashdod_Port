using Ashdod_Port.Core.Entities;
namespace Ashdod_Port.Service
{
    public class SupplierService
    {
        public List<string> GetSuppliers()
        {
            return _dataContext.SuppliersLst;
        }

        public Supplier GetSupplier(string id)
        {
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
        }
    }
}
