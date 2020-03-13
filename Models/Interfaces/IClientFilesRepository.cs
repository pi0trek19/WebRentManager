
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IClientFilesRepository
    {
        ClientFile Add(ClientFile file);
        ClientFile GetFile(Guid id);
        List<ClientFile> GetClientFiles(Guid id);
    }
}
