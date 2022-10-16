using Dapper;
using IntroducaoDapper.Domain;
using IntroducaoDapper.Dto;
using IntroducaoDapper.Infra;

namespace IntroducaoDapper.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private DbSession _db;

        public TarefaRepository(DbSession db)
        {
            _db = db;
        }

        public async Task<List<Tarefa>> GetTarefasAsync()
        {
            using (var connection = _db.Connection)
            {
                string query = "SELECT * FROM Tarefas";
                List<Tarefa> tarefas = (await connection.QueryAsync<Tarefa>(query)).ToList();
                return tarefas;
            }
        }

        public async Task<Tarefa> GetTarefaByIdAsync(int id)
        {
            using (var connection = _db.Connection)
            {
                string query = "SELECT * FROM Tarefas WHERE Id = @id";
                Tarefa tarefa = await connection.QueryFirstOrDefaultAsync<Tarefa>(query, new { id });

                return tarefa;
            }
        }

        public async Task<TarefaContainer> GetTarefasEContadorAsync()
        {
            using (var connection = _db.Connection)
            {
                string query =
                    @"SELECT COUNT(*) FROM Tarefas
                    SELECT * FROM Tarefas";

                var reader = await connection.QueryMultipleAsync(query);

                return new TarefaContainer
                {
                    Contador = (await reader.ReadAsync<int>()).FirstOrDefault(),
                    Tarefas = (await reader.ReadAsync<Tarefa>()).ToList()
                };
            }
        }

        public async Task<int> SaveAsync(Tarefa novaTarefa)
        {
            using (var connection = _db.Connection)
            {
                string command = @"
                    INSERT INTO Tarefas(Descricao, IsCompleta)
                    VALUES(@Descricao, @IsCompleta)";

                var result = await connection.ExecuteAsync(command, param: novaTarefa);
                return result;
            }
        }

        public async Task<int> UpdateTarefaStatusAsync(Tarefa atualizaTarefa)
        {
            using (var connection = _db.Connection)
            {
                string command = @"
                    UPDATE Tarefas SET IsCompleta = @IsCompleta WHERE Id = @Id";

                var result = await connection.ExecuteAsync(command, param: atualizaTarefa);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = _db.Connection)
            {
                string command = @"
                    DELETE FROM Tarefas WHERE Id = @id";
                var resultado = -await connection.ExecuteAsync(command, param: new { id });
                return resultado;
            }
        }
    }
}
