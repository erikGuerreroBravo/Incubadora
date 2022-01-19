using Incubadora.Domain;
using Incubadora.Repository;
using Incubadora.ViewModels;

namespace Incubadora.Infraestructure
{
    public class AutomaperWebProfile : AutoMapper.Profile
    {
        public AutomaperWebProfile()
        {
            //entidad AspNetRoles
            CreateMap<AspNetRolesDomainModel, AspNetRolesVM>();
            CreateMap<AspNetRolesVM, AspNetRolesDomainModel>();

            //entidad AspNetUsers
            CreateMap<AspNetUsersDomainModel, AspNetUsersVM>().ForMember(x=>x.AspNetRolesVM, x=>x.MapFrom(p=>p.AspNetRolesDomainModel));
            CreateMap<AspNetUsersVM, AspNetUsersDomainModel>().ForMember(x=>x.AspNetRolesDomainModel, x=>x.MapFrom(p=>p.AspNetRolesVM));

            ///catcarreras
            CreateMap<CatCarrerasDomainModel, CatCarreraVM>();
            CreateMap<CatCarreraVM, CatCarrerasDomainModel>();

            //calendarizacion
            CreateMap<CalendarizacionDomainModel, CalendarizacionVM>();//.ForMember(x=> x.dteInicio, x=> x.MapFrom(p=>p.dteInicio.ToLongDateString() ))
                //.ForMember(x=>x.dteFin, x=>x.MapFrom(p=>p.dteFin.ToLongDateString()));
            CreateMap<CalendarizacionVM, CalendarizacionDomainModel>();

        }
        public static void Run()
        {

            AutoMapper.Mapper.Initialize(a =>
            {
                a.AddProfile<AutomaperWebProfile>();
            });
        }
    }
}