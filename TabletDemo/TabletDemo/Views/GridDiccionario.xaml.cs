using TabletDemo.Models;
using TabletDemo.Renderers;
using TabletDemo.Resources;
using TabletDemo.ViewModels;
using Xamarin.CommunityToolkit.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabletDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GridDiccionario : ContentPage
    {
        public GridDiccionario()
        {
            LocalizationResourceManager.Current.PropertyChanged += Current_PropertyChanged;
            LocalizationResourceManager.Current.Init(DemoResource.ResourceManager);

            InitializeComponent();
            var viewModel = BindingContext as GridDiccionarioViewModel;
            viewModel.GridPrincipal = gridPrincipal;

            gridPrincipal.CellRenderers.Remove("TextView");
            gridPrincipal.CellRenderers.Add("TextView", new GridCellTextViewRendererExt<EquipoConceptoDic>("ListaDic"));
            gridPrincipal.CellRenderers.Remove("Numeric");
            gridPrincipal.CellRenderers.Add("Numeric", new GridCellNumericRendererExt<EquipoConceptoDic>("ListaDic"));
            gridPrincipal.CellRenderers.Remove("ComboBox");
            gridPrincipal.CellRenderers.Add("ComboBox", new GridCellComboBoxRendererExt<EquipoConceptoDic>("ListaDic"));
            gridPrincipal.CellRenderers.Remove("Template");
            gridPrincipal.CellRenderers.Add("Template", new GridCellTemplateRendererExt<EquipoConceptoDic>("ListaDic"));
        }

        private void Current_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            LocalizationResourceManager.Current.Init(DemoResource.ResourceManager);
            DemoResource.Culture = LocalizationResourceManager.Current.CurrentCulture;
        }
    }
}
