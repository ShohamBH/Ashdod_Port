using Ashdod_Port.Core.Entities;

namespace Ashdod_Port.Core.Interface
{
    public interface IDataContext
    {
        List<Container> ContainersList { get; set; }
         List<Importer> ImportersLst { get; set; }
         List<Supplier> SuppliersLst { get; set; }
    }
}


