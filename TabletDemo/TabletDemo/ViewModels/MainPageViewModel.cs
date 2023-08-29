using Prism.Navigation;
using Prism.Services;
using Syncfusion.Data.Extensions;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TabletDemo.Models;
using TabletDemo.Resources;
using TabletDemo.Services;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using static TabletDemo.Models.AccionesPredefinidas.ServicioOPUS;

namespace TabletDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        readonly ITabletDemoService _tabletDemoService;

        //Comandos
        public ICommand CurrentCellEndEditCommand { protected set; get; }

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
        public Columns SfGridColumns { get; set; } = new Columns();
        public StackedHeaderRowCollection SfGridStackedHeaderRows { get; set; } = new StackedHeaderRowCollection();

        List<EquipoConceptoTurno> lEquipoConceptoTurno;

        //Constantes
        readonly int IDGRUPOCONCEPTO = 111;

        public MainPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, ITabletDemoService tabletDemoService)
            : base(navigationService, pageDialogService)
        {
            DemoResource.Culture = LocalizationResourceManager.Current.CurrentCulture;
            Title = DemoResource.TitleTabletDemoPage;
            _tabletDemoService = tabletDemoService;

            //Comandos
            CurrentCellEndEditCommand = new AsyncCommand<object>(OnCurrentCellEndEdit);

            lEquipoConceptoTurno = new List<EquipoConceptoTurno>();
        }

        async Task OnCurrentCellEndEdit(object obj)
        {
            var e = obj as GridCurrentCellEndEditEventArgs;
            //var datagrid = e.OriginalSender as SfDataGrid;
            //var currentItem = datagrid.CurrentItem as DataRowView;

            if (Convert.ToString(e.OldValue) != Convert.ToString(e.NewValue))
            {
                var ect = lEquipoConceptoTurno.First(x => x.NroFila == e.RowColumnIndex.RowIndex && x.NroColumna == e.RowColumnIndex.ColumnIndex);
                ect.Valor = Convert.ToString(e.NewValue);

                if (ect.Valor == "0" || string.IsNullOrWhiteSpace(ect.Valor))
                    ect.EstadoEntidad = EstadosEntidad.Eliminar;
                else
                    ect.EstadoEntidad = EstadosEntidad.Sincronizar; //inserta o actualiza
            }
        }

        private void CrearEstructuraConDatos()
        {
            EquipoConceptos = new DataTable();
            lEquipoConceptoTurno = _tabletDemoService.ObtenerDatosTurno(IDGRUPOCONCEPTO);

            var stackedHeaderRow1 = new StackedHeaderRow();
            stackedHeaderRow1.StackedColumns.Add(new StackedColumn()
            {
                ChildColumns = "Equipo" + "," + "Molino",
                Text = "Order Details",
                MappingName = "OrderDetails",
                FontAttribute = FontAttributes.Bold,
                TextAlignment = TextAlignment.Center
            });
            stackedHeaderRow1.StackedColumns.Add(new StackedColumn()
            {
                ChildColumns = "TiempoOper" + "," + "Tonelaje" + "," + "Energia" + "," + "Estado",
                Text = "Customer Details",
                MappingName = "CustomerDetails",
                FontAttribute = FontAttributes.Bold,
                TextAlignment = TextAlignment.Center
            });

            SfGridStackedHeaderRows.Add(stackedHeaderRow1);



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
                    SfGridColumns.Add(new GridComboBoxColumn() { MappingName = gcd.DescripcionEquipoConcepto, ItemsSource = _tabletDemoService.ObtenerDatosXNombreMetodo(gcd.ConsultaValorObjeto), ValueMemberPath = "Codigo", DisplayMemberPath = "Descripcion", AllowEditing = true, ColumnSizer = ColumnSizer.Star, DropDownWidth = 150 });
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
            GrupoConcepto.GrupoConceptoDetalle = _tabletDemoService.ObtenerGrupoConceptoDetalle(IDGRUPOCONCEPTO).ToObservableCollection();
            CrearEstructuraConDatos();
        }

        ///////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////
    }
}
