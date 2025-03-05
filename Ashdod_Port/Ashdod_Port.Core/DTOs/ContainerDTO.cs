using Ashdod_Port.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ashdod_Port.Core.DTOs
{
    public class ContainerDTO
    {
        public int Id { get ; set; }
        public string ImporterName { get ; set ; }
        public string SupplierName { get ; set ; }
        public DateTime Date { get ; set; }
        public int Weight { get ;set; }
        public ContainerStatus Status { get ; set; }

    }
}
