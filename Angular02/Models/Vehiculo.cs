//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Angular02.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehiculo
    {
        public long idvehiculo { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public Nullable<long> idpersona { get; set; }
    
        public virtual Persona Persona { get; set; }
    }
}
