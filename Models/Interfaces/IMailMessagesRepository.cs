using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IMailMessagesRepository
    {
        MailMessage Create(MailMessage message);
        MailMessage Edit(MailMessage messageChanges);
        MailMessage GetMailMessageById(Guid id);
        MailMessage GetMailMessageByDesc(string desc);
        List<MailMessage> GetAllMessages();
        MailMessage Delete(MailMessage message);
    }
}
