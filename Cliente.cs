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
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Pedido = new HashSet<Pedido>();
            this.Resena = new HashSet<Resena>();
        }
    
        public string DNI { get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
        public Nullable<int> puntos_fidelidad { get; set; }
    
        public virtual ICollection<Pedido> Pedido { get; set; }
        public virtual ICollection<Resena> Resena { get; set; }
    }
}
