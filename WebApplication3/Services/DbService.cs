using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.DTOs;
using WebApplication2.Exceptions;
using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IDbService
{
    public Task<IEnumerable<GetPolitykResponse>> GetPolitykDetails();
    public Task<GetPolitykResponse>  CreatePolityk(CreatePolitykRequest request);

}
public class DbService(MyDbContext data) : IDbService
{
    public async Task<IEnumerable<GetPolitykResponse>> GetPolitykDetails()
    {
        return await data.Politycy.Select(p => new GetPolitykResponse
        {
            Id = p.Id,
            Imie = p.Imie,
            Nazwisko = p.Nazwisko,
            Powiedzenie = p.Powiedzenie,
            Przynaleznosci = p.Przynaleznosci.Select(e => new PrzynaleznoscResponse
            {
                Nazwa = e.Partia.Nazwa,
                Skrot = e.Partia.Skrot,
                DataZalozenia = e.Partia.DataZalozenia,
                Od = e.Od,
                Do = e.Do,
            })
        }).ToListAsync();
    }
    

    public async Task<GetPolitykResponse> CreatePolityk(CreatePolitykRequest request)
    {
        //1. pobieramy partie i sprawdzamy czy istnieją
        //2. dodac polityka do bazy
        //3. opcjonalnie dodac info o przynaleznosciach
        //4. zwroc info o utworzonym obiekcie

        List<Partia> partie = [];        
        
        if (request.Przynaleznosc != null && request.Przynaleznosc.Any())
        {
            partie = await data.Partie.Where(p => request.Przynaleznosc.Contains(p.Id)).ToListAsync();

            foreach (var id in request.Przynaleznosc)
            {
                if (partie.FirstOrDefault(p => p.Id == id) == null)
                {
                    throw new NotFoundException($"Id {id} not found");
                }
            }
            
        }

        var polityk = new Polityk
        {
            Imie = request.Imie,
            Nazwisko = request.Nazwisko,
            Powiedzenie = request.Powiedzenie,
            Przynaleznosci = partie.Select(p => new Przynaleznosc
            {
                Od = DateTime.Now,
                Partia = p,
                Do = null
            }).ToList()
        };
        
        await data.AddAsync(polityk);
        await data.SaveChangesAsync();

        return new GetPolitykResponse
        {
            Id = polityk.Id,
            Imie = polityk.Imie,
            Nazwisko = polityk.Nazwisko,
            Powiedzenie = polityk.Powiedzenie,
            Przynaleznosci = polityk.Przynaleznosci.Select(e => new PrzynaleznoscResponse
            {
                DataZalozenia = e.Partia.DataZalozenia,
                Od = e.Od,
                Do = e.Do,
                Nazwa = e.Partia.Nazwa,
                Skrot = e.Partia.Skrot,
            })
        };

    }
}