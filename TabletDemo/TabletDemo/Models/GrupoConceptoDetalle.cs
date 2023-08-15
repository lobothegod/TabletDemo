using Prism.Mvvm;

namespace TabletDemo.Models
{
    public class GrupoConceptoDetalle : BindableBase
    {
        public GrupoConceptoDetalle()
        {

        }

        public string Id { get; set; }
        public int IdEquipoConcepto { get; set; }
        public string GrupoConceptoDetalleAux01 { get; set; }
        public short SecuenciaColumna { get; set; }
        public short SecuenciaFila { get; set; }
        public string IDEquipo { get; set; }
        public string EquipoCodRef01 { get; set; }
        public string DescripcionEquipo { get; set; }
        public string IDConcepto { get; set; }
        public string DescripcionEquipoConcepto { get; set; }
        public string CodigoTipoObjeto { get; set; }
        public string ConsultaValorObjeto { get; set; }
        public string CodigoTipoValor { get; set; }
        public byte NumeroDecimales { get; set; }

        private string _valor;
        public string Valor
        {
            get { return _valor; }
            set { SetProperty(ref _valor, value); }
        }

        public GrupoConcepto GrupoConcepto { get; set; }
    }
}
