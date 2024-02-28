using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace FrontEnd.Helpers.Implementations
{
    public class DistritoHelper : IDistritoHelper
    {
        private readonly IServiceRepository _serviceRepository;

        public DistritoHelper(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public DistritoViewModel AddDistrito(DistritoViewModel distrito)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PostResponse("api/Distrito", Convertir(distrito));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }

            return distrito;
        }

        private Distrito Convertir(DistritoViewModel distrito)
        {
            return new Distrito
            {
                DistritoId = distrito.DistritoId,
                Nombre = distrito.Nombre,
            };
        }

        private DistritoViewModel Convertir(Distrito distrito)
        {
            return new DistritoViewModel
            {
                DistritoId = distrito.DistritoId,
                Nombre = distrito.Nombre,
                // Aquí no hay campo "Description"
            };
        }

        public DistritoViewModel DeleteDistrito(int id)
        {
            HttpResponseMessage responseMessage = _serviceRepository.DeleteResponse("api/Distrito/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }

            return new DistritoViewModel();
        }

        public List<DistritoViewModel> GetDistritos()
        {
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Distrito");
            List<Distrito> resultado = new List<Distrito>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Distrito>>(content);
            }
            List<DistritoViewModel> lista = new List<DistritoViewModel>();

            if (resultado != null && resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }

            return lista;
        }

        public DistritoViewModel GetDistrito(int id)
        {
            DistritoViewModel distrito = new DistritoViewModel();
            HttpResponseMessage responseMessage = _serviceRepository.GetResponse("api/Distrito/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                distrito = Convertir(JsonConvert.DeserializeObject<Distrito>(content));
            }

            return distrito;
        }

        public DistritoViewModel UpdateDistrito(DistritoViewModel distrito)
        {
            HttpResponseMessage responseMessage = _serviceRepository.PutResponse("api/Distrito", Convertir(distrito));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
            }

            return distrito;
        }
    }
}
