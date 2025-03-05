using Ashdod_Port.Core.DTOs;
using Ashdod_Port.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ashdod_Port.Core.Interface
{
    public interface IContrainerService
    {
        public List<ContainerDTO> GetContainers();
        public Container GetContainer(int id);
        public Task<bool>  AddContainerAsync(ContainerDTO container);
        public Task<bool> UpdateContainerAsync(int id, Container container);
        public Task<bool> DeleteContainerIdAsync(int id);
        public bool DeleteContainer(Container container);
        public List<ContainerDTO> GetContainersByImporter(string importerId);

        public List<ContainerDTO> GetContainersBySupplier(string supplierId);

    }
}
