using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace TabletDemo.Models
{
    public class EquipoConceptoDic : BindableBase
    {
        public EquipoConceptoDic()
        {
            ListaDic = new Dictionary<string, double>();
        }

        //public string Nombre { get; set; }
        //public Dictionary<string, double> ListaDic { get; set; }

        private Dictionary<string, double> _listaDic;
        public Dictionary<string, double> ListaDic
        {
            get { return _listaDic; }
            set { SetProperty(ref _listaDic, value); }
        }
    }
}
