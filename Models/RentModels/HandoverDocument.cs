using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class HandoverDocument
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid RentId { get; set; }
        public Guid ClientId { get; set; }
        public bool IsTermAccepted { get; set; }

        //wydanie
        public int StartMilage { get; set; }
        public int StartFuel { get; set; }
        public string StartNotes { get; set; }
        public bool StartManual { get; set; }
        public bool StartService { get; set; }
        public bool StartTriangle { get; set; }
        public bool StartFireEx { get; set; }
        public bool StartSpare { get; set; }
        public bool StartRepairSet { get; set; }
        public DateTime StartDate { get; set; }
        public string StartCientSignature { get; set; }
        public string StartCompanySignature { get; set; }
        //zdanie
        public int EndMilage { get; set; }
        public int EndFuel { get; set; }
        public string EndNotes { get; set; }
        public bool EndManual { get; set; }
        public bool EndService { get; set; }
        public bool EndTriangle { get; set; }
        public bool EndFireEx { get; set; }
        public bool EndSpare { get; set; }
        public bool EndRepairSet { get; set; }
        public DateTime EndDate { get; set; }
        public string EndClientSignature { get; set; }
        public string EndCompanySignature { get; set; }
        public List<HandoverDocumentFile> HandoverDocumentFiles { get; set; }
    }
}
