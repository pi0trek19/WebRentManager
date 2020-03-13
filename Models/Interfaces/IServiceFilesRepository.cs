using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IServiceFilesRepository
    {
        ServiceFile Add(ServiceFile file);
        ServiceFile GetFile(Guid id);
        List<ServiceFile> GetServiceFiles(Guid id);
    }
}
