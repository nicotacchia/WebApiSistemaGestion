using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace WebApiSistemaGestion.models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Productos = new HashSet<Producto>();
            Venta = new HashSet<Ventum>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public string Mail { get; set; } = null!;

        public Usuario(string nombre, string apellido, string nombreUsuario, string contraseña, string mail)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NombreUsuario = nombreUsuario;
            this.Contraseña = contraseña;
            this.Mail = mail;
        }

        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
