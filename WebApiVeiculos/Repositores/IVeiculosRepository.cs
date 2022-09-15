using WebApiVeiculos.Models;

namespace WebApiVeiculos.Repositores
{
    public interface IVeiculosRepository
    {
        Task<IEnumerable<Veiculos>> GetVeiculo();
        Task<Veiculos> GetVeiculoId(int id);
        Task<Veiculos> Create(Veiculos veiculo);
        Task Update(Veiculos veiculo);
        Task Delete(int id);
    }
}
