using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface ICatCarrerasBusiness
    {
        /// <summary>
        /// Este metodo se encarga de consultar a todas las carreras del sistema
        /// </summary>
        /// <returns>la lista de carreras del sistema</returns>
        List<CatCarrerasDomainModel> GetCarreras();
        /// <summary>
        /// Este emtodos e encarga de actualizar o insertar una entidad carrera
        /// </summary>
        /// <param name="carrerasDM">la entidad carrera</param>
        /// <returns>true o false</returns>
        bool AddUpdatecarreras(CatCarrerasDomainModel carrerasDM);


    }
}
