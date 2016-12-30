using System;
using System.Collections.Generic;

namespace LSSProject_2.Controllers
{
    public class AdManager: IAdManager
    {
        private static readonly List<string> adsList;

        static AdManager()
        {
            adsList = new List<string>
            {
                "http://i.imgur.com/mcBlL.jpg",
                "http://i.imgur.com/dXHRNPX.png",
                "http://i.imgur.com/Tg0Hm.jpg",
                "http://i.imgur.com/I5hy7Eq.jpg"
            };
        }
        public string GetAdLink()
        {
            var r = new Random();
            var i = r.Next(adsList.Count);

            return adsList[i];
        }
    }
}
