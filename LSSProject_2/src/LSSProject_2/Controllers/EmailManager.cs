using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net.Http;
using SendGrid;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace LSSProject_2.Controllers
{
    public class EmailManager
    {
        public async void sendEmail(string _to, string _subject, string _fromAddress, string _message, string _adLink, string _parkingAddress)
        {
            string apiKey = ""; 
            dynamic sg = new SendGridAPIClient(apiKey);

            Email from = new Email(_fromAddress);
            string subject = _subject;
            Email to = new Email(_to);
            Content content = new Content("text/html", _message + "<p>A message from our sponsors:</p>" +
                "<img src=\"" + _adLink + "\"/>" +
                "<p>Your Nearset Parking is at: " + _parkingAddress + "</p>");
            Mail mail = new Mail(from, subject, to, content);

            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
        }
    }
}
