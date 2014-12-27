﻿using nmct.ba.cashlessproject.api.Helper;
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
    public class KassaController : ApiController
    {
        public List<RegistersKlant> Get()
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            return DAkassaMngmt.GetKassasManagement(p.Claims);
        }
        public HttpResponseMessage Put(RegistersKlant kl)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            DAkassaMngmt.UpdateAccount(kl, p.Claims);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}