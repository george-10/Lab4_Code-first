using Lab4_Part2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Part2.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Roles = "Student")]
public class EnrollementController :ControllerBase
{
    private readonly UniversityDbContext _context;

    public EnrollementController(UniversityDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> addEnrollement([FromBody] Enrollement enrollement)
    {
        bool course_id = _context.Courses.Any(c => c.CourseId == enrollement.CourseId);
        bool student_id = _context.Students.Any(s => s.StudentId == enrollement.StudentId);
        if (course_id && student_id)
        {
            _context.Enrollements.Add(enrollement);
            await _context.SaveChangesAsync();
            return Ok(enrollement);
        }
        else
        {
            return BadRequest();
        }
    }
    [HttpGet]
    public async Task<IActionResult> getAllEnrollements()
    {
        var res = _context.Enrollements.ToList();
        return Ok(res);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteEnrollement(int id)
    {
        var enrollement = _context.Enrollements.FirstOrDefault(x => x.EnrollementId == id);
        if(enrollement != null)
        {
            _context.Enrollements.Remove(enrollement);
            await _context.SaveChangesAsync();
            return Ok(enrollement);
        }
        else
        {
            return BadRequest();
        }
    }
}