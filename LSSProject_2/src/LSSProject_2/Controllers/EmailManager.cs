using SendGrid;
using SendGrid.Helpers.Mail;

namespace LSSProject_2.Controllers
{
    public class EmailManager
    {
        public async void sendEmail(string _to, string _subject, string _fromAddress, string _message, string _adLink, string _parkingAddress)
        {
            var apiKey = ""; 
            dynamic sg = new SendGridAPIClient(apiKey);

            var from = new Email(_fromAddress);
            var subject = _subject;
            var to = new Email(_to);
            var content = new Content("text/html", _message + "<p>A message from our sponsors:</p>" +
                "<img src=\"" + _adLink + "\"/>" +
                "<p>Your Nearset Parking is at: " + _parkingAddress + "</p>");
            var mail = new Mail(from, subject, to, content);

            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
        }
    }
}
