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
    
    public partial class Empleado
    {
        public Empleado()
        {
            this.Pedido = new HashSet<Pedido>();
            this.Turno_Empleado = new HashSet<Turno_Empleado>();
        }
    
        public string empleado_id { get; set; }
        public string nombre { get; set; }
        public string puesto { get; set; }
        public Nullable<decimal> salario { get; set; }
        public Nullable<System.DateTime> fecha_contratacion { get; set; }
        public string telefono { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual ICollection<Pedido> Pedido { get; set; }
        public virtual ICollection<Turno_Empleado> Turno_Empleado { get; set; }
    }
}
