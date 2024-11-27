using Ashdod_Port.Core.Entities;
using Ashdod_Port.Core.Interface;

namespace Ashdod_Port.Service
{
    public class ImporterService
    {
        public List<string> GetImporters()
        {
            return _dataContext.ImportersLst;
        }

        public Importer GetImporter(string id)
        {
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
        }
    }
}
