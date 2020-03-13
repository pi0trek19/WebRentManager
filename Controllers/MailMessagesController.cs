using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;
using WebRentManager.ViewModels;

namespace WebRentManager.Controllers
{
    public class MailMessagesController : Controller
    {
        private readonly IMailMessagesRepository _mailMessagesRepository;

        public MailMessagesController(IMailMessagesRepository mailMessagesRepository)
        {
            _mailMessagesRepository = mailMessagesRepository;
        }

        [HttpGet]
        public ViewResult Index()
        {
            var model = _mailMessagesRepository.GetAllMessages();
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MailMessageCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                MailMessage message = new MailMessage
                {
                    Content = model.Content,
                    Desc = model.Desc,
                    Subject = model.Subject,
                    Id = Guid.NewGuid(),
                    Enabled = true
                };
                _mailMessagesRepository.Create(message);
                return RedirectToAction("index");
            }
            return RedirectToAction("create");
        }
        [HttpGet]
        public ViewResult Edit(Guid id)
        {
            var message = _mailMessagesRepository.GetMailMessageById(id);
            MailMessageEditViewModel model = new MailMessageEditViewModel
            {
                Subject = message.Subject,
                Desc = message.Desc,
                Content = message.Content,
                Id = message.Id
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(MailMessageEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = _mailMessagesRepository.GetMailMessageById(model.Id);
                message.Desc = model.Desc;
                message.Content = model.Content;
                message.Subject = model.Subject;
                _mailMessagesRepository.Edit(message);
                return RedirectToAction("index");
            }
            return RedirectToAction("edit", new { id = model.Id });
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var message = _mailMessagesRepository.GetMailMessageById(id);
            _mailMessagesRepository.Delete(message);
            return RedirectToAction("index");
        }
    }
}
