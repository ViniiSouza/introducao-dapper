using IntroducaoDapper.Domain;

namespace IntroducaoDapper.Dto
{
    public class TarefaContainer
    {
        public int Contador { get; set; }

        public List<Tarefa> Tarefas { get; set; }
    }
}
