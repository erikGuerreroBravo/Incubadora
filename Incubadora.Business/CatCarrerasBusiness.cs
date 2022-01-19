using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business
{
    public class CatCarrerasBusiness: ICatCarrerasBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CatCarrerasRepository repository;

        public CatCarrerasBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = new CatCarrerasRepository(this.unitOfWork);
        }



        /// <summary>
        /// Este metodo se encarga de consultar a todas las carreras del sistema
        /// </summary>
        /// <returns>la lista de carreras del sistema</returns>
        public List<CatCarrerasDomainModel> GetCarreras()
        {
            List<CatCarrerasDomainModel> carreras = null;
            carreras = repository.GetAll().Select(p => new CatCarrerasDomainModel
            {
                Id= p.Id,
                StrValor = p.StrValor,
                StrDescripcion = p.StrDescripcion
            }).ToList();
            return carreras;
        }

        /// <summary>
        /// Este emtodos e encarga de actualizar o insertar una entidad carrera
        /// </summary>
        /// <param name="carrerasDM">la entidad carrera</param>
        /// <returns>true o false</returns>
        public bool AddUpdatecarreras(CatCarrerasDomainModel carrerasDM)
        {
            bool respuesta = false;
            if (carrerasDM != null)
            {

                CatCarreras carrera = repository.SingleOrDefault(p => p.Id == carrerasDM.Id);
                if (carrera != null)
                {
                    carrera.StrValor = carrerasDM.StrValor;
                    carrera.StrDescripcion = carrerasDM.StrDescripcion;
                    repository.Update(carrera);
                    respuesta = true;
                }
                else
                {
                    CatCarreras carreras = new CatCarreras { 
                      StrValor = carrerasDM.StrValor,
                      StrDescripcion = carrerasDM.StrDescripcion
                    };
                                     
                    repository.Insert(carreras);
                    respuesta = true;
                }

            }
            return respuesta;
        }


        


    }
}
