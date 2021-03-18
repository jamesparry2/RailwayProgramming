using MySqlConnector;
namespace RopExample.DataLayer
{
    public class DatabaseContext : IDatabaseContext
    {
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection();
        }
    }
}
