namespace TraningsbokningssystemAPI.Models;

public class Bokning
{
    public int Id { get; set; }

    public int KundId { get; set; }
    public Kund? Kund { get; set; }

    public int TräningsPassId { get; set; }
    public TräningsPass? Pass { get; set; }
}
