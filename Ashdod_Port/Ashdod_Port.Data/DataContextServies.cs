using System.Net;
using System.Security.Claims;
using System;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Core.Entities;

namespace Ashdod_Port.Data
{
    public class DataContextServies :IDataContext
    {
        public  List<Container> ContainersList { get; set; }
        public  List<Importer> ImportersLst { get; set; }
        public  List<Supplier> SuppliersLst { get; set; }

        public DataContextServies()
        {

            ContainersList = new List<Container>()
            {
                new Container("329","123",new DateTime(2025,10,05))
            };
            ImportersLst = new List<Importer>()
            {
                new Importer("shoham","329","hjk","13",4)
            };
            SuppliersLst = new List<Supplier>();
        }
    }
}
