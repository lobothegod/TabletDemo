using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TabletDemo.Models;
using TabletDemo.Resources;
using TabletDemo.Services;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace TabletDemo.ViewModels
{
    public class GridDiccionarioViewModel : ViewModelBase
    {
        readonly ITabletDemoService _tabletDemoService;

        //Comandos
        public ICommand CurrentCellEndEditCommand { protected set; get; }
        public ICommand BotonCommand { protected set; get; }

        //Variables de pantalla
        private ObservableCollection<EquipoConceptoDic> _equipoConceptoDic;
        public ObservableCollection<EquipoConceptoDic> EquipoConceptoDic
        {
            get { return _equipoConceptoDic; }
            set { SetProperty(ref _equipoConceptoDic, value); }
        }

        //Variables internas
        public Columns SfGridColumns { get; set; } = new Columns();
        public StackedHeaderRowCollection SfGridStackedHeaderRows { get; set; } = new StackedHeaderRowCollection();

        public GridDiccionarioViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            DemoResource.Culture = LocalizationResourceManager.Current.CurrentCulture;
            Title = DemoResource.TitleTabletDemoPage;

            //Comandos
            CurrentCellEndEditCommand = new AsyncCommand<object>(OnCurrentCellEndEdit);
            BotonCommand = new AsyncCommand(OnBoton);

        }

        async Task OnBoton()
        {
            //CrearCabecera();
            CrearEstructuraConDatos();
        }

        async Task OnCurrentCellEndEdit(object obj)
        {
            var e = obj as GridCurrentCellEndEditEventArgs;

            if (Convert.ToString(e.OldValue) != Convert.ToString(e.NewValue))
            {
            }
        }

        private List<GridComboBoxModelo> CargarCombo()
        {
            var listaCombo = new List<GridComboBoxModelo>();
            listaCombo.Add(new GridComboBoxModelo() { Codigo = "1", Descripcion = "Soltero" });
            listaCombo.Add(new GridComboBoxModelo() { Codigo = "2", Descripcion = "Casado" });
            listaCombo.Add(new GridComboBoxModelo() { Codigo = "3", Descripcion = "Viudo" });

            return listaCombo;
        }

        private void CrearEstructuraConDatos()
        {
            SfGridColumns.Add(new GridNumericColumn() { MappingName = "ListaDic[Subject1]", HeaderText = "titulo Subject1", NumberDecimalDigits = 2, ColumnSizer = ColumnSizer.Star });
            SfGridColumns.Add(new GridNumericColumn() { MappingName = "ListaDic[Subject2]", HeaderText = "titulo Subject2", NumberDecimalDigits = 0, ColumnSizer = ColumnSizer.Star });

            EquipoConceptoDic = new ObservableCollection<EquipoConceptoDic>();


            var equipoConceptoDic = new EquipoConceptoDic();

            var dictionary = new Dictionary<string, int?>();
            dictionary.Add("Subject1", 122);
            dictionary.Add("Subject2", null);

            equipoConceptoDic.ListaDic = dictionary;
            EquipoConceptoDic.Add(equipoConceptoDic);


            var equipoConceptoDic2 = new EquipoConceptoDic();

            var dictionary2 = new Dictionary<string, int?>();
            dictionary2.Add("Subject1", 222);
            dictionary2.Add("Subject2", 233);

            equipoConceptoDic2.ListaDic = dictionary2;
            EquipoConceptoDic.Add(equipoConceptoDic2);
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        private void CrearCabecera()
        {
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
        }

        ///////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////
    }
}
