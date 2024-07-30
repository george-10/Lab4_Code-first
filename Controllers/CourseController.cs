using Lab4_Part2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Part2.Controllers;


[ApiController]
[Route("[controller]/[action]")]
[Authorize(Roles = "Teachers")]
public class CourseController :ControllerBase
{
    private readonly UniversityDbContext _context;

    public CourseController(UniversityDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<OkObjectResult> addCourse([FromBody] Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        
        return Ok(course);
    }
    
    [HttpGet]
    public async Task<IActionResult> getAllCourses()
    {
        var res = _context.Courses.ToList();
        return Ok(res);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteCourse(int id)
    {
        var course = _context.Courses.FirstOrDefault(x => x.CourseId == id);
        if(course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return Ok(course);
        }
        else
        {
            return BadRequest();
        }
    }
}