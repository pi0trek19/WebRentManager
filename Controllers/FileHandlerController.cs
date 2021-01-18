using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class FileHandlerController : Controller
    {
        private readonly IFileDescriptionsRepository _fileDescriptionsRepository;

        public FileHandlerController(IFileDescriptionsRepository fileDescriptionsRepository)
        {
            _fileDescriptionsRepository = fileDescriptionsRepository;
        }
        [HttpGet]
        public IActionResult DownloadFile(Guid id)
        {
            BackblazeAPI api = new BackblazeAPI();
            api.AutorizeAccount();
            FileDescription fileDescription = _fileDescriptionsRepository.GetFile(id);
            byte[] filebytes = api.DownloadFileById(fileDescription.BackblazeFileId);
            return File(filebytes, "application/pdf", fileDescription.FileName+fileDescription.Ext); //fileDescription.ContentType
        }
        [HttpGet]
        public ViewResult AddFile(Guid id,string controller, string action)
        {
            AddObjectFileViewModel model = new AddObjectFileViewModel
            {
                Id = id,
                Action = action,
                Controller = controller
            };
            return View(model);
        }

    }
}