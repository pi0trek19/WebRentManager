using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.ViewComponents
{
    [ViewComponent]
    public class FilesTableViewComponent : ViewComponent
    {
        private readonly IFileDescriptionsRepository _fileDescriptionsRepository;
        private readonly ICarFilesRepository _carFilesRepository;
        private readonly IServiceFilesRepository _serviceFilesRepository;
        private readonly ICarDamageFilesRepository _carDamageFilesRepository;
        private readonly ICarExpenseFilesRepository _carExpenseFilesRepository;
        private readonly IClientFilesRepository _clientFilesRepository;
        private readonly IHandoverDocumentFilesRepository _handoverDocumentFilesRepository;
        private readonly IRentFilesRepository _rentFilesRepository;
        private readonly IInsuranceClaimFilesRepository _insuranceClaimFilesRepository;

        public FilesTableViewComponent(IFileDescriptionsRepository fileDescriptionsRepository, ICarFilesRepository carFilesRepository, IServiceFilesRepository serviceFilesRepository, ICarDamageFilesRepository carDamageFilesRepository, ICarExpenseFilesRepository carExpenseFilesRepository, IClientFilesRepository clientFilesRepository, IHandoverDocumentFilesRepository handoverDocumentFilesRepository, IRentFilesRepository rentFilesRepository, IInsuranceClaimFilesRepository insuranceClaimFilesRepository)
        {
            _fileDescriptionsRepository = fileDescriptionsRepository;
            _carFilesRepository = carFilesRepository;
            _serviceFilesRepository = serviceFilesRepository;
            _carDamageFilesRepository = carDamageFilesRepository;
            _carExpenseFilesRepository = carExpenseFilesRepository;
            _clientFilesRepository = clientFilesRepository;
            _handoverDocumentFilesRepository = handoverDocumentFilesRepository;
            _rentFilesRepository = rentFilesRepository;
            _insuranceClaimFilesRepository = insuranceClaimFilesRepository;
        }

        public IViewComponentResult Invoke(string controllerName,string actionName, Guid id)
        {
            FilesTableViewModel model = new FilesTableViewModel(); //string musi być nazwą kontrolera
            switch (controllerName)
            {
                case "cars":
                    model.List = GetCarFiles(id);
                    break;
                case "carexpenses":
                    model.List = GetCarExpenseFiles(id);
                    break;
                case "insuranceclaims":
                    model.List = GetInsuranceClaimFiles(id);
                    break;
                case "services":
                    model.List = GetServiceFiles(id);
                    break;
                case "rents":
                    model.List = GetRentFiles(id);
                    break;
                case "clients":
                    model.List = GetClientFiles(id);
                    break;
                default:
                    model.List = null;
                    break;
            }
            model.List = model.List.OrderBy(m => m.Item1.DateAdded).ToList();
            model.Controller = controllerName;
            model.ItemId = id;
            model.Action = actionName;
            return View("Table", model);
        }
        public List<Tuple<FileDescription, string, Guid>> GetCarFiles(Guid id)
        {
            List<CarFile> carFiles = _carFilesRepository.GetCarFiles(id);
            List<Tuple<FileDescription, string, Guid>> files = new List<Tuple<FileDescription, string, Guid>>();
            foreach (var item in carFiles)
            {
                files.Add(Tuple.Create(_fileDescriptionsRepository.GetFile(item.FileDescriptionId), "",Guid.Empty));
                
            }
            //tak samo trzeba dodać dla serwisu, szkody i wydatku złożyć w jedną listę i oddać do metody 
            return files;
        }
        public List<Tuple<FileDescription, string, Guid>> GetRentFiles(Guid id)
        {
            List<RentFile> rentFiles = _rentFilesRepository.GetRentFiles(id);            
            List<Tuple<FileDescription, string, Guid>> files = new List<Tuple<FileDescription, string, Guid>>();
            foreach (var item in rentFiles)
            {
                files.Add(Tuple.Create(_fileDescriptionsRepository.GetFile(item.FileDescriptionId), "", Guid.Empty));
            }
            return files;
        }
        public List<Tuple<FileDescription, string, Guid>> GetClientFiles(Guid id)
        {
            List<ClientFile> rentFiles = _clientFilesRepository.GetClientFiles(id);
            List<Tuple<FileDescription, string, Guid>> files = new List<Tuple<FileDescription, string, Guid>>();
            foreach (var item in rentFiles)
            {
                files.Add(Tuple.Create(_fileDescriptionsRepository.GetFile(item.FileDescriptionId), "", Guid.Empty));
            }
            return files;
        }
        public List<Tuple<FileDescription, string, Guid>> GetServiceFiles(Guid id)
        {
            List<ServiceFile> rentFiles = _serviceFilesRepository.GetServiceFiles(id);
            List<Tuple<FileDescription, string, Guid>> files = new List<Tuple<FileDescription, string, Guid>>();
            foreach (var item in rentFiles)
            {
                files.Add(Tuple.Create(_fileDescriptionsRepository.GetFile(item.FileDescriptionId), "", Guid.Empty));
            }
            return files;
        }
        public List<Tuple<FileDescription, string, Guid>> GetInsuranceClaimFiles(Guid id)
        {
            List<InsuranceClaimFile> rentFiles = _insuranceClaimFilesRepository.GetInsuranceClaimFiles(id);
            List<Tuple<FileDescription, string, Guid>> files = new List<Tuple<FileDescription, string, Guid>>();
            foreach (var item in rentFiles)
            {
                files.Add(Tuple.Create(_fileDescriptionsRepository.GetFile(item.FileDescriptionId), "", Guid.Empty));
            }
            return files;
        }
        public List<Tuple<FileDescription, string, Guid>> GetHandoverDocumentFiles(Guid id)
        {
            List<HandoverDocumentFile> rentFiles = _handoverDocumentFilesRepository.GetHandoverDocumentFiles(id);
            List<Tuple<FileDescription, string, Guid>> files = new List<Tuple<FileDescription, string, Guid>>();
            foreach (var item in rentFiles)
            {
                files.Add(Tuple.Create(_fileDescriptionsRepository.GetFile(item.FileDescriptionId), "", Guid.Empty));
            }
            return files;
        }
        public List<Tuple<FileDescription, string, Guid>> GetCarExpenseFiles(Guid id)
        {
            List<CarExpenseFile> rentFiles = _carExpenseFilesRepository.GetCarExpenseFiles(id);
            List<Tuple<FileDescription, string, Guid>> files = new List<Tuple<FileDescription, string, Guid>>();
            foreach (var item in rentFiles)
            {
                files.Add(Tuple.Create(_fileDescriptionsRepository.GetFile(item.FileDescriptionId), "", Guid.Empty));
            }
            return files;
        }
    }
}
