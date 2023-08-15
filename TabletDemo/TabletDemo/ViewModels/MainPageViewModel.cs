using Prism.Navigation;
using Syncfusion.Data.Extensions;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using TabletDemo.Models;

namespace TabletDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

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

        private Columns column = new Columns();
        public Columns SfGridColumns
        {
            get { return column; }
            set { column = value; }
        }

        public ObservableCollection<string> ListaItemsCombo { get; set; }

        private void GenerarDetalles()
        {
            GrupoConcepto.GrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IDEquipo = "1", CodigoEquipo = "MLT1B", DescripcionEquipo = "1B", IDConcepto = "1", DescripcionConcepto = "TiempoOper", TituloColumna = "datos@texto", Valor = "10" });
            GrupoConcepto.GrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IDEquipo = "1", CodigoEquipo = "MLT1B", DescripcionEquipo = "1B", IDConcepto = "2", DescripcionConcepto = "Tonelaje", TituloColumna = "datos@texto", Valor = "20" });
            GrupoConcepto.GrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IDEquipo = "1", CodigoEquipo = "MLT1B", DescripcionEquipo = "1B", IDConcepto = "3", DescripcionConcepto = "Energia", TituloColumna = "datos@texto", Valor = "30" });
            GrupoConcepto.GrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IDEquipo = "2", CodigoEquipo = "MLT2C", DescripcionEquipo = "2C", IDConcepto = "1", DescripcionConcepto = "TiempoOper", TituloColumna = "datos@texto", Valor = "40" });
            GrupoConcepto.GrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IDEquipo = "2", CodigoEquipo = "MLT2C", DescripcionEquipo = "2C", IDConcepto = "3", DescripcionConcepto = "Energia", TituloColumna = "datos@texto", Valor = "50" });
            GrupoConcepto.GrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IDEquipo = "3", CodigoEquipo = "MLT3C", DescripcionEquipo = "3C", IDConcepto = "2", DescripcionConcepto = "Tonelaje", TituloColumna = "datos@texto", Valor = "33" });
            GrupoConcepto.GrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IDEquipo = "3", CodigoEquipo = "MLT3C", DescripcionEquipo = "3C", IDConcepto = "4", DescripcionConcepto = "CmbEstado", TituloColumna = "datos@texto", Valor = "Soltero" });
            GrupoConcepto.GrupoConceptoDetalle.Add(new GrupoConceptoDetalle() { IDEquipo = "1", CodigoEquipo = "MLT1B", DescripcionEquipo = "1B", IDConcepto = "4", DescripcionConcepto = "CmbEstado", TituloColumna = "datos@texto", Valor = "Casado" });
        }

        private void ConvertirDataTable()
        {
            var equiposAgrupados = GrupoConcepto.GrupoConceptoDetalle.GroupBy(x => new { x.IDEquipo, x.CodigoEquipo, x.DescripcionEquipo }).ToList();
            var conceptos = GrupoConcepto.GrupoConceptoDetalle.Select(detalle => detalle.DescripcionConcepto).Distinct().ToList();

            EquipoConceptos = new DataTable();
            EquipoConceptos.Columns.Add("Equipo");
            SfGridColumns.Add(new GridTextColumn() { MappingName = "Equipo" });
            foreach (var concepto in conceptos)
            {
                EquipoConceptos.Columns.Add(concepto);

                if (concepto == "CmbEstado")
                {
                    SfGridColumns.Add(new GridComboBoxColumn() { MappingName = concepto, ItemsSource = ListaItemsCombo, AllowEditing = true });
                    //SfGridColumns[concepto].ColumnSizer = ColumnSizer.Auto;
                    SfGridColumns[concepto].Width = 250;
                }
                else
                {
                    SfGridColumns.Add(new GridNumericColumn() { MappingName = concepto, HeaderText=concepto+"titulo" });
                    SfGridColumns[concepto].Width = 150;
                }
            }

            for (int i = 0; i < equiposAgrupados.Count; i++)
            {
                EquipoConceptos.Rows.Add();
                EquipoConceptos.Rows[i]["Equipo"] = equiposAgrupados[i].Key.CodigoEquipo;

                foreach (var concepto in conceptos)
                {
                    var valor = equiposAgrupados[i].FirstOrDefault(detalle => detalle.DescripcionConcepto == concepto)?.Valor ?? "";
                    
                    if (concepto == "CmbEstado" && valor == "")
                        EquipoConceptos.Rows[i][concepto] = " ";
                    else
                        EquipoConceptos.Rows[i][concepto] = valor;
                }
            }
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            GrupoConcepto = new GrupoConcepto();
            ListaItemsCombo = new ObservableCollection<string>();
            ListaItemsCombo.Add("Soltero");
            ListaItemsCombo.Add("Casado");
            ListaItemsCombo.Add("Viudo");
            ListaItemsCombo.Add(" ");
            ListaItemsCombo.Add("Divorciado");
            GenerarDetalles();
            ConvertirDataTable();
        }
    }
}
