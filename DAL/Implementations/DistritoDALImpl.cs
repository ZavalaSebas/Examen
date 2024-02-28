using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Implementations
{
    public class DistritoDALImpl : DALGenericoImpl<Distrito>, IDistritoDAL
    {
        public DistritoDALImpl(ExamenContext context) : base(context)
        {
        }

        public IEnumerable<Distrito> GetAll()
        {
            List<Distrito> distritos = _context.Distritos.ToList();
            return distritos;
        }

        public bool Add(Distrito entity)
        {
            try
            {
                _context.Distritos.Add(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
