
using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;

namespace Ashdod_Port.Test
{
    public class FakeContextServies : IDataContext
    {
        public List<Container> ContainersList { get; set; }
        public List<Importer> ImportersLst { get; set; }
        public List<Supplier> SuppliersLst { get; set; }

        public FakeContextServies()
        {

            ContainersList = new List<Container>()
            {
                new Container("329","123",new DateTime(2025,10,05))
            };
            ImportersLst = new List<Importer>()
            {
                new Importer("shoham","329","fake","13",4)
            };
            SuppliersLst = new List<Supplier>();
        }
    }
}
