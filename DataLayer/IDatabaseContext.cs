using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RopExample.DataLayer
{
    public interface IDatabaseContext
    {
        MySqlConnection GetConnection();
    }
}
