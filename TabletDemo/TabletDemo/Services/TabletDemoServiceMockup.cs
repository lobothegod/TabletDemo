using System;
using System.Collections.Generic;
using System.Text;
using TabletDemo.Models;

namespace TabletDemo.Services
{
    public class TabletDemoServiceMockup : ITabletDemoService
    {
        public List<EquipoConceptoTurno> ObtenerDatosTurno(int IDGrupoConcepto)
        {
            var lEquipoConceptoTurno = new List<EquipoConceptoTurno>();

            if (IDGrupoConcepto == 111)
            {
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 1, Valor = "11" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 2, Valor = "22" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 3, Valor = "33" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 4, Valor = "3" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 5, Valor = "44" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 6, Valor = "55" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 7, Valor = "66" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 8, Valor = "4" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 9, Valor = "77" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 10, Valor = "88" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 11, Valor = "99" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 12, Valor = " " });
            }
            else if (IDGrupoConcepto == 222)
            {
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 1, Valor = "11" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 2, Valor = "22" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 3, Valor = "Primavera" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 4, Valor = "Casado" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 5, Valor = "44" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 6, Valor = "55" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 7, Valor = " " });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 8, Valor = "Soltero" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 9, Valor = "77" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 10, Valor = "88" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 11, Valor = "Verano" });
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 12, Valor = " " });
            }

            return lEquipoConceptoTurno;
        }

        public List<GridComboBoxModelo> ObtenerDatosXNombreMetodo(string nombreMetodo)
        {
            var ListaItemsCombo = new List<GridComboBoxModelo>();

            if (nombreMetodo == "Estado")
            {
                ListaItemsCombo.Add(new GridComboBoxModelo() { Codigo = " ", Descripcion = "--ELIGE--" });
                ListaItemsCombo.Add(new GridComboBoxModelo() { Codigo = "1", Descripcion = "Soltero" });
                ListaItemsCombo.Add(new GridComboBoxModelo() { Codigo = "2", Descripcion = "Casado" });
                ListaItemsCombo.Add(new GridComboBoxModelo() { Codigo = "3", Descripcion = "Viudo" });
                ListaItemsCombo.Add(new GridComboBoxModelo() { Codigo = "4", Descripcion = "Divorciado" });
            }
            else if (nombreMetodo == "Estacion")
            {
                ListaItemsCombo.Add(new GridComboBoxModelo() { Codigo = "1", Descripcion = "Primavera" });
                ListaItemsCombo.Add(new GridComboBoxModelo() { Codigo = "2", Descripcion = "Verano" });
                ListaItemsCombo.Add(new GridComboBoxModelo() { Codigo = "3", Descripcion = "Otoño" });
                ListaItemsCombo.Add(new GridComboBoxModelo() { Codigo = "4", Descripcion = "Invierno" });
            }

            return ListaItemsCombo;
        }

        public List<GrupoConceptoDetalle> ObtenerGrupoConceptoDetalle(int IDGrupoConcepto)
        {
            var lGrupoConceptoDetalle = new List<GrupoConceptoDetalle>();
            if (IDGrupoConcepto == 111)
            {
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 1, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 2, IDEquipo = "1", EquipoCodRef01 = "MLT1B", DescripcionEquipo = "1B", IDConcepto = "1", DescripcionEquipoConcepto = "TiempoOper", Valor = "10", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "C", NumeroDecimales = 0 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 2, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 3, IDEquipo = "1", EquipoCodRef01 = "MLT1B", DescripcionEquipo = "1B", IDConcepto = "2", DescripcionEquipoConcepto = "Tonelaje", Valor = "20", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "N", NumeroDecimales = 2 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 3, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 4, IDEquipo = "1", EquipoCodRef01 = "MLT1B", DescripcionEquipo = "1B", IDConcepto = "3", DescripcionEquipoConcepto = "Energia", Valor = "30", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "N", NumeroDecimales = 5 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 4, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 5, IDEquipo = "1", EquipoCodRef01 = "MLT1B", DescripcionEquipo = "1B", IDConcepto = "4", DescripcionEquipoConcepto = "Estado", Valor = "Casado", CodigoTipoObjeto = "COMBOBOX", ConsultaValorObjeto = "Estado", CodigoTipoValor = "N", NumeroDecimales = 0 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 5, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 2, IDEquipo = "2", EquipoCodRef01 = "MLT2C", DescripcionEquipo = "2C", IDConcepto = "1", DescripcionEquipoConcepto = "TiempoOper", Valor = "40", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "C", NumeroDecimales = 0 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 6, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 3, IDEquipo = "2", EquipoCodRef01 = "MLT2C", DescripcionEquipo = "2C", IDConcepto = "2", DescripcionEquipoConcepto = "Tonelaje", Valor = "50", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "N", NumeroDecimales = 2 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 7, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 4, IDEquipo = "2", EquipoCodRef01 = "MLT2C", DescripcionEquipo = "2C", IDConcepto = "3", DescripcionEquipoConcepto = "Energia", Valor = "60", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "N", NumeroDecimales = 5 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 8, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 5, IDEquipo = "2", EquipoCodRef01 = "MLT2C", DescripcionEquipo = "2C", IDConcepto = "4", DescripcionEquipoConcepto = "Estado", Valor = "Soltero", CodigoTipoObjeto = "COMBOBOX", ConsultaValorObjeto = "Estado", CodigoTipoValor = "N", NumeroDecimales = 0 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 9, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 2, IDEquipo = "3", EquipoCodRef01 = "MLT3C", DescripcionEquipo = "3C", IDConcepto = "1", DescripcionEquipoConcepto = "TiempoOper", Valor = "70", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "C", NumeroDecimales = 0 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 10, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 3, IDEquipo = "3", EquipoCodRef01 = "MLT3C", DescripcionEquipo = "3C", IDConcepto = "2", DescripcionEquipoConcepto = "Tonelaje", Valor = "80", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "N", NumeroDecimales = 2 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 11, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 4, IDEquipo = "3", EquipoCodRef01 = "MLT3C", DescripcionEquipo = "3C", IDConcepto = "3", DescripcionEquipoConcepto = "Energia", Valor = "90", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "N", NumeroDecimales = 5 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 12, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 5, IDEquipo = "3", EquipoCodRef01 = "MLT3C", DescripcionEquipo = "3C", IDConcepto = "4", DescripcionEquipoConcepto = "Estado", Valor = " ", CodigoTipoObjeto = "COMBOBOX", ConsultaValorObjeto = "Estado", CodigoTipoValor = "N", NumeroDecimales = 0 });
            }
            else if (IDGrupoConcepto == 222)
            {
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 1, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 2, IDEquipo = "1", EquipoCodRef01 = "MLT5B", DescripcionEquipo = "5B", IDConcepto = "1", DescripcionEquipoConcepto = "TiempoOper", Valor = "10", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "N", NumeroDecimales = 3 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 2, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 3, IDEquipo = "1", EquipoCodRef01 = "MLT5B", DescripcionEquipo = "5B", IDConcepto = "2", DescripcionEquipoConcepto = "Tonelaje", Valor = "20", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "N", NumeroDecimales = 5 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 3, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 4, IDEquipo = "1", EquipoCodRef01 = "MLT5B", DescripcionEquipo = "5B", IDConcepto = "3", DescripcionEquipoConcepto = "Estacion", Valor = "Primavera", CodigoTipoObjeto = "COMBOBOX", ConsultaValorObjeto = "Estacion", CodigoTipoValor = "N", NumeroDecimales = 0 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 4, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 5, IDEquipo = "1", EquipoCodRef01 = "MLT5B", DescripcionEquipo = "5B", IDConcepto = "4", DescripcionEquipoConcepto = "Estado", Valor = "Casado", CodigoTipoObjeto = "COMBOBOX", ConsultaValorObjeto = "Estado", CodigoTipoValor = "N", NumeroDecimales = 0 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 5, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 2, IDEquipo = "2", EquipoCodRef01 = "MLT6C", DescripcionEquipo = "6C", IDConcepto = "1", DescripcionEquipoConcepto = "TiempoOper", Valor = "40", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "N", NumeroDecimales = 3 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 6, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 3, IDEquipo = "2", EquipoCodRef01 = "MLT6C", DescripcionEquipo = "6C", IDConcepto = "2", DescripcionEquipoConcepto = "Tonelaje", Valor = "50", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "N", NumeroDecimales = 5 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 7, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 4, IDEquipo = "2", EquipoCodRef01 = "MLT6C", DescripcionEquipo = "6C", IDConcepto = "3", DescripcionEquipoConcepto = "Estacion", Valor = " ", CodigoTipoObjeto = "COMBOBOX", ConsultaValorObjeto = "Estacion", CodigoTipoValor = "N", NumeroDecimales = 0 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 8, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 5, IDEquipo = "2", EquipoCodRef01 = "MLT6C", DescripcionEquipo = "6C", IDConcepto = "4", DescripcionEquipoConcepto = "Estado", Valor = "Soltero", CodigoTipoObjeto = "COMBOBOX", ConsultaValorObjeto = "Estado", CodigoTipoValor = "N", NumeroDecimales = 0 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 9, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 2, IDEquipo = "3", EquipoCodRef01 = "MLT7C", DescripcionEquipo = "7C", IDConcepto = "1", DescripcionEquipoConcepto = "TiempoOper", Valor = "70", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "N", NumeroDecimales = 3 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 10, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 3, IDEquipo = "3", EquipoCodRef01 = "MLT7C", DescripcionEquipo = "7C", IDConcepto = "2", DescripcionEquipoConcepto = "Tonelaje", Valor = "80", CodigoTipoObjeto = "TEXTBOX", ConsultaValorObjeto = "", CodigoTipoValor = "N", NumeroDecimales = 5 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 11, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 4, IDEquipo = "3", EquipoCodRef01 = "MLT7C", DescripcionEquipo = "7C", IDConcepto = "3", DescripcionEquipoConcepto = "Estacion", Valor = "Verano", CodigoTipoObjeto = "COMBOBOX", ConsultaValorObjeto = "Estacion", CodigoTipoValor = "N", NumeroDecimales = 0 });
                lGrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IdEquipoConcepto = 12, GrupoConceptoDetalleAux01 = "G1", SecuenciaColumna = 5, IDEquipo = "3", EquipoCodRef01 = "MLT7C", DescripcionEquipo = "7C", IDConcepto = "4", DescripcionEquipoConcepto = "Estado", Valor = " ", CodigoTipoObjeto = "COMBOBOX", ConsultaValorObjeto = "Estado", CodigoTipoValor = "N", NumeroDecimales = 0 });
            }

            return lGrupoConceptoDetalle;
        }
    }
}
