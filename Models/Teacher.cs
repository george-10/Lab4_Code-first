using System.Text.Json.Serialization;

namespace Lab4_Part2.Models;

public class Teacher
{
    public int TeacherId { get; set; }

    public string name { get; set; }

    public DateTime? birthDate { get; set; }
    
    [JsonIgnore] 
    public virtual ICollection<Teaching> Teachings { get; set; } = new List<Teaching>();
    [JsonIgnore] 
    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}