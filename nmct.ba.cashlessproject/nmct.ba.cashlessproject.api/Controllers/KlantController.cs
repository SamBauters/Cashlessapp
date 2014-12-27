using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using nmct.ba.cashlessproject.model;
using nmct.ba.cashlessproject.api.Helper;
using System.Security.Claims;

namespace nmct.ba.cashlessproject.api.Controllers
{
        [Authorize]
    public class KlantController : ApiController
    {
        public List<Customers> Get()
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            return DAklant.GetKlanten(p.Claims);
        }
        public HttpResponseMessage Put(Customers kl)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            DAklant.UpdateAccount(kl, p.Claims);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
            [AllowAnonymous]
        public HttpResponseMessage Post(Customers kl)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            DAklant.AddNewCustomer(kl, p.Claims);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}