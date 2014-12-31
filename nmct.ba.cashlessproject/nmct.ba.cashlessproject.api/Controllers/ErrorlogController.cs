using System.Net;
using System.Net.Http;
using System.Web.Http;
using nmct.ba.cashlessproject.api.Helper;
using nmct.ba.cashlessproject.model;

namespace nmct.ba.cashlessproject.api.Controllers
{
    public class ErrorlogController : ApiController
    {
        // GET: Errorlog
        public HttpResponseMessage Post(Errorlog e)
        {
            DAerrorlog.InsertErrorlog(e);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}