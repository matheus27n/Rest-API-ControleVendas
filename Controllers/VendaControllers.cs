using DesafioFinal.Context;
using DesafioFinal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFinal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaControllers : ControllerBase
    {
        private readonly VendaContext _context;

        public VendaControllers(VendaContext context)
        {
            _context = context;
        }

        //REGISTAR VENDA por vendedor
        [HttpPost("RegistrarVenda")]
        public IActionResult RegistrarVenda(Venda venda)
        {
            var vendedor = _context.Vendedores.Find(venda.Vendedor.Id);

            venda.Vendedor = vendedor;

           _context.Vendas.Add(venda);
           _context.SaveChanges();
          return CreatedAtAction(nameof(BuscarPorId), new { id = venda.Id }, venda);

        }


        //  Buscar Por id
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            var venda = _context.Vendedores.Find(id);
            if (venda == null)
            {
                return NotFound();
            }
          //  var vendedor = _context.Vendedores.Find(venda.Vendedor.Nome);
            return Ok(venda);
        }

        //Atualizar Venda
        [HttpPut("AtualizarStatus/{id}")]
        public IActionResult AtualizarVenda(int id)
        {
            var VendaTabela = _context.Vendas.Find(id);

            if(VendaTabela == null)
                return NotFound();

            if(VendaTabela.Status == EnumStatusVenda.AguardandoPagamento){
                VendaTabela.Status = EnumStatusVenda.PagamentoAprovado;
                _context.Update(VendaTabela);
                _context.SaveChanges();
                return Ok(VendaTabela);
            }
            else if(VendaTabela.Status == EnumStatusVenda.PagamentoAprovado){
                VendaTabela.Status = EnumStatusVenda.EnviadoParaTransportadora;
                _context.Update(VendaTabela);
                _context.SaveChanges();
                return Ok(VendaTabela);
            }
            else if(VendaTabela.Status == EnumStatusVenda.EnviadoParaTransportadora){
                VendaTabela.Status = EnumStatusVenda.EntregueAoCliente;
                _context.Update(VendaTabela);
                _context.SaveChanges();
                return Ok(VendaTabela);
            }
            else if(VendaTabela.Status == EnumStatusVenda.EntregueAoCliente){
                VendaTabela.Status = EnumStatusVenda.Entregue;
                _context.Update(VendaTabela);
                _context.SaveChanges();
                return Ok(VendaTabela);
            }
            else{
                return BadRequest();
            }
        }

        //Deletar Venda
        [HttpDelete("Venda/{id}")]
        public IActionResult DeletarVenda(int id)
        {
            var VendaTabela = _context.Vendas.Find(id);

            if(VendaTabela == null)
                return NotFound();

            _context.Vendas.Remove(VendaTabela);
            _context.SaveChanges();
            return NoContent();
        }

        //deletar venda por vendedor
        [HttpDelete("vendedor/{id}")]
        public IActionResult DeletarVendaPorVendedor(int id)
        {
            var Vendedor = _context.Vendedores.Find(id);

            if(Vendedor == null)
                return NotFound();

            _context.Vendedores.Remove(Vendedor);
            _context.SaveChanges();
            return NoContent();
        }
    }
}