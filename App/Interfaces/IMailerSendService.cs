using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.App.Interfaces
{
    public interface IMailerSendService
    {
         Task SendEmailAsync(string from, string fromName, List<string> to, List<string> toNames, string subject, string text, string html);
    }
}