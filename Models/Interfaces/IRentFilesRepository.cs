using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IRentFilesRepository
    {
        RentFile Add(RentFile file);
        RentFile GetFile(Guid id);
        List<RentFile> GetRentFiles(Guid id);
    }
}
