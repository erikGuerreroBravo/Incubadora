using Incubadora.Domain;
using System.Collections.Generic;

namespace Incubadora.Business.Interface
{
    public interface IAspNetRolesBusiness
    {
        /// <summary>
        /// Este metodo se encarga de obtener una lista de roles
        /// </summary>
        /// <returns>lista de roles</returns>
        List<AspNetRolesDomainModel> GetRoles();
    }
}
