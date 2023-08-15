using System.Collections.Generic;
using TabletDemo.Models;

namespace TabletDemo.Services
{
    public interface ITabletDemoService
    {
        List<EquipoConceptoTurno> ObtenerDatosTurno(int IDGrupoConcepto);
        List<GridComboBoxModelo> ObtenerDatosXNombreMetodo(string nombreMetodo);
        List<GrupoConceptoDetalle> ObtenerGrupoConceptoDetalle(int IDGrupoConcepto);
    }
}
