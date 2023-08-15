using System;
using System.Collections.Generic;
using System.Text;

namespace TabletDemo.Models
{
    public class AccionesPredefinidas
    {
        public struct ServicioOPUS
        {
            public struct TipoProceso
            {
                public const string Asignar = "1";
                public const string Desasignar = "2";
            }

            public struct MensajeRpta
            {
                public const string Error = "0";
                public const string Existoso = "1";
                public const string YaExiste = "2";
            }

            public enum ListaSonidos
            {
                Success = 0,
                Wrong = 1
            }

            public struct EstadoPesoPiezas
            {
                public const int Incorrecto = 0; //La comparacion de información no coincide
                public const int Correcto = 1; //La información es la misma
                public const int SinValidar = 2; //Estado inicial
                public const int SinServicio = 3; //No hay conexión al servicio online (OPUS)
                public const int SinRegistro = 4; //Hubo conexión, pero no se encontró un registro para comparar
                public const int Deshabilitado = 5; //Se deshabilito la validacion de paquetes en la configuración
            }

            public struct EstadoPaquete
            {
                public const int Incorrecto = 0; //La comparacion de información no coincide
                public const int Correcto = 1; //La información es la misma
                public const int SinValidar = 2; //Estado inicial
                public const int SinServicio = 3; //No hay conexión al servicio online (OPUS)
                public const int Deshabilitado = 5; //Se deshabilito la validacion de paquetes en la configuración
            }

            public struct CodBarModoLeer
            {
                public const string KEYEVENT = "Escáner";
                public const string HARDCODED = "Pruebas";
                public const string CAMERA = "Cámara";
            }

            public enum TipoSincronizacion
            {
                PorLotes = 0,
                Todo = 1
            }

            public struct CampoTrama
            {
                public string Dummy; // Valor ficticio
                public const string NROLOTE = "L";
                public const string PAQUETE = "P";
                public const string CODIGOPRODUCCION = "COD";
                public const string CALIDAD = "CAL";
                public const string PESO = "W";
                public const string PESOLIBRAS = "WL";
                public const string UNIDADMEDIDA1 = "UM1";
                public const string UNIDADMEDIDA2 = "UM2";
                public const string FECHA = "F";
                public const string AÑO = "Y";
                public const string HORA = "H";
                public const string MAQUINADESHOJADORA = "M";
                public const string TOTALUNIDADES = "U";
            }

            public struct InterfazCodigo
            {
                public const int MobileMMYM = 62804; //mex
                public const int MobileRefILO = 64738;
                public const int MobileAlambron = 62802; //mex
                public const int MobileTDemo = 62222; //mex
            }

            public struct ModuloParametroCodigo
            {
                public const string IDProducto = "IDPRODUCTO";
                //public const string CodBarPatronInicio = "CodBarPatronInicio";
                public const string PaquetePesoNetoMin = "PAQUETEPESONETOMIN";
                public const string PaquetePesoNetoMax = "PAQUETEPESONETOMAX";
                public const string ProductoNombre = "PRODUCTONOMBRE";
                public const string RegexCodigoBarra = "REGEXCODIGOBARRA";
                public const string ValidarPaqueteAgregar = "VALIDARPAQUETEAGREGAR";
                public const string CarroNroPaquetesMax = "CARRONROPAQUETESMAX";
                public const string IDLocacion = "IDLOCACION";
            }

            public struct FormatoIdioma
            {
                public const string ESPAÑOL = "Español";
                public const string INGLES = "Inglés";
                public const string ESPAÑOL2LETRAS = "es";
                public const string INGLES2LETRAS = "en";
            }

            public struct CodigoTipoObjeto
            {
                public const string COMBOBOX = "COMBOBOX";
                public const string TEXTBOX = "TEXTBOX";
            }

            public struct CodigoTipoValor
            {
                public const string CADENA = "C";
                public const string NUMERICO = "N";
            }
        }
    }
}
