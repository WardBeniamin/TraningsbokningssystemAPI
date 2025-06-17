namespace TraningsbokningssystemAPI.Models;

public class TräningsPass
{
    public int Id { get; set; }
    public string Typ { get; set; } = string.Empty;
    public DateTime StartTid { get; set; }
    public ICollection<Bokning>? Bokningar { get; set; }
}
