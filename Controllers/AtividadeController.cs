using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using atividadeApi.Models.Dtos;
using atividadeApi.Models;

namespace atividadeApi.Controllers
{
    [Route("/Atividade")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        // Lista de atividades (simulação de banco em memória)
        private static List<Atividade> _ListaAtividade = new List<Atividade>
        {
            new Atividade()
            {
                Id = 1,
                Descricao = "atividade 1",
                DataAbertura = new DateTime(2025, 09, 03),
                DataFechamento = new DateTime(2025, 09, 11)
            }
        };

        // Controle de IDs
        private static int _proximoId = 3;

        // Buscar todas as atividades
        [HttpGet("{Mostrar Atividade}")]
        public IActionResult BuscarTodos()
        {
            return Ok(_ListaAtividade);
        }

        // Buscar atividade por ID
        [HttpGet("{Buscar atividade por ID}")]
        public IActionResult BuscarPorId(int id)
        {
            var chamado = _ListaAtividade.FirstOrDefault(x => x.Id == id);

            if (chamado == null)
            {
                return NotFound();
            }

            return Ok(chamado);
        }

        // Criar nova atividade
        [HttpPost("{Criar nova atividade}")]
        public IActionResult Criar([FromBody] atividadeDto novoChamado)
        {
            var chamado = new Atividade() { Descricao = novoChamado.Descricao };

            chamado.Id = _proximoId++;
            _ListaAtividade.Add(chamado);

            return Created("", chamado);
        }

        // Atualizar atividade
        [HttpPut("{Atualizar atividade}")]
        public IActionResult Atulizacao(int id, [FromBody] atividadeDto novaAtividade)
        {
            var atividade = _ListaAtividade.FirstOrDefault(item => item.Id == id);

            if (atividade == null)
            {
                return NotFound();
            }

            atividade.Descricao = novaAtividade.Descricao;
            return Ok(atividade);
        }

        // Atualizar status da atividade
        [HttpPut("{id}/status")]
        public IActionResult AtulizarStatus(int id, [FromBody] Atividade Atividade)
        {
            var atividade = _ListaAtividade.FirstOrDefault(item => item.Id == id);

            if (atividade == null)
            {
                return NotFound();
            }

            atividade.Status = Atividade.Status;
            return Ok(atividade.Status);
        }

        // Finalizar atividade
        [HttpPost("{id}/Finalizar")]
        public IActionResult FinalizarChamado(int id)
        {
            var atividade = _ListaAtividade.FirstOrDefault(x => x.Id == id);

            if (atividade == null)
            {
                return NotFound();
            }

            atividade.Status = "Finalizado";
            return Ok(atividade.Status);
        }

        // Remover atividade
        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var atividade = _ListaAtividade.FirstOrDefault(x => x.Id == id);

            if (atividade == null)
            {
                return NotFound();
            }

            _ListaAtividade.Remove(atividade);
            return NoContent();
        }
    }
}
