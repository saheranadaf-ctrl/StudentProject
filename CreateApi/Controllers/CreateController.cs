using CreateApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreateApi.Controllers
{

    
    [ApiController]
    [Route("api/[controller]")]
    public class CreateController : ControllerBase
    {

        private readonly StudentDataContext _dbContext;

        public CreateController(StudentDataContext dbContext)
        {
            _dbContext = dbContext;
        }

// ------------------------ CREATE METHOD -------------------------------

        [HttpPost("Create")]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                
                // Add any additional data validation logic here

                _dbContext.Students.Add(student);
                 await _dbContext.SaveChangesAsync();

                return CreatedAtAction("GetStudentById", new { id = student.StudentId }, student);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine(ex);
                //give the valid message with status code
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
