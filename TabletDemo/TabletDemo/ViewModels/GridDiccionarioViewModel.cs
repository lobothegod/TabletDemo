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
            listaCombo.Add(new GridComboBoxModelo() { Codigo = " ", Descripcion = "--Elige--" });
            listaCombo.Add(new GridComboBoxModelo() { Codigo = "1", Descripcion = "Soltero" });
            listaCombo.Add(new GridComboBoxModelo() { Codigo = "2", Descripcion = "Casado" });
            listaCombo.Add(new GridComboBoxModelo() { Codigo = "3", Descripcion = "Viudo" });

            return listaCombo;
        }

        private void CrearEstructuraConDatos()
        {
            SfGridColumns.Add(new GridTextColumn() { MappingName = "ListaDic[Subject1]", HeaderText = "col1 text", ColumnSizer = ColumnSizer.Star });
            SfGridColumns.Add(new GridNumericColumn() { MappingName = "ListaDic[Subject2]", HeaderText = "col2 numeric", NumberDecimalDigits = 0, ColumnSizer = ColumnSizer.Star, AllowNullValue = true });
            SfGridColumns.Add(new GridComboBoxColumn() { MappingName = "ListaDic[Subject3]", HeaderText = "col3 combo", ItemsSource = CargarCombo(), ValueMemberPath = "Codigo", DisplayMemberPath = "Descripcion", AllowEditing = true, ColumnSizer = ColumnSizer.Star, DropDownWidth = 150 });

            EquipoConceptoDic = new ObservableCollection<EquipoConceptoDic>();


            var equipoConceptoDic = new EquipoConceptoDic();

            var dictionary = new Dictionary<string, object>();
            dictionary.Add("Subject1", null);
            dictionary.Add("Subject2", null);
            dictionary.Add("Subject3", " ");

            equipoConceptoDic.ListaDic = dictionary;
            EquipoConceptoDic.Add(equipoConceptoDic);


            var equipoConceptoDic2 = new EquipoConceptoDic();

            var dictionary2 = new Dictionary<string, object>();
            dictionary2.Add("Subject1", "Some text");
            dictionary2.Add("Subject2", 233);
            dictionary2.Add("Subject3", "2");

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
