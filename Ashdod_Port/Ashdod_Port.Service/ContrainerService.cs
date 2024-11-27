using Ashdod_Port.Core.Entities;

namespace Ashdod_Port.Service
{
    public class ContrainerService
    {
        private static int idCounter = 1;
        public  List<Container> GetContainers()
        {
            return _dataContext.ContainersList;
        }
        
        public Container GetContainer(int id)
        {
            return _dataContext.ContainersList.FirstOrDefault(c => c.IdNum == id);
        }

        public void AddContainer( Container container)
        {
            container.IdNum = idCounter++;
            _dataContext.ContainersList.Add(container);
        }

        public void UpdateContainer(int id,  Container container,int index)
        {
            _dataContext.ContainersList[index] = container;
            _dataContext.ContainersList[index].IdNum = id;//שישאר ב ו ג שהיה 
        }

        public void DeleteContainerId(int index)
        {
            _dataContext.ContainersList.RemoveAt(index);
        }

        public void DeleteContainer( Container container)
        {
           _dataContext.ContainersList.Remove(container);
        }

    }
}
