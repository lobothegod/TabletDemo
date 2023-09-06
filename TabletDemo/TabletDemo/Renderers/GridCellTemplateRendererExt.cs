using Prism.Mvvm;
using Syncfusion.SfDataGrid.XForms;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TabletDemo.Renderers
{
    public class GridCellTemplateRendererExt<T> : GridCellTemplateRenderer where T : BindableBase
    {
        public string NombreDic { get; set; }

        public GridCellTemplateRendererExt(string nombreDic)
        {
            NombreDic = nombreDic;
        }

        public async override void CommitCellValue(bool isNewValue)
        {
            var editedValue = GetControlValue();
            var editingColumn = DataGrid.Columns[CurrentCellIndex.ColumnIndex];
            var indexCorcheteAbre = editingColumn.MappingName.IndexOf("[");
            var indexCorcheteCierra = editingColumn.MappingName.IndexOf("]");
            var editingColumnName = editingColumn.MappingName.Substring(indexCorcheteAbre + 1, indexCorcheteCierra - indexCorcheteAbre - 1);
            var dataColumn = (CurrentCellElement as GridCell).DataColumn;
            //(dataColumn.RowData as EquipoConceptoDic).ListaDic.Values[editingColumnName] = editedValue;

            var rowData = dataColumn.RowData as T;
            if (rowData != null)
            {
                var listaDic = rowData.GetType().GetProperty(NombreDic)?.GetValue(rowData) as Dictionary<string, object>;
                if (listaDic != null)
                {
                    if (listaDic.ContainsKey(editingColumnName))
                    {
                        listaDic[editingColumnName] = editedValue;
                        await Task.Delay(1);
                        UpdateCellValue(dataColumn);
                        RefreshDisplayValue(dataColumn);
                    }
                }
            }
        }

        protected override void OnUpdateCellValue(DataColumnBase dataColumn)
        {
            var cellValue = SfDataGridHelpers.GetCellValue(this.DataGrid, dataColumn.RowData, dataColumn.GridColumn.MappingName);
            base.OnUpdateCellValue(dataColumn);
        }
    }
}
