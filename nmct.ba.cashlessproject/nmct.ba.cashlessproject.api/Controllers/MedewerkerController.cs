using System;
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
    public class MedewerkerController : ApiController
    {
           
         [AllowAnonymous]
        public List<Employee> Get()
        {
            ClaimsPrincipal p = RequestContext.Principal as ClaimsPrincipal;
            return DAmedewerker.GetEmployees(p.Claims);
        }

        [AllowAnonymous]
        public Employee Get(int id)
        {
            return DAmedewerker.GetEmployeeById(id);
        }

        public List<Register_Employee> Get(string rID)
        {
            int id = Convert.ToInt32(rID.Substring(1, rID.Length - 1));

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