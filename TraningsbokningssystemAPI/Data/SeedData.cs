using Bogus;
using TraningsbokningssystemAPI.Models;

namespace TraningsbokningssystemAPI.Data
{
    public static class SeedData
    {
        public static void Init(ApplicationDbContext context)
        {
            if (!context.Kunder.Any())
            {
                var kundFaker = new Faker<Kund>()
                    .RuleFor(k => k.Namn, f => f.Name.FullName());

                var kunder = kundFaker.Generate(10);
                context.Kunder.AddRange(kunder);
            }

            if (!context.Träningspass.Any())
            {
                var passFaker = new Faker<TräningsPass>()
                    .RuleFor(p => p.Typ, f => f.PickRandom("Gym", "Yoga", "Spinning"))
                    .RuleFor(p => p.StartTid, f => f.Date.Soon(10));

                var pass = passFaker.Generate(10);
                context.Träningspass.AddRange(pass);
            }

            context.SaveChanges();
        }
    }
}
