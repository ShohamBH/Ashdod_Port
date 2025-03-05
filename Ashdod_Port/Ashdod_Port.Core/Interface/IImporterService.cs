
using Ashdod_Port.Core.DTOs;
using Ashdod_Port.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ashdod_Port.Core.Interface
{
    public interface IImporterService
    {
        public List<ImporterDTO> GetImporters();
        public Importer GetImporter(string id);
        public void AddImporter(Importer importer);
        public bool UpdateImporter(string id, Importer importer);
        public bool DeleteImporterId(string id);
        public bool DeleteImporter(Importer importer);

    }
}
