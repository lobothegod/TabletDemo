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
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace TabletDemo.ViewModels
{
    public class ObjetoPageViewModel : ViewModelBase
    {
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

        public ObjetoPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
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

        private void CrearEstructuraConDatos()
        {
            SfGridColumns.Add(new GridTextColumn() { MappingName = "Nombre", HeaderText = "nombre", ColumnSizer = ColumnSizer.Star });
            SfGridColumns.Add(new GridNumericColumn() { MappingName = "DNI", HeaderText = "dni", NumberDecimalDigits = 0, ColumnSizer = ColumnSizer.Star });

            EquipoConceptoDic = new ObservableCollection<EquipoConceptoDic>();

            var model = new EquipoConceptoDic();
            model.Nombre = "nombre1";
            model.DNI = 415;
            EquipoConceptoDic.Add(model);


            var model2 = new EquipoConceptoDic();
            model2.Nombre = "nombre1";
            model2.DNI = 415;
            EquipoConceptoDic.Add(model2);
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
