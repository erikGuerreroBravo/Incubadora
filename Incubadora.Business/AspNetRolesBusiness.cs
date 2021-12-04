using Incubadora.Business.Interface;
using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.Repository.Infraestructure.Contract;
using System.Collections.Generic;
using System.Linq;
namespace Incubadora.Business
{
    public class AspNetRolesBusiness : IAspNetRolesBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AspNetRolesRepository repository;
        public AspNetRolesBusiness(IUnitOfWork _unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
            repository = new AspNetRolesRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de obtener una lista de roles
        /// </summary>
        /// <returns>lista de roles</returns>
        public List<AspNetRolesDomainModel> GetRoles()
        {
            List<AspNetRolesDomainModel> roles = null;
            roles = repository.GetAll().Select(p => new AspNetRolesDomainModel { 
               Id = p.Id,
               Name = p.Name,
               NormalizedName = p.NormalizedName,
               ConcurrencyStamp = p.ConcurrencyStamp
            }).ToList();
            return roles;
        }


    }
}
