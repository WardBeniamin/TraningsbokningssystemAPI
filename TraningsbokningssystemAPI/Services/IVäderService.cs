namespace TraningsbokningssystemAPI.Services
{
    public interface IVäderService
    {
        Task<string> HämtaVäderAsync(DateTime datum);
    }
}
