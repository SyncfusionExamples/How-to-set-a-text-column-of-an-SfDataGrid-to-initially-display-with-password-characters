using Syncfusion.Maui.DataGrid;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            sfGrid.CellRenderers.Remove("Text");
            sfGrid.CellRenderers.Add("Text", new PasswordCellRenderer());
        }

    }
    public class PasswordCellRenderer : DataGridTextBoxCellRenderer
    {
        private string originalPassword;
        protected override void OnInitializeDisplayView(DataColumnBase dataColumn, SfDataGridLabel? view)
        {
            base.OnInitializeDisplayView(dataColumn, view);
            var mappingName = dataColumn.DataGridColumn.MappingName;
            if (view != null && mappingName == "Name")
            {
                originalPassword = dataColumn.CellValue?.ToString();
                view.Text = new string('●', originalPassword?.Length ?? 0);
                view.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(() => OnCellTapped(view, dataColumn))
                });
            }
        }
        private void OnCellTapped(SfDataGridLabel? passwordCell, DataColumnBase dataColumn)
        {
            passwordCell.Text = dataColumn.CellValue.ToString();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                passwordCell.Text = new string('●', originalPassword.Length);
                return false;
            });
        }
        public override void OnInitializeEditView(DataColumnBase dataColumn, SfDataGridEntry view)
        {
            base.OnInitializeEditView(dataColumn, view);
            var mappingName = dataColumn.DataGridColumn.MappingName;
            if (view != null && mappingName == "Passwrd")
            {
                view.IsPassword = true;
            }
        }
    }
}
