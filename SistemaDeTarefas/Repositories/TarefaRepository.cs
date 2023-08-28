using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositories.Interfaces;

namespace SistemaDeTarefas.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly SistemaDeTarefasDBContext _dbContext;

        public TarefaRepository(SistemaDeTarefasDBContext sistemaDeTarefasDBContext)
        {
            _dbContext = sistemaDeTarefasDBContext;
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas.ToListAsync();
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorID = await BuscarPorId(id);

            if (tarefaPorID == null)
            {
                throw new Exception($"Usuário para o ID {id} não foi encontrado.");
            }

            tarefaPorID.Name = tarefa.Name;
            tarefaPorID.Description = tarefa.Description;
            tarefaPorID.Status = tarefa.Status;
            tarefaPorID.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(tarefaPorID);
            await _dbContext.SaveChangesAsync();
            return tarefaPorID;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorID = await BuscarPorId(id);

            if (tarefaPorID == null)
            {
                throw new Exception($"Usuário para o ID {id} não foi encontrado.");
            }

            _dbContext.Tarefas.Remove(tarefaPorID);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        

        

        
    }
}
