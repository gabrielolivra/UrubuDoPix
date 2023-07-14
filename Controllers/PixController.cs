using Microsoft.AspNetCore.Mvc;
using UrubuDoPix.Models;
using UrubuDoPix.Repositorios.Interfaces;

namespace UrubuDoPix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PixController : ControllerBase
    {
        private readonly InvestimentosPix _investimentosPix;
        public PixController(InvestimentosPix investimentoPix)
        {
            _investimentosPix = investimentoPix;
        }

        [HttpGet]
        public async Task<ActionResult<List<PixModel>>> BuscarInvestimentos()
        {
            List<PixModel> Pix = await _investimentosPix.BuscarInvestimentos();

            return Ok(Pix);
        }

        [HttpGet("{investimento}")]
        public async Task<ActionResult<PixModel>> BuscarPorInvestimento(int investimento)
        {
            PixModel Pix = await _investimentosPix.BuscarPorInvestimento(investimento);

            return Ok(Pix);
        }

        [HttpPost]
        public async Task<ActionResult<PixModel>> AdicionarInvestimento(int investimento)
        {
            PixModel pix = new PixModel
            {
                Investimento = investimento,
                Retorno = investimento * 10
            };

            await _investimentosPix.AdicionarInvestimento(pix);
            return Ok(pix);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PixModel>> Apagar(int id)
        {
            bool apagar = await _investimentosPix.Apagar(id);
            return Ok(apagar);
        }
    }

}