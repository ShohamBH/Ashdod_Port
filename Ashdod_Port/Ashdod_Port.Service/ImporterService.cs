<<<<<<< HEAD
﻿using Ashdod_Port.Core.DTOs;
using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;
using Ashdod_Port.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Ashdod_Port.Service
{
    public class ImporterService:IImporterService
    {
        private readonly DataContextServies _dataContext;
        private readonly IMapper _mapper;

        public ImporterService(DataContextServies dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public List<ImporterDTO> GetImporters()
        {
             return  _mapper.Map <List < ImporterDTO >> (_dataContext.ImportersLst.ToList());
=======
﻿using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;

namespace Ashdod_Port.Service
{
    public class ImporterService
    {
        public List<string> GetImporters()
        {
            return _dataContext.ImportersLst;
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        }

        public Importer GetImporter(string id)
        {
<<<<<<< HEAD
            Importer im = _dataContext.ImportersLst.FirstOrDefault(i => i.Id == id);
            if (im == null)
                return null;
            return im;
        }

        public void AddImporter(Importer importer)
        {
            _dataContext.ImportersLst.Add(importer);
            _dataContext.SaveChanges();
            //return Ok();
        }
 
        public bool UpdateImporter(string id, Importer importer)
        {
            var temp = _dataContext.ImportersLst.FirstOrDefault(i => i.Id == id);
            if (temp == null)
                return false;

            temp.Name = importer.Name;
            temp.City = importer.City;
            temp.Phone = importer.Phone;
            temp.Password = importer.Password;
            temp.Num = importer.Num;
            temp.Containers = importer.Containers;

            _dataContext.SaveChanges();
            return true;

        }
            //public bool DeleteImporterId(string id)
            //{
            //    var importer = _dataContext.ImportersLst.Find(id);
            //    if (importer == null)
            //        return false;
            //    _dataContext.ImportersLst.Remove(importer);
            //    _dataContext.SaveChanges();
            //    return true;
            //}
            public bool DeleteImporterId(string id)
        {
            var importer = _dataContext.ImportersLst.Find(id);
            if (importer == null)
                return false;

            // Remove related records first
            var relatedContainers = _dataContext.ContainersList.Where(c => c.Importer.Id == id).ToList();
            _dataContext.ContainersList.RemoveRange(relatedContainers);

            // Now remove the importer
            _dataContext.ImportersLst.Remove(importer);
            _dataContext.SaveChanges();
            return true;
        }


        public bool DeleteImporter(Importer importer)
        {
            bool removed = _dataContext.ImportersLst.ToList().Remove(importer);
            if (!removed)
                return false;

            _dataContext.ImportersLst.Remove(importer);
            _dataContext.SaveChanges();
            return true;

=======
            //Importer im = _dataContext.ImportersLst.FirstOrDefault(i => i.Id == id);
            //if (im == null)
            //    return NotFound("id Importer not found");
            return _dataContext.ImportersLst.FirstOrDefault(i => i.Id == id);
        }

        public void AddImporter( Importer importer)
        {
            //if (importer.Phone.Length != 10)
            //    return BadRequest("Phone number must be 10 digits and start with 0.");
            //if (importer.Id.Length != 9)
            //    return BadRequest("ID must be 9 digits.");

            _dataContext.ImportersLst.Add(importer);
            //return Ok();
        }

        public void UpdateImporter(int index,  Importer importer)
        {
            _dataContext.ImportersLst[index] = importer;
        }

        public void DeleteImporterId(int index)
        {
            //int index = _dataContext.ImportersLst.FindIndex(i => i.Id == id);
            //if (index == -1)
            //    return NotFound("Importer not found");
            _dataContext.ImportersLst.RemoveAt(index);
            //return Ok();
        }
        public void DeleteContainer(Importer importer)
        {
            _dataContext.ImportersLst.Remove(importer);
            //bool removed = _dataContext.ImportersLst.Remove(importer);
            //if (!removed)
            //    return NotFound("Importer not found");
            //return Ok();
>>>>>>> 4811816a9a0098ff7f3e96c3b56f0b7a7afd2164
        }
    }
}
