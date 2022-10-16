using System.Data;
using System.Data.SqlClient;

namespace IntroducaoDapper.Infra
{
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; set; }

        public DbSession(IConfiguration configuration)
        {
            Connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
