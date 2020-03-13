using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class MailMessagesRepository : IMailMessagesRepository
    {
        private readonly AppDbContext context;

        public MailMessagesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public MailMessage Create(MailMessage message)
        {
            context.MailMessages.Add(message);
            context.SaveChanges();
            return message;
        }

        public MailMessage Delete(MailMessage message)
        {        
            context.MailMessages.Find(message.Id).Enabled = false;
            context.SaveChanges();
            return message;
        }

        public MailMessage Edit(MailMessage messageChanges)
        {
            var message = context.MailMessages.Attach(messageChanges);
            message.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return messageChanges;
        }

        public List<MailMessage> GetAllMessages()
        {
            return context.MailMessages.Where(message => message.Enabled == true).ToList();
        }

        public MailMessage GetMailMessageByDesc(string desc)
        {
            return context.MailMessages.FirstOrDefault(message => message.Desc == desc);
        }

        public MailMessage GetMailMessageById(Guid id)
        {
            return context.MailMessages.Find(id);
        }
    }
}
