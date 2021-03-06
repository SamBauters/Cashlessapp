﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using nmct.ba.cashlessproject.api.Helper;
using nmct.ba.cashlessproject.model;

namespace nmct.ba.cashlessproject.api.Controllers
{
        [Authorize]
    public class KlantController : ApiController
    {
            [AllowAnonymous]
        public List<Customers> Get()
        {
            return DAklant.GetKlanten();
        }
            [AllowAnonymous]
        public HttpResponseMessage Put(Customers kl)
        {
            DAklant.UpdateAccount(kl);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
            [AllowAnonymous]
        public HttpResponseMessage Post(Customers kl)
        {
            DAklant.AddNewCustomer(kl);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}