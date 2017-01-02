using LSSProject_2.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace LSSProject_2.Controllers
{
    public class EmailManager
    {
        public async void sendEmail(string _to, string _subject, string _fromAddress, string _message, string _adLink, ParkingModel _parking)
        {
            var apiKey = ""; 
            dynamic sg = new SendGridAPIClient(apiKey);

            var from = new Email(_fromAddress);
            var subject = _subject;
            var to = new Email(_to);
            var content = new Content("text/html", _message + "<p>A message from our sponsors:</p>" +
                "<img src=\"" + _adLink + "\"/>" +
                "<p>Your Nearset Parkings are at: </p>" +
                "<img src=\"" + constructMapLink(_parking) + "\"/>");
            var mail = new Mail(from, subject, to, content);

            dynamic response = await sg.client.mail.send.post(requestBody: mail.Get());
        }

        private string constructMapLink(ParkingModel parking)
        {
            var imgURL = "http://maps.googleapis.com/maps/api/staticmap?center=" + parking.center + "&zoom=13&size=700x500&maptype=roadmap";
            foreach (var p in parking.parkingList)
            {
                if(p.spaces>0)
                    imgURL = imgURL + "&markers=color:blue|label:P|" + p.latLang;
                imgURL = imgURL + "&markers=color:red|label:0|" + p.latLang;
            }
            return imgURL;
        }
    }
}
