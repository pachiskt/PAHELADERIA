//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Heladeria_CRUD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tamano_Helado
    {
        public Tamano_Helado()
        {
            this.Helado = new HashSet<Helado>();
        }
    
        public string tamano_id { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> precio_adicional { get; set; }
        public string descripcion { get; set; }
    
        public virtual ICollection<Helado> Helado { get; set; }
    }
}
