using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Services.Implementations
{
    public class DistritoService : IDistritoService
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public DistritoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public DistritoModel GetById(int id)
        {
            Distrito entity = _unidadDeTrabajo.DistritoDAL.Get(id);
            return ConvertToModel(entity);
        }

        public bool AddDistrito(DistritoModel distrito)
        {
            Distrito entity = ConvertToEntity(distrito);
            _unidadDeTrabajo.DistritoDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        public bool DeleteDistrito(int id)
        {
            Distrito entity = _unidadDeTrabajo.DistritoDAL.Get(id);
            if (entity == null)
                return false;

            _unidadDeTrabajo.DistritoDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public IEnumerable<DistritoModel> GetDistritos()
        {
            IEnumerable<Distrito> entities = _unidadDeTrabajo.DistritoDAL.GetAll();
            return entities.Select(ConvertToModel).ToList();
        }

        public bool UpdateDistrito(DistritoModel distrito)
        {
            Distrito entity = ConvertToEntity(distrito);
            _unidadDeTrabajo.DistritoDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }

        private Distrito ConvertToEntity(DistritoModel distrito)
        {
            return new Distrito
            {
                DistritoId = distrito.DistritoId,
                Nombre = distrito.Nombre
            };
        }

        private DistritoModel ConvertToModel(Distrito distrito)
        {
            return new DistritoModel
            {
                DistritoId = distrito.DistritoId,
                Nombre = distrito.Nombre
            };
        }
    }
}
