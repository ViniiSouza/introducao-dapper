using IntroducaoDapper.Infra;
using IntroducaoDapper.Repositories;

namespace IntroducaoDapper.Security
{
    public static class DependencyResolver
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            service.AddScoped<DbSession>();
            service.AddTransient<ITarefaRepository, TarefaRepository>();
        }
    }
}
