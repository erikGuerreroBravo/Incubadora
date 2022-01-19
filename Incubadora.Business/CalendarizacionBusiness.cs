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
   public class CalendarizacionBusiness : ICalendarizacionBusiness
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly CalendarizacionRepository repository;

        public CalendarizacionBusiness(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = new CalendarizacionRepository(this.unitOfWork);
        }

        /// <summary>
        /// Este metodo se encarga de insertar un evento calendarizado
        /// </summary>
        /// <param name="calendarizacionDM">la entidad del tipo calendarizacion</param>
        /// <returns>un valor true/false</returns>
        public bool AddUpdateCalendarizacion(CalendarizacionDomainModel calendarizacionDM)
        {
            bool respuesta = false;
            if (calendarizacionDM != null)
            {

                Calendarizacion calendarizacion = repository.SingleOrDefault(p => p.Id == calendarizacionDM.Id);
                if (calendarizacion != null)
                {
                    calendarizacion.strAsunto = calendarizacionDM.strAsunto;
                    calendarizacion.strDescripcion = calendarizacionDM.strDescripcion;
                    calendarizacion.dteInicio = calendarizacionDM.dteInicio;
                    calendarizacion.dteFin = calendarizacionDM.dteFin;
                    calendarizacion.strColorTema = calendarizacionDM.strColorTema;
                    calendarizacion.boolIsFullDay = calendarizacionDM.boolIsFullDay;
                    
                    repository.Update(calendarizacion);
                    respuesta = true;
                }
                else
                {
                    
                    Calendarizacion calendario = new Calendarizacion 
                    {
                        strAsunto = calendarizacionDM.strAsunto,
                        strDescripcion = calendarizacionDM.strDescripcion,
                        dteInicio = calendarizacionDM.dteInicio,
                        dteFin = calendarizacionDM.dteFin,
                        strColorTema = calendarizacionDM.strColorTema,
                        boolIsFullDay = calendarizacionDM.boolIsFullDay
                   };
                    repository.Insert(calendario);
                    respuesta = true;
                }

            }
            return respuesta;
        }


        /// <summary>
        /// Este metodo se encarga de consultar todos los eventos calendarizados
        /// </summary>
        /// <returns>lista de eventos calendarizados</returns>
        public List<CalendarizacionDomainModel> GetEventos()
        {
            List<CalendarizacionDomainModel> evts = null;
            evts = repository.GetAll().Select(p => new CalendarizacionDomainModel
            {
                Id = p.Id,
                strAsunto = p.strAsunto,
                strDescripcion = p.strDescripcion,
                dteInicio = p.dteInicio,
                dteFin = p.dteFin,
                strColorTema = p.strColorTema,
                boolIsFullDay = p.boolIsFullDay
                
            }).ToList();
            return evts;
        }


    }
}
