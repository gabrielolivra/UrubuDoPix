using UrubuDoPix.Models;

namespace UrubuDoPix.Repositorios.Interfaces
{
    public interface InvestimentosPix
    {
        Task<List<PixModel>> BuscarInvestimentos();
        Task<PixModel> BuscarPorId(int id);
        Task<PixModel> BuscarPorInvestimento( int Investimento);
        Task<PixModel> AdicionarInvestimento(PixModel pix);
        Task<bool> Apagar(int id);
    }
}
