using Lab4_Part2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Part2.Controllers;
[ApiController]
[Route("[controller]/[action]")]
[Authorize(Roles = "Teachers")]
public class TeachingController :ControllerBase
{
    private readonly UniversityDbContext _context;

    public TeachingController(UniversityDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> addTeacher([FromBody] Teaching teaching)
    {
        bool teacher_id = _context.Teachers.Any(x => x.TeacherId == teaching.TeacherId);
        bool course_id = _context.Courses.Any(x => x.CourseId == teaching.TeacherId);
        if (teacher_id && course_id)
        {
            _context.Teachings.Add(teaching);
            await _context.SaveChangesAsync();
            return Ok(teaching);
        }
        else
        {
            return BadRequest();
        }
    }
    [HttpGet]
    public async Task<IActionResult> getAllTeachings()
    {
        var res = _context.Teachings.ToList();
        return Ok(res);
    }
     
    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteTeaching(int id)
    {
        var teaching = _context.Teachings.FirstOrDefault(x => x.TeachingId == id);
        if(teaching != null)
        {
            _context.Teachings.Remove(teaching);
            await _context.SaveChangesAsync();
            return Ok(teaching);
        }
        else
        {
            return BadRequest();
        }
    }
}