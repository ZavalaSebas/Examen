using System;
using System.Collections.Generic;
using DAL.Interfaces;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IDistritoDAL DistritoDAL { get; }
        bool Complete();
    }
}
