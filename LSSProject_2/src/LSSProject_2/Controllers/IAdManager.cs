using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LSSProject_2.Controllers
{
    public interface IAdManager
    {
        /// <summary>
        /// Gets an Ad image link
        /// </summary>
        /// <returns>image link as string</returns>
        string GetAdLink();
    }
}
