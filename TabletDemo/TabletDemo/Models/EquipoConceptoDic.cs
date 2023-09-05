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
            ListaDic = new Dictionary<string, object>();
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { SetProperty(ref _nombre, value); }
        }

        private double _dni;
        public double DNI
        {
            get { return _dni; }
            set { SetProperty(ref _dni, value); }
        }
        //public Dictionary<string, double> ListaDic { get; set; }

        private Dictionary<string, object> _listaDic;
        public Dictionary<string, object> ListaDic
        {
            get { return _listaDic; }
            set { SetProperty(ref _listaDic, value); }
        }
    }
}
