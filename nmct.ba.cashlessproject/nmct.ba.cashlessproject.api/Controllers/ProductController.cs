using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using nmct.ba.cashlessproject.api.Helper;
using nmct.ba.cashlessproject.model;

namespace nmct.ba.cashlessproject.api.Controllers
{
     [Authorize]
    public class ProductController : ApiController
    {
         [AllowAnonymous]
        public List<Products> Get()
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            return DAproduct.GetProducts(p.Claims);
        }
        public HttpResponseMessage Put(Products product)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            DAproduct.UpdateProduct(product, p.Claims);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
         [AllowAnonymous]
        public Products Get(int id)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            return DAproduct.GetProducts(id, p.Claims);
        }
        public HttpResponseMessage Delete(int id)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            DAproduct.DeleteProduct(id, p.Claims);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        public HttpResponseMessage Post(Products product)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            DAproduct.AddNewProduct(product, p.Claims);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

    }
}
