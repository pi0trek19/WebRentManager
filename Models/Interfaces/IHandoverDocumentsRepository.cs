using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IHandoverDocumentsRepository
    {
        HandoverDocument Create(HandoverDocument document);
        HandoverDocument GetHandoverById(Guid id);
        HandoverDocument GetHandoverByRent(Guid id);
        HandoverDocument Update(HandoverDocument documentChanges);
    }
}
