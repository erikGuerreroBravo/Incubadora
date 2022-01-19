using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Incubadora.ViewModels
{
    public class CalendarizacionVM
    {
        public int Id { get; set; }
        public string strAsunto { get; set; }
        public string strDescripcion { get; set; }
        
        //public String dteInicio { get; set; }
        public System.DateTime dteInicio { get; set; }
        public System.DateTime dteFin { get; set; }
        //public String dteFin { get; set; }
        public string strColorTema { get; set; }
        public Nullable<bool> boolIsFullDay { get; set; }
    }
}