using Microsoft.EntityFrameworkCore;
using WebApiVeiculos.Data;
using WebApiVeiculos.Models;

namespace WebApiVeiculos.Repositores
{
    public class VeiculosRepository : IVeiculosRepository
    {
        public readonly WebApiVeiculosContext _context;

        public VeiculosRepository(WebApiVeiculosContext context)
        {
            _context = context;
        }

        public async Task<Veiculos> Create(Veiculos veiculo)
        {
            _context.Veiculos.Add(veiculo);
            await _context.SaveChangesAsync();
            return veiculo;

        }

        public async Task Delete(int id)
        {
            var car = await _context.Veiculos.FindAsync(id);
            _context.Veiculos.Remove(car);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Veiculos>> GetVeiculo()
        {
            return await _context.Veiculos.ToListAsync();     
        }

        public async Task<Veiculos> GetVeiculoId(int id)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(Veiculos veiculo)
        {
            _context.Entry(veiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
