using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubadora.Domain
{
    public class CalendarizacionDomainModel
    {
        public int Id { get; set; }
        public string strAsunto { get; set; }
        public string strDescripcion { get; set; }
        public System.DateTime dteInicio { get; set; }
        public System.DateTime dteFin { get; set; }
        public string strColorTema { get; set; }
        public Nullable<bool> boolIsFullDay { get; set; }
    }
}
