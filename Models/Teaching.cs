using System.Text.Json.Serialization;

namespace Lab4_Part2.Models;

public class Teaching
{
    public int TeachingId { get; set; }

    public int CourseId { get; set; }
    [JsonIgnore] 
    public virtual Course? Course { get; set; }= null!;
    public int TeacherId { get; set; }
    [JsonIgnore] 
    public virtual Teacher? Teacher { get; set; } = null!;


}