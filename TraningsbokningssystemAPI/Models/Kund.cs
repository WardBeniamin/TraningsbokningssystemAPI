namespace TraningsbokningssystemAPI.Models;

public class Kund
{
    public int Id { get; set; }
    public string Namn { get; set; } = string.Empty;
    public ICollection<Bokning>? Bokningar { get; set; }
}
