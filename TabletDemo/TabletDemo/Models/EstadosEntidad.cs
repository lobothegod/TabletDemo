using System;
using System.Collections.Generic;
using System.Text;

namespace TabletDemo.Models
{
    public static class EstadosEntidad
    {
        public static int SinCambios { get; set; } = 0; //La entidad no requiere de ninguna accion, esta sincronizada con el servicio online.
        public static int Sincronizar { get; set; } = 1; //La entidad requiere obtener datos del servicio online.
        public static int Agregar { get; set; } = 2; //La entidad debe agregarse al servicio online.
        public static int Eliminar { get; set; } = 3; //La entidad debe eliminarse al servicio online.
    }
}
