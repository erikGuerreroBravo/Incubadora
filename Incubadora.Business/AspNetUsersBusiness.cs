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
    public class AspNetUsersBusiness : IAspNetUsersBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AspNetUsersRepository repository;

        public AspNetUsersBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = new AspNetUsersRepository(this.unitOfWork);
        }
        /// <summary>
        /// Este metodo se encarga de consultar a todos los usuarios del sistema
        /// </summary>
        /// <returns>la lista de usuarios del sistema</returns>
        public List<AspNetUsersDomainModel> GetUsers()
        {
            List<AspNetUsersDomainModel> usuarios = null;
            usuarios = repository.GetAll().Select(p => new AspNetUsersDomainModel { 
             Id =p.Id,
             UserName = p.UserName,
             NormalizedUserName = p.NormalizedUserName,
             Email = p.Email,
             NormalizedEmail = p.NormalizedEmail,
             PasswordHash = p.PasswordHash,
             PhoneNumber =p.PhoneNumber
            }).ToList();
            return usuarios;
        }
    }
}
