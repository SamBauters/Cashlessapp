using nmct.ba.cashlessproject.api.Helper;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace nmct.ba.cashlessproject.api.Controllers
{
    [Authorize]
    public class OrganisationController : ApiController
    {
        public bool Get(string username, string password)
        {
            return DAorganisations.CheckAccount(username, password);
        }

        public HttpResponseMessage Put(Organisations o)
        {
            ClaimsPrincipal cp = RequestContext.Principal as ClaimsPrincipal;
            DAorganisations.UpdateOrganisation(o, cp.Claims);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}