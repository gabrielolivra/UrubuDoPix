using Microsoft.EntityFrameworkCore;
using UrubuDoPix.Data;
using UrubuDoPix.Models;
using UrubuDoPix.Repositorios.Interfaces;

namespace UrubuDoPix.Repositorios
{
    public class InvestimentoRepositorio : InvestimentosPix

    {
        private readonly UrubuDoPixDBContext _dbContext;


        public InvestimentoRepositorio(UrubuDoPixDBContext UrubuDoPixDBContext) { 
        
            _dbContext= UrubuDoPixDBContext;
        }

        public async Task<PixModel> BuscarPorId(int id)
        {
            return await _dbContext.Pix.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<PixModel>> BuscarInvestimentos()
        {
            return await _dbContext.Pix.ToListAsync();
        }


        public async Task<PixModel> BuscarPorInvestimento(int Investimento)
        {
            return await _dbContext.Pix.FirstOrDefaultAsync(x => x.Investimento == Investimento);
        }

        public async Task<PixModel> AdicionarInvestimento(PixModel pix)
        {
            await _dbContext.Pix.AddAsync(pix);
            await _dbContext.SaveChangesAsync();
            return pix;
        }

        public async Task<bool> Apagar(int id)
        {
            PixModel pixPorId = await BuscarPorId(id);
            if(pixPorId == null)
            {
                throw new Exception($"O Id: {id} não foi encontrado");
             }
            _dbContext.Pix.Remove(pixPorId);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
