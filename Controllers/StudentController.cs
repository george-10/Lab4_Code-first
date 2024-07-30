using AutoMapper;
using Lab4_Part2.Models;
using Lab4_Part2.Profiles;
using Lab4_Part2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4_Part2.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Roles = "Student")]
public class StudentController : ControllerBase
{
    private readonly UniversityDbContext _context;

    private readonly IMapper _mapper;
    
    public StudentController(UniversityDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    [HttpPost]
    public async Task<OkObjectResult> addStudent([FromBody] Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return Ok(student);
    }
    
    [HttpGet]
    public async Task<IActionResult> getAllStudents()
    {
        var listOfStudends = _context.Students.ToList();
        var res = _mapper.Map<List<StudentViewModel>>(listOfStudends); 
        return Ok(res);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteStudent(int id)
    {
        var student = _context.Students.FirstOrDefault(x => x.StudentId == id);
        if(student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }
        else
        {
            return BadRequest();
        }
    }
}