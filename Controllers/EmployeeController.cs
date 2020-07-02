using HttpPatchExe.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HttpPatchExe.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        public ActionResult Get()
        {
            return Ok(EmployeeData.GetEmployees);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public ActionResult Create(Employee employee)
        {
            return Created("/employee", employee);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(JsonPatchDocument<Employee>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] JsonPatchDocument<Employee> patchDoc)
        {
            if (id == 0 || patchDoc == null)
            {
                return BadRequest();
            }

            var emp = EmployeeData.GetEmployees.FirstOrDefault(a => a.EmpUId == id);

            if (emp == null)
            {
                return NotFound();
            }

            patchDoc.ApplyTo(emp, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //Todo: apply patch to your DB

            return Ok(emp);
        }
    }
}
