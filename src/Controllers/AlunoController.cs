using AlunosCrudApiCSharp.Data;
using AlunosCrudApiCSharp.src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlunosCrudApiCSharp.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlunoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
            return await _context.Alunos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound(new { message = "Aluno não encontrado" });
            }
            return aluno;
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> CreateAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAluno), new { id = aluno.AlunoId }, aluno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAluno(int id, Aluno alunoAtualizado)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null) return NotFound(new { message = "Aluno não encontrado" });

            aluno.Nome = alunoAtualizado.Nome;
            aluno.Email = alunoAtualizado.Email;
            aluno.Endereco = alunoAtualizado.Endereco;
            aluno.Telefone = alunoAtualizado.Telefone;
            aluno.Documento = alunoAtualizado.Documento;
            aluno.RM = alunoAtualizado.RM;
            aluno.CursoId = alunoAtualizado.CursoId;

            await _context.SaveChangesAsync();

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null) return NotFound(new { message = "Aluno não encontrado" });

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Aluno deletado com sucesso" });
        }
    }
}
