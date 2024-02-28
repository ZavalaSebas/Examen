using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistritoController : ControllerBase
    {
        private readonly IDistritoService _distritoService;

        public DistritoController(IDistritoService distritoService)
        {
            _distritoService = distritoService;
        }

        // GET: api/<DistritoController>
        [HttpGet]
        public IEnumerable<DistritoModel> Get()
        {
            return _distritoService.GetDistritos();
        }

        // GET api/<DistritoController>/5
        [HttpGet("{id}")]
        public DistritoModel Get(int id)
        {
            return _distritoService.GetById(id);
        }

        // POST api/<DistritoController>
        [HttpPost]
        public string Post([FromBody] DistritoModel distrito)
        {
            var result = _distritoService.AddDistrito(distrito);

            if (result)
            {
                return "Distrito agregado correctamente.";
            }
            return "Hubo un error al agregar el distrito.";
        }

        // PUT api/<DistritoController>
        [HttpPut]
        public string Put([FromBody] DistritoModel distrito)
        {
            var result = _distritoService.UpdateDistrito(distrito);

            if (result)
            {
                return "Distrito actualizado correctamente.";
            }
            return "Hubo un error al actualizar el distrito.";
        }

        // DELETE api/<DistritoController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var result = _distritoService.DeleteDistrito(id);

            if (result)
            {
                return "Distrito eliminado correctamente.";
            }
            return "Hubo un error al eliminar el distrito.";
        }
    }
}
