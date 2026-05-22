using AlunosCrudApiCSharp.Data;
using AlunosCrudApiCSharp.src.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlunosCrudApiCSharp.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CursoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCurso()
        {
            return await _context.Cursos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCursoById(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return NotFound(new { message = "Curso não encontrado!" });

            return curso;
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> CreateCurso(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCurso), new { id = curso.CursoId }, curso);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Curso>> UpdateCurso(int id, Curso cursoAtualizado)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return NotFound(new { message = "Curso não encontrado!" });

            curso.Nome = cursoAtualizado.Nome;
            curso.Descricao = cursoAtualizado.Descricao;

            await _context.SaveChangesAsync();

            return Ok(curso);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null) return NotFound(new { message = "Curso não encontrado!" });

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Curso removido com sucesso!" });
        }
    }
}
