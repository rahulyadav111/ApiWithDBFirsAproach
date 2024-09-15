using DotNetCoreApi_Practice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreApi_Practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly TestDBContext context;

        public StudentAPIController(TestDBContext context) {  //ctor 

            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudent()
        {
            var data = await context.Students.ToListAsync();
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> GetStudent(int id)
        {
            var student = await context.Students.FindAsync(id);
            if(student==null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> createStudent(Student student)
        {
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
            return Ok(student);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Student>>> UpdateStudent(int id,Student student)
        {
            if(id!=student.Id)
            {
                return BadRequest();
            }
            context.Entry(student).State=EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id, Student student)
        {
            var std = await context.Students.FindAsync(id);
            if(std==null)
            {
                return NotFound();
            }
            context.Students.Remove(std);
            await context.SaveChangesAsync();   
            return Ok();
        }




    }
}
