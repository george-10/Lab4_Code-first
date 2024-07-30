using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

namespace Lab4_Part2.Models;

public class Student
{
    public int StudentId { get; set; }

    public string name { get; set; }

    public string phoneNumber { get; set; }

    public string password { get; set; }
    
    public DateTime? birthDate { get; set; }
    [JsonIgnore] 
    public virtual ICollection<Enrollement> Enrollements { get; set; } = new List<Enrollement>();

}