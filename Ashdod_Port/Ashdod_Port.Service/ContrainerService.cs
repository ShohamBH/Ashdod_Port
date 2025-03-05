<<<<<<< HEAD
﻿using Ashdod_Port.Core.DTOs;
using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace Ashdod_Port.Service
{
    public class ContrainerService:IContrainerService
    {
        //private static int idCounter = 1;
        private readonly DataContextServies _dataContext;
        private readonly IMapper _mapper;

        public ContrainerService(DataContextServies dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public List<ContainerDTO> GetContainers()
        {
            var c=  _dataContext.ContainersList.Include(i => i.Supplier).Include(i => i.Importer).ToList();
            return _mapper.Map<List<ContainerDTO>>(c);
        }

        public Container GetContainer(int id)
        {
            Container con = _dataContext.ContainersList.FirstOrDefault(i=>i.Id==id);
            return con;
        }

        public List<ContainerDTO> GetContainersByImporter(string importerId)
        {
            List<Container> containers = _dataContext.ContainersList.Include(c => c.Importer).Where(p => p.Importer.Id == importerId).ToList();
            return _mapper.Map<List<ContainerDTO>>(containers); ;
        }

        public List<ContainerDTO> GetContainersBySupplier(string supplierId)
        {
            List<Container> containers = _dataContext.ContainersList.Include(c => c.Supplier).Where(p => p.Supplier.Id == supplierId).ToList();
            return _mapper.Map<List<ContainerDTO>>(containers); ;
        }

        public async Task< bool>AddContainerAsync(ContainerDTO container)
        {
            var c = _mapper.Map<Container>(container);

            if (container == null || container.Weight <= 0)
                return false;
            await _dataContext.ContainersList.AddAsync(c);
           await _dataContext.SaveChangesAsync();
            return true;
        }
       
        public async Task<bool> UpdateContainerAsync1(int id, Container container)
        {
            int index = _dataContext.ContainersList.ToList().FindIndex(c => c.Id == id);

            if (index == -1)
                return false;
       
            _dataContext.ContainersList.ToList()[index] = container;
            _dataContext.ContainersList.ToList()[index].Id = id;//שישאר ב ו ג שהיה 
            await _dataContext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateContainerAsync(int id, Container container)
        {
            int index = _dataContext.ContainersList.ToList().FindIndex(c => c.Id == id);

            var existingContainer = await _dataContext.ContainersList.FindAsync(id);

            if (existingContainer == null)
                return false;

            existingContainer.Weight = container.Weight;
            existingContainer.ImporterName = container.ImporterName;
            existingContainer.SupplierName = container.SupplierName;
            existingContainer.Status = container.Status;
            _dataContext.ContainersList.ToList()[index] = container;
            _dataContext.ContainersList.ToList()[index].Id = id;//שישאר ב ו ג שהיה 
            await _dataContext.SaveChangesAsync();
            return true;

        }

            public async Task<bool> DeleteContainerIdAsync(int id)
        {
            
            var container = await _dataContext.ContainersList.FindAsync(id);

            if (container == null)
                return false;
  
            _dataContext.ContainersList.Remove(container);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public bool DeleteContainer(Container container)
        {
            bool removed = _dataContext.ContainersList.ToList().Remove(container);
            _dataContext.SaveChanges();
            return removed;
=======
﻿using Ashdod_Port.Core.Entities;

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
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        }

    }
}
