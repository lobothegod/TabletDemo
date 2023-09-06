using TabletDemo.Models;
using TabletDemo.Renderers;
using TabletDemo.Resources;
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
            GridPrincipal.CellRenderers.Remove("TextView");
            GridPrincipal.CellRenderers.Add("TextView", new GridCellTextViewRendererExt<EquipoConceptoDic>("ListaDic"));

            GridPrincipal.CellRenderers.Remove("Numeric");
            GridPrincipal.CellRenderers.Add("Numeric", new GridCellNumericRendererExt<EquipoConceptoDic>("ListaDic"));

            GridPrincipal.CellRenderers.Remove("ComboBox");
            GridPrincipal.CellRenderers.Add("ComboBox", new GridCellComboBoxRendererExt<EquipoConceptoDic>("ListaDic"));

            GridPrincipal.CellRenderers.Remove("Template");
            GridPrincipal.CellRenderers.Add("Template", new GridCellTemplateRendererExt<EquipoConceptoDic>("ListaDic"));
        }

        private void Current_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            LocalizationResourceManager.Current.Init(DemoResource.ResourceManager);
            DemoResource.Culture = LocalizationResourceManager.Current.CurrentCulture;
        }
    }
}
