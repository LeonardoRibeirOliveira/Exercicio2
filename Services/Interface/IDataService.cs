using Exercicio2.Models;

namespace Exercicio2.Services.Interface
{
    public interface IDataService
    {
        Task<IEnumerable<Data>> GetAll();
    }
}
