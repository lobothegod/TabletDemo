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
        public SfDataGrid GridPrincipal { get; set; }
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
            GridPrincipal.ScrollingMode = ScrollingMode.Line; //temporal para poder editar celdas cuando hay pocas filas (si no hay scroll, no se puede editar)
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

        private void GenerarDataAleatoria()
        {
            var nroFilas = 2;// a partir de 8 filas se puede hacer clic en la celda a editar
            for (int i = 0; i < nroFilas; i++)
            {
                var col1Random = new Random();
                var col2Random = new Random();
                var col3Random = new Random();
                
                var dictionary = new Dictionary<string, object>();
                dictionary.Add("Subject1", "Some text" + col1Random.Next(10, 1000));
                dictionary.Add("Subject2", col2Random.Next(10, 1000));
                dictionary.Add("Subject3", col3Random.Next(1, 4).ToString());

                var equipoConceptoDic = new EquipoConceptoDic();
                equipoConceptoDic.ListaDic = dictionary;
                EquipoConceptoDic.Add(equipoConceptoDic);
            }
        }

        private void CrearEstructuraConDatos()
        {
            SfGridColumns.Add(new GridTextColumn() { MappingName = "ListaDic[Subject1]", HeaderText = "col1 text", ColumnSizer = ColumnSizer.Star });
            SfGridColumns.Add(new GridNumericColumn() { MappingName = "ListaDic[Subject2]", HeaderText = "col2 numeric", NumberDecimalDigits = 0, ColumnSizer = ColumnSizer.Star, AllowNullValue = true });
            SfGridColumns.Add(new GridComboBoxColumn() { MappingName = "ListaDic[Subject3]", HeaderText = "col3 combo", ItemsSource = CargarCombo(), ValueMemberPath = "Codigo", DisplayMemberPath = "Descripcion", AllowEditing = true, ColumnSizer = ColumnSizer.Star, DropDownWidth = 150 });

            EquipoConceptoDic = new ObservableCollection<EquipoConceptoDic>();
            GenerarDataAleatoria();
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
