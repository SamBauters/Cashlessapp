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
    public class MedewerkerController : ApiController
    {
           
        public List<Employee> Get()
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            return DAmedewerker.GetEmployee(p.Claims);
        }
        public Employee Get(int id)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            return DAmedewerker.GetEmployee(id, p.Claims);
        }

        public List<Employee> Get(string registerID)
        {
            int id = Convert.ToInt32(registerID.Substring(1, registerID.Length - 1));

            ClaimsPrincipal cp = RequestContext.Principal as ClaimsPrincipal;
            return DAmedewerker.GetEmployeesByRegister(id, cp.Claims);
        }

        public HttpResponseMessage Put(Employee emp)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            DAmedewerker.UpdateEmployee(emp, p.Claims);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public HttpResponseMessage Post(Employee emp)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            DAmedewerker.AddNewEmployee(emp, p.Claims);
            return new HttpResponseMessage(HttpStatusCode.Created);

        }
        public HttpResponseMessage Delete(int id)
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            DAmedewerker.DeleteEmployee(id, p.Claims);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}