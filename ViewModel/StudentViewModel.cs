using System.Text.Json.Serialization;
using Lab4_Part2.Models;

namespace Lab4_Part2.ViewModel;

public class StudentViewModel
{
    public int StudentId { get; set; }

    public string name { get; set; }

    public string phoneNumber { get; set; }
    
    public DateTime? birthDate { get; set; }
    [JsonIgnore] 
    public virtual ICollection<Enrollement> Enrollements { get; set; } = new List<Enrollement>();

}