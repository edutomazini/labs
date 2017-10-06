using LlabsApplication;
using LlabsDomain;
using System.Collections.Generic;
using System.Web.Http;

namespace ManagerEmployee
{
    public class EmployeeController : ApiController
    {
        readonly AppEmployee _AppEmployee;

        public EmployeeController()
        {
            _AppEmployee = new AppEmployee();
        }

        // GET: api/Employee
        [HttpGet]
        public Result Get([FromUri]int PageNumber = 1, [FromUri]int PageSize = 10)
        {
            return _AppEmployee.List(PageNumber, PageSize);
        }

        // POST: api/Employee
        [HttpPost]
        public IHttpActionResult Post([FromBody]Employee value)
        {
            if (ModelState.IsValid)
                return Created("/api/Employee", _AppEmployee.Insert(value));
            else
                return BadRequest(ModelState);
        }

        // DELETE: api/Employee/5
        [HttpDelete]
        public int Delete(int id)
        {
            return _AppEmployee.Delete(id);
        }
    }
}
