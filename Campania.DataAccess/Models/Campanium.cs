using System;
using System.Collections.Generic;

namespace Campania.DataAccess.Models
{
    public partial class Campanium
    {
        public decimal Idcampania { get; set; }
        public decimal Codcampania { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Producto { get; set; }
        public string? Telefono { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
    }
}
