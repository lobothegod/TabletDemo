using Prism.Navigation;
using Prism.Services;
using Syncfusion.Data.Extensions;
using Syncfusion.SfDataGrid.XForms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using TabletDemo.Models;

namespace TabletDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //Comandos


        //Variables de pantalla
        private GrupoConcepto _grupoConcepto;
        public GrupoConcepto GrupoConcepto
        {
            get { return _grupoConcepto; }
            set { SetProperty(ref _grupoConcepto, value); }
        }

        private DataTable _equipoConceptos;
        public DataTable EquipoConceptos
        {
            get { return _equipoConceptos; }
            set { SetProperty(ref _equipoConceptos, value); }
        }

        //Variables internas
        public ObservableCollection<GridComboBoxModelo> DatosCombo { get; set; }
        public Columns SfGridColumns { get; set; } = new Columns();

        List<EquipoConceptoTurno> lEquipoConceptoTurno;

        //Constantes
        readonly int IDGRUPOCONCEPTO = 111;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            //Comandos

            lEquipoConceptoTurno = new List<EquipoConceptoTurno>();
            DatosCombo = new ObservableCollection<GridComboBoxModelo>();
        }

        private void CrearEstructuraConDatos()
        {
            EquipoConceptos = new DataTable();
            lEquipoConceptoTurno = ObtenerDatosTurno(IDGRUPOCONCEPTO);

            //AGREGANDO COLUMNAS AL DATATABLE Y AL SFGRID
            EquipoConceptos.Columns.Add("Equipo", typeof(string));
            EquipoConceptos.Columns.Add("Molino", typeof(string));

            SfGridColumns.Add(new GridTextColumn() { MappingName = "Equipo", AllowEditing = false });
            SfGridColumns.Add(new GridTextColumn() { MappingName = "Molino", AllowEditing = false });

            foreach (var concepto in GrupoConcepto.GrupoConceptoDetalle.Where(x => x.GrupoConceptoDetalleAux01 == "G1")
                .OrderBy(o => o.SecuenciaColumna).Select(s => new { s.DescripcionEquipoConcepto }).Distinct())
            {
                var gcd = GrupoConcepto.GrupoConceptoDetalle.First(x => x.DescripcionEquipoConcepto == concepto.DescripcionEquipoConcepto); //busco el objecto para obtener sus valores
                if (gcd.CodigoTipoObjeto == CodigoTipoObjeto.COMBOBOX)
                {
                    EquipoConceptos.Columns.Add(gcd.DescripcionEquipoConcepto, typeof(string)).DefaultValue = " ";
                    DatosCombo = ObtenerDatosXNombreMetodo(gcd.ConsultaValorObjeto).ToObservableCollection();
                    SfGridColumns.Add(new GridComboBoxColumn() { MappingName = gcd.DescripcionEquipoConcepto, ItemsSource = DatosCombo, ValueMemberPath = gcd.DescripcionEquipoConcepto, DisplayMemberPath = "Descripcion", AllowEditing = true, ColumnSizer = ColumnSizer.Star, DropDownWidth = 150 });
                }
                else if (gcd.CodigoTipoObjeto == CodigoTipoObjeto.TEXTBOX)//TEXTBOX
                {
                    if (gcd.CodigoTipoValor == CodigoTipoValor.CADENA)
                    {
                        EquipoConceptos.Columns.Add(gcd.DescripcionEquipoConcepto, typeof(string)).DefaultValue = "";
                        SfGridColumns.Add(new GridTextColumn() { MappingName = gcd.DescripcionEquipoConcepto, ColumnSizer = ColumnSizer.Star });
                    }
                    else if (gcd.CodigoTipoValor == CodigoTipoValor.NUMERICO)
                    {
                        EquipoConceptos.Columns.Add(gcd.DescripcionEquipoConcepto, typeof(decimal)).DefaultValue = 0;
                        SfGridColumns.Add(new GridNumericColumn() { MappingName = gcd.DescripcionEquipoConcepto, NumberDecimalDigits = gcd.NumeroDecimales, ColumnSizer = ColumnSizer.Star });
                    }
                }
            }

            //AGREGANDO FILAS AL DATATABLE (AUTOMATICAMENTE AL SFGRID)
            var equipos = GrupoConcepto.GrupoConceptoDetalle.Where(x => x.GrupoConceptoDetalleAux01 == "G1").OrderBy(o => o.SecuenciaFila)
                .Select(s => new { IDEquipo = s.IDEquipo, CodRef01 = s.EquipoCodRef01, DescripcionEquipo = s.DescripcionEquipo }).Distinct().ToList();
            for (int r = 0; r < equipos.Count; r++)
            {
                var filaNueva = EquipoConceptos.Rows.Add();
                filaNueva["Equipo"] = equipos[r].CodRef01;
                filaNueva["Molino"] = equipos[r].DescripcionEquipo;

                //RECORRO LAS COLUMNAS DEL EQUIPO ACTUAL
                var lGrupoConceptoDetalle = GrupoConcepto.GrupoConceptoDetalle.Where(x => x.GrupoConceptoDetalleAux01 == "G1" && x.IDEquipo == equipos[r].IDEquipo).OrderBy(o => o.SecuenciaColumna).ToList();
                for (int c = 0; c < lGrupoConceptoDetalle.Count; c++)
                {
                    var ect = lEquipoConceptoTurno.First(x => x.IDEquipoConcepto == lGrupoConceptoDetalle[c].IdEquipoConcepto);
                    filaNueva[lGrupoConceptoDetalle[c].DescripcionEquipoConcepto] = ect.Valor;
                    ect.NroFila = r + 1; //comienza en la fila 1 porquee la fila 0 tiene los titulos
                    ect.NroColumna = c + 2; //comienza en la columna 2 porque la columna 0 y 1 tiene "equipo y "molino"
                    ect.EstadoEntidad = EstadosEntidad.SinCambios;
                }
            }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            GrupoConcepto = new GrupoConcepto();
            GrupoConcepto.GrupoConceptoDetalle = ObtenerGrupoConceptoDetalle(IDGRUPOCONCEPTO).ToObservableCollection();
            CrearEstructuraConDatos();
        }

        ///////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////


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
                lEquipoConceptoTurno.Add(new EquipoConceptoTurno() { IDEquipoConcepto = 12, Valor = "1" });
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
                ListaItemsCombo.Add(new GridComboBoxModelo() { Estado = "1", Descripcion = "Soltero" });
                ListaItemsCombo.Add(new GridComboBoxModelo() { Estado = "2", Descripcion = "Casado" });
                ListaItemsCombo.Add(new GridComboBoxModelo() { Estado = "3", Descripcion = "Viudo" });
                ListaItemsCombo.Add(new GridComboBoxModelo() { Estado = "4", Descripcion = "Divorciado" });
            }
            else if (nombreMetodo == "Estacion")
            {
                ListaItemsCombo.Add(new GridComboBoxModelo() { Estado = "1", Descripcion = "Primavera" });
                ListaItemsCombo.Add(new GridComboBoxModelo() { Estado = "2", Descripcion = "Verano" });
                ListaItemsCombo.Add(new GridComboBoxModelo() { Estado = "3", Descripcion = "Otoño" });
                ListaItemsCombo.Add(new GridComboBoxModelo() { Estado = "4", Descripcion = "Invierno" });
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
