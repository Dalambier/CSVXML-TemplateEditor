using System.Windows;
using System.Windows.Input;

namespace CSVXML_TemplateEditor
{
    public partial class FormNewColumn : Window
    {
        public FormNewColumn()
        {
            InitializeComponent();
        }

        private string ColumnName;

        private void CreateColumn(object sender, MouseButtonEventArgs e)
        {
            if (TextFieldColumn.Text != "")
            {
                ColumnName = TextFieldColumn.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show(ProgramSettings.ZeroField, ProgramSettings.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string ShowColumn()
        {
            return ColumnName;
        }

        private void EnterColumnName_Loaded(object sender, RoutedEventArgs e)
        {
            EnterColumnName.Text = ProgramSettings.EnterColumnName;
            EnterButtonText.Text = ProgramSettings.Enter;
        }
    }
}
