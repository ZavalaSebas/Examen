using DAL.Interfaces;
using Entities.Entities;
using System;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IDistritoDAL DistritoDAL { get; }
        private readonly ExamenContext _context;

        public UnidadDeTrabajo(ExamenContext context, IDistritoDAL distritoDAL)
        {
            _context = context;
            DistritoDAL = distritoDAL;
        }

        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
