# How to set a text column of an SfDataGrid to initially display with password characters?
In this article, we will show you how to set a text column to initially display with password characters in [.Net Maui DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid).

## C#
The below code illustrates how to set a text column to initially display with password characters in DataGrid.
```
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
```
 ![Password.png](https://support.syncfusion.com/kb/agent/attachment/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjI3OTMyIiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.8oAnP-UapfeaU3CYZEoCFU8bXWHC7GIu9o5z-Tzf8gI)

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-set-a-text-column-of-an-SfDataGrid-to-initially-display-with-password-characters)

Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).
 
##### Conclusion
 
I hope you enjoyed learning about how to set a text column to initially display with password characters in .NET MAUI DataGrid (SfDataGrid).
 
You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.
 
If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!
