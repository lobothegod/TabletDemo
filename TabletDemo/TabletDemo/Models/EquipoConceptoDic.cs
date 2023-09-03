using System;
using System.Collections.Generic;
using System.Text;

namespace TabletDemo.Models
{
    public class EquipoConceptoDic
    {
        public EquipoConceptoDic()
        {
            ListaDic = new Dictionary<string, double>();
        }

        //public string Nombre { get; set; }
        public Dictionary<string, double> ListaDic { get; set; }
    }
}
