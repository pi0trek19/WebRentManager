using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IHandoverDocumentFilesRepository
    {
        HandoverDocumentFile Add(HandoverDocumentFile file);
        HandoverDocumentFile GetFile(Guid id);
        List<HandoverDocumentFile> GetHandoverDocumentFiles(Guid id);
    }
}
