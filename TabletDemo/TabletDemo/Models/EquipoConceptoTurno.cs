using Prism.Mvvm;

namespace TabletDemo.Models
{
    public class EquipoConceptoTurno : BindableBase
    {
        public EquipoConceptoTurno()
        {

        }

        public int IDEquipoConcepto { get; set; }
        public int NroFila { get; set; }
        public int NroColumna { get; set; }
        public string Valor { get; set; }
        public int EstadoEntidad { get; set; }
    }
}
