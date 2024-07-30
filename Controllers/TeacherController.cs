using System.Runtime.InteropServices;
using Lab4_Part2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Part2.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Roles = "Teachers")]
public class TeacherController : ControllerBase
{
    private readonly UniversityDbContext _context;

    public TeacherController(UniversityDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> addTeacher([FromBody] Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();
        return Ok(teacher);
    }

    [HttpGet]
    public async Task<IActionResult> getAllTeachers()
    {
        var res = _context.Teachers.ToList();
        return Ok(res);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteTeacher(int id)
    {
        var teacher = _context.Teachers.FirstOrDefault(x => x.TeacherId == id);
        if(teacher != null)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return Ok(teacher);
        }
        else
        {
            return BadRequest();
        }
    }
}