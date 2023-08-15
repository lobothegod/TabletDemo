using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace TabletDemo.Models
{
    public class GrupoConcepto : BindableBase
    {
        public GrupoConcepto()
        {
            GrupoConceptoDetalle = new ObservableCollection<GrupoConceptoDetalle>();
            GrupoConceptoDetalle.CollectionChanged += GrupoConceptoDetalle_CollectionChanged;
        }

        private void GrupoConceptoDetalle_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        }

        public string Id { get; set; }

        public ObservableCollection<GrupoConceptoDetalle> GrupoConceptoDetalle { get; }
    }
}
