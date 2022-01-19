using Incubadora.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Business.Interface
{
    public interface ICalendarizacionBusiness
    {
        /// <summary>
        /// Este metodo se encarga de insertar un evento calendarizado
        /// </summary>
        /// <param name="calendarizacionDM">la entidad del tipo calendarizacion</param>
        /// <returns>un valor true/false</returns>
        bool AddUpdateCalendarizacion(CalendarizacionDomainModel calendarizacionDM);
        /// <summary>
        /// Este metodo se encarga de consultar todos los eventos calendarizados
        /// </summary>
        /// <returns>lista de eventos calendarizados</returns>
        List<CalendarizacionDomainModel> GetEventos();
    }
}
