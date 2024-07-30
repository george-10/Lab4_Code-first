using Lab4_Part2.Models;
using Lab4_Part2.ViewModel;

namespace Lab4_Part2.Profiles;
using AutoMapper;
public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentViewModel>();
    }
}