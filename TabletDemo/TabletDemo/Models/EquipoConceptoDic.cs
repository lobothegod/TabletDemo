using System;
using System.Collections.Generic;
using System.Text;

namespace TabletDemo.Models
{
    public class EquipoConceptoDic
    {
        public EquipoConceptoDic()
        {
            ListaDic = new Dictionary<string, int?>();
        }

        //public string Nombre { get; set; }
        public Dictionary<string, int?> ListaDic { get; set; }
    }
}
