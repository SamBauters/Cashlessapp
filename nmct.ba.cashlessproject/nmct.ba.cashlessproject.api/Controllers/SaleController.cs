using nmct.ba.cashlessproject.api.Helper;
using nmct.ba.cashlessproject.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace nmct.ba.cashlessproject.api.Controllers
{
    public class SaleController : ApiController
    {
        // GET: Sale
        public List<Sales> Get()
        {
            return DAsale.GetSales();
        }

        public HttpResponseMessage Post(Sales s)
        {
            DAsale.InsertSale(s);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}