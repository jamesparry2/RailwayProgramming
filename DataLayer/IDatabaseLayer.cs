using Microsoft.AspNetCore.Mvc;
using RopExample.ROP;
using System.Threading.Tasks;

namespace RopExample.IDataLayer
{
    public interface IDatabaseLayer
    {
        Result<T, string[]> GetRop<T>(string id);
        Result<T, string[]> InsertRop<T>(T item);
    }
}
