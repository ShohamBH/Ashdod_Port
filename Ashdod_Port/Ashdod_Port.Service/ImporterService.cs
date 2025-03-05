using Ashdod_Port.Core.DTOs;
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
        }

        public Importer GetImporter(string id)
        {
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

        }
    }
}
