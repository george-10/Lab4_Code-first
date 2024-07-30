using System.Text.Json.Serialization;

namespace Lab4_Part2.Models;

public class Enrollement
{
    public int EnrollementId { get; set; }

    public int StudentId { get; set; }
    [JsonIgnore] 
    public virtual Student? Student { get; set; } = null!;

    public int CourseId { get; set; }
    [JsonIgnore] 
    public virtual Course? Course { get; set; } = null!;


}