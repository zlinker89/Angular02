using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Angular02.DTO
{
    public class PersonaDTO
    {

        public long idpersona { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tdocumento { get; set; }
        public string docmento { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
    }
}