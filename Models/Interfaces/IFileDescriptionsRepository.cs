using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IFileDescriptionsRepository
    {
        FileDescription Create(FileDescription file);
        FileDescription GetFile(Guid id);
        FileDescription Delete(FileDescription file);
    }
}
