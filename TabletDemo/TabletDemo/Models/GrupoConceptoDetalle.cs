using Prism.Mvvm;

namespace TabletDemo.Models
{
    public class GrupoConceptoDetalle : BindableBase
    {
        public GrupoConceptoDetalle()
        {

        }

        public string Id { get; set; }
        public string IDEquipo { get; set; }
        public string CodigoEquipo { get; set; }
        public string DescripcionEquipo { get; set; }
        public string IDConcepto { get; set; }
        public string DescripcionConcepto { get; set; }
        public string TituloColumna { get; set; }
        public string Valor { get; set; }

        public GrupoConcepto GrupoConcepto { get; set; }
    }
}
