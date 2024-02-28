using BackEnd.Models;
using Entities.Entities;
using System.Collections.Generic;

namespace BackEnd.Services.Interfaces
{
    public interface IDistritoService
    {
        IEnumerable<DistritoModel> GetDistritos();
        DistritoModel GetById(int id);
        bool AddDistrito(DistritoModel distrito);
        bool UpdateDistrito(DistritoModel distrito);
        bool DeleteDistrito(int id);
    }
}
