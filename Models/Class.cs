using System.Text.Json.Serialization;

namespace Lab4_Part2.Models;

public class Class
{
    public int ClassId { get; set; }
    
    public string department { get; set; }

    public DateTime time { get; set; }

    public int courseId { get; set; }
    [JsonIgnore] 
    public virtual Course? Course { get; set; }= null!;
    
    public int TeacherId { get; set; }
    [JsonIgnore] 
    public virtual Teacher? Teacher { get; set; } = null!;
}