using Refit;
using System.Threading.Tasks;

namespace Veterinario
{
    public interface iApiService
    {
        [Get("/api/cidades/{sigla}")]
        Task<string> GetCitiesAsync(string sigla);
    }
}