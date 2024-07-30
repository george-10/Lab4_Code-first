using System.Text.RegularExpressions;
using Lab4_Part2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;

namespace Lab4_Part2.Controllers;


[ApiController]
[Route("[controller]/[action]")]
[Authorize(Roles = "Teachers")]
public class ClassController :ControllerBase
{
    private readonly UniversityDbContext _context;

    public ClassController(UniversityDbContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> addClass([FromBody] Class cClass)
    {
        _context.Classes.Add(cClass);
        await _context.SaveChangesAsync();
        return Ok(cClass);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> getAllClasses()
    {
        var res = _context.Classes.ToList();
        return Ok(res);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteClass(int id)
    {
        var cClass = _context.Classes.FirstOrDefault(x => x.ClassId == id);
        if(cClass != null)
        {
            _context.Classes.Remove(cClass);
            await _context.SaveChangesAsync();
            return Ok(cClass);
        }
        else
        {
            return BadRequest();
        }
    }
}
